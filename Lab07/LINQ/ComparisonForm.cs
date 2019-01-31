using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Windows.Forms.DataVisualization.Charting;

namespace LINQ
{
    public partial class ComparisonForm : Form
    {
        private Stopwatch sw1;
        private Stopwatch sw2;
        private long[,] LINQTime;
        private long[,] CSharpTime;

        public ComparisonForm()
        {
            InitializeComponent();
        }

        private void ComparisonForm_Shown(object sender, EventArgs e)
        {
            sw1 = new Stopwatch();
            sw2 = new Stopwatch();
            LINQTime = new long[3, 10];
            CSharpTime = new long[3, 10];
            TestLINQMethods();
            TestCSharpMethods();
            FillDGV();
            DrawGraphics();
        }

        private void TestLINQMethods()
        {
            int size = 1000;
            int[] data = null;
            for (int i = 0; i < 10; i++)
            {
                GenerateArray(ref data, size);
                size = size + 1000;

                sw1.Start();
                int res = data.OrderBy(n => n).First();
                sw1.Stop();
                LINQTime[0, i] = sw1.Elapsed.Ticks;
                sw1.Reset();

                sw1.Start();
                // фильтр Where(n => n < 500) + Count()
                res = data.Where(n => n < 500).Count();
                sw1.Stop();
                LINQTime[1, i] = sw1.Elapsed.Ticks;
                sw1.Reset();

                sw1.Start();
                res = data.Sum(n => n);
                sw1.Stop();
                LINQTime[2, i] = sw1.Elapsed.Ticks;
                sw1.Reset();
            }
        }

        private void TestCSharpMethods()
        {
            int size = 1000;
            int[] data = null;
            int res = 0;
            for (int i = 0; i < 10; i++)
            {
                GenerateArray(ref data, size);
                size = size + 1000;

                sw2.Start();
                Array.Sort(data);
                res = data[0];
                sw2.Stop();
                CSharpTime[0, i] = sw2.Elapsed.Ticks;
                sw2.Reset();

                sw2.Start();
                // определение в массиве количества элементов, меньших значения 500
                res = 0; // количество элементов
                for (int j = 0; j < data.Length; ++j)
                    if (data[j] < 500) res++;
                sw2.Stop();
                CSharpTime[1, i] = sw2.Elapsed.Ticks;
                sw2.Reset();

                sw2.Start();
                res = 0;
                for (int j = 0; j < data.Length; ++j)
                    res= res + data[j];
                sw2.Stop();
                CSharpTime[2, i] = sw2.Elapsed.Ticks;
                sw2.Reset();
            }
        }

        private void GenerateArray(ref int[]data, int size)
        {
            data = new int[size];
            Random r = new Random();
            for(int i = 0; i < size; i++)
            {
                data[i] = r.Next(-1000, 1000);
            }
        }

        private void DrawGraphics()
        {
            long[] yval = new long[10];
            // значения по оси X
            int[] xval = new int[10];
            xval[0] = 1000;
            for (int i = 1; i < 10; i++)
            {
                xval[i] = xval[i - 1] + 1000;
            }

            chart1.Series[0].ChartType = SeriesChartType.Line;
            chart1.Series[0].Color = Color.Black; // цвет диаграммы
            // 1. вид маркера данных
            chart1.Series[0].MarkerStyle = MarkerStyle.Circle;
            // 2. цвет маркера данных
            chart1.Series[0].MarkerColor = Color.Red;
            // 3. размер маркера данных
            chart1.Series[0].MarkerSize = 5;

            chart1.ChartAreas[0].AxisX.Title = "Размерность";
            chart1.ChartAreas[0].AxisY.Title = "Время(тики)";
            // выравнивание строки текста
            chart1.ChartAreas[0].AxisY.TitleAlignment = StringAlignment.Center; // по центру
            chart1.ChartAreas[0].AxisX.TitleAlignment = StringAlignment.Center; // около оси
            // установка шрифта по оси Y
            chart1.ChartAreas[0].AxisY.TitleFont = new Font("Verdana", 10.0f, FontStyle.Regular);
            // установка шрифта по оси X
            chart1.ChartAreas[0].AxisX.TitleFont = new Font("Verdana", 10.0f, FontStyle.Regular);

            // задание имени серии
            chart1.Series[0].Name = "LINQ";
            // связывание данных с исходной серией
            for (int i = 0; i < 10; i++)
                yval[i] = LINQTime[0, i];
            chart1.Series[0].Points.DataBindXY(xval, yval);

            Series bp = new Series();
            bp.Name = "C#";
            // тип диаграммы - колонки
            bp.ChartType = SeriesChartType.Line;
            bp.Color = Color.Red; // цвет диаграммы
            bp.MarkerStyle = MarkerStyle.Circle;
            // 2. цвет маркера данных
            bp.MarkerColor = Color.Black;
            // 3. размер маркера данных
            bp.MarkerSize = 5;
            // связывание серии с данными
            for (int i = 0; i < 10; i++)
                yval[i] = CSharpTime[0, i];
            bp.Points.DataBindXY(xval, yval);
            // добавление созданной серии в коллекцию серий элемента chart1
            chart1.Series.Add(bp);
            //-------------------------------------------------------------------
            chart2.Series[0].ChartType = SeriesChartType.Line;
            chart2.Series[0].Color = Color.Black; // цвет диаграммы
            // 1. вид маркера данных
            chart2.Series[0].MarkerStyle = MarkerStyle.Circle;
            // 2. цвет маркера данных
            chart2.Series[0].MarkerColor = Color.Red;
            // 3. размер маркера данных
            chart2.Series[0].MarkerSize = 5;

            chart2.ChartAreas[0].AxisX.Title = "Размерность";
            chart2.ChartAreas[0].AxisY.Title = "Время(тики)";
            // выравнивание строки текста
            chart2.ChartAreas[0].AxisY.TitleAlignment = StringAlignment.Center; // по центру
            chart2.ChartAreas[0].AxisX.TitleAlignment = StringAlignment.Center; // около оси
            // установка шрифта по оси Y
            chart2.ChartAreas[0].AxisY.TitleFont = new Font("Verdana", 10.0f, FontStyle.Regular);
            // установка шрифта по оси X
            chart2.ChartAreas[0].AxisX.TitleFont = new Font("Verdana", 10.0f, FontStyle.Regular);

            // задание имени серии
            chart2.Series[0].Name = "LINQ";
            // связывание данных с исходной серией
            for (int i = 0; i < 10; i++)
                yval[i] = LINQTime[1, i];
            chart2.Series[0].Points.DataBindXY(xval, yval);

            Series bp1 = new Series();
            bp1.Name = "C#";
            // тип диаграммы - колонки
            bp1.ChartType = SeriesChartType.Line;
            bp1.Color = Color.Red; // цвет диаграммы
            bp1.MarkerStyle = MarkerStyle.Circle;
            // 2. цвет маркера данных
            bp1.MarkerColor = Color.Black;
            // 3. размер маркера данных
            bp1.MarkerSize = 5;
            // связывание серии с данными
            for (int i = 0; i < 10; i++)
                yval[i] = CSharpTime[1, i];
            bp1.Points.DataBindXY(xval, yval);
            // добавление созданной серии в коллекцию серий элемента chart1
            chart2.Series.Add(bp1);
            //-------------------------------------------------------------------
            chart3.Series[0].ChartType = SeriesChartType.Line;
            chart3.Series[0].Color = Color.Black; // цвет диаграммы
            // 1. вид маркера данных
            chart3.Series[0].MarkerStyle = MarkerStyle.Circle;
            // 2. цвет маркера данных
            chart3.Series[0].MarkerColor = Color.Red;
            // 3. размер маркера данных
            chart3.Series[0].MarkerSize = 5;

            chart3.ChartAreas[0].AxisX.Title = "Размерность";
            chart3.ChartAreas[0].AxisY.Title = "Время(тики)";
            // выравнивание строки текста
            chart3.ChartAreas[0].AxisY.TitleAlignment = StringAlignment.Center; // по центру
            chart3.ChartAreas[0].AxisX.TitleAlignment = StringAlignment.Center; // около оси
            // установка шрифта по оси Y
            chart3.ChartAreas[0].AxisY.TitleFont = new Font("Verdana", 10.0f, FontStyle.Regular);
            // установка шрифта по оси X
            chart3.ChartAreas[0].AxisX.TitleFont = new Font("Verdana", 10.0f, FontStyle.Regular);

            // задание имени серии
            chart3.Series[0].Name = "LINQ";
            // связывание данных с исходной серией
            for (int i = 0; i < 10; i++)
                yval[i] = LINQTime[2, i];
            chart3.Series[0].Points.DataBindXY(xval, yval);

            Series bp2 = new Series();
            bp2.Name = "C#";
            // тип диаграммы - колонки
            bp2.ChartType = SeriesChartType.Line;
            bp2.Color = Color.Red; // цвет диаграммы
            bp2.MarkerStyle = MarkerStyle.Circle;
            // 2. цвет маркера данных
            bp2.MarkerColor = Color.Black;
            // 3. размер маркера данных
            bp2.MarkerSize = 5;
            // связывание серии с данными
            for (int i = 0; i < 10; i++)
                yval[i] = CSharpTime[2, i];
            bp2.Points.DataBindXY(xval, yval);
            // добавление созданной серии в коллекцию серий элемента chart1
            chart3.Series.Add(bp2);
        }

        private void FillDGV()
        {
            DGV.RowCount = 60;
            int size = 1000;
            for (int i = 0; i < 20; i++)
            {
                DGV[0, i].Value = "LINQ";
                DGV[1, i].Value = "Сортировка";
                DGV[2, i].Value = LINQTime[0, i/2];
                DGV[3, i].Value = size;
                i++;
                DGV[0, i].Value = "C#";
                DGV[1, i].Value = "Сортировка";
                DGV[2, i].Value = CSharpTime[0, i / 2];
                DGV[3, i].Value = size;
                size = size + 1000;
            }

            size = 1000;
            for (int i = 20, j = 0; i < 40; i++, j++)
            {
                DGV[0, i].Value = "LINQ";
                DGV[1, i].Value = "Фильтрация";
                DGV[2, i].Value = LINQTime[1, j / 2];
                DGV[3, i].Value = size;
                i++;
                DGV[0, i].Value = "C#";
                DGV[1, i].Value = "Фильтрация";
                DGV[2, i].Value = CSharpTime[1, j / 2];
                DGV[3, i].Value = size;
                size = size + 1000;
            }

            size = 1000;
            for (int i = 40, j = 0; i < 60; i++, j++)
            {
                DGV[0, i].Value = "LINQ";
                DGV[1, i].Value = "Сумма";
                DGV[2, i].Value = LINQTime[2, j / 2];
                DGV[3, i].Value = size;
                i++;
                DGV[0, i].Value = "C#";
                DGV[1, i].Value = "Сумма";
                DGV[2, i].Value = CSharpTime[2, j / 2];
                DGV[3, i].Value = size;
                size = size + 1000;
            }
        }
    }
}
