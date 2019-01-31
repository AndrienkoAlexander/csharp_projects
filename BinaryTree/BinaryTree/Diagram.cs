using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BinaryTree
{
    public partial class Diagram : Form
    {
        private OperationTime AVL;
        private OperationTime BP;
        private OperationTime BA;

        public Diagram(OperationTime AVL, OperationTime BP, OperationTime BA)
        {
            InitializeComponent();
            this.AVL = AVL;
            this.BP = BP;
            this.BA = BA;
            ColumnDiagram();
            LineDiagramInsert();
            LineDiagramRemove();
            LineDiagramFind();
        }

        private void LineDiagramInsert()
        {
            label2.Text = label2.Text + Environment.NewLine + "АВЛ-дерево" + Environment.NewLine + "y = -2E-05x^2 + 0.0828x + 7.8176" + Environment.NewLine + "Бинарное дерево на указателях" + Environment.NewLine + "y = 2E-05x^2 + 0.2248x + 10.031" + Environment.NewLine + "Бинарное дерево на массиве" + Environment.NewLine + "y = -2E-05x^2 + 0.0828x + 7.8176";
            int size = 10;
            // данные по оси Y
            double[,] yval = new double[3, size];
            yval[0, 0] = 7.901;
            yval[0, 1] = 7.983;
            yval[0, 2] = 8.065;
            yval[0, 3] = 8.148;
            yval[0, 4] = 8.231;
            yval[0, 5] = 8.314;
            yval[0, 6] = 8.396;
            yval[0, 7] = 8.478;
            yval[0, 8] = 8.563;
            yval[0, 9] = 8.642;

            yval[1, 0] = 10.256;
            yval[1, 1] = 10.481;
            yval[1, 2] = 10.706;
            yval[1, 3] = 10.931;
            yval[1, 4] = 11.156;
            yval[1, 5] = 11.381;
            yval[1, 6] = 11.606;
            yval[1, 7] = 11.831;
            yval[1, 8] = 12.056;
            yval[1, 9] = 12.282;

            yval[2, 0] = 14.147;
            yval[2, 1] = 14.4897;
            yval[2, 2] = 14.8324;
            yval[2, 3] = 15.1751;
            yval[2, 4] = 15.5178;
            yval[2, 5] = 15.8605;
            yval[2, 6] = 16.2032;
            yval[2, 7] = 16.5459;
            yval[2, 8] = 16.8886;
            yval[2, 9] = 17.232;

            // значения по оси X
            int[] xval = new int[size];
            xval[0] = 1000;
            xval[1] = 2000;
            xval[2] = 3000;
            xval[3] = 4000;
            xval[4] = 5000;
            xval[5] = 6000;
            xval[6] = 7000;
            xval[7] = 8000;
            xval[8] = 9000;
            xval[9] = 10000;

            chartInsert.Series[0].ChartType = SeriesChartType.Line;
            chartInsert.Series[0].Color = Color.Black; // цвет диаграммы
            // 1. вид маркера данных
            chartInsert.Series[0].MarkerStyle = MarkerStyle.Circle;
            // 2. цвет маркера данных
            chartInsert.Series[0].MarkerColor = Color.Red;
            // 3. размер маркера данных
            chartInsert.Series[0].MarkerSize = 5;

            chartInsert.Titles.Add(" Оценка производительности деревьев ");
            // установка шрифта названия графика
            chartInsert.Titles[0].Font = new Font("Verdana", 12.0f, FontStyle.Bold);
            // координаты вывода названия графика
            chartInsert.Titles[0].Position.X = 40;
            chartInsert.Titles[0].Position.Y = 2;

            chartInsert.ChartAreas[0].AxisX.Title = "Размерность";
            chartInsert.ChartAreas[0].AxisY.Title = "Время выполнения в миллисекундах";
            // выравнивание строки текста
            chartInsert.ChartAreas[0].AxisY.TitleAlignment = StringAlignment.Center; // по центру
            chartInsert.ChartAreas[0].AxisX.TitleAlignment = StringAlignment.Center;
            // установка шрифта по оси Y
            chartInsert.ChartAreas[0].AxisY.TitleFont = new Font("Verdana", 10.0f, FontStyle.Regular);
            // установка шрифта по оси X
            chartInsert.ChartAreas[0].AxisX.TitleFont = new Font("Verdana", 10.0f, FontStyle.Regular);

            // задание имени серии
            chartInsert.Series[0].Name = "АВЛ-дерево";
            // связывание данных с исходной серией
            chartInsert.Series[0].Points.DataBindXY(xval, new double[] { yval[0, 0], yval[0, 1], yval[0, 2], yval[0, 3], yval[0, 4], yval[0, 5], yval[0, 6], yval[0, 7], yval[0, 8], yval[0, 9] });

            Series bp = new Series();
            bp.Name = "Бинарное дерево на указателях";
            // тип диаграммы - колонки
            bp.ChartType = SeriesChartType.Line;
            bp.Color = Color.Red; // цвет диаграммы
            bp.MarkerStyle = MarkerStyle.Circle;
            // 2. цвет маркера данных
            bp.MarkerColor = Color.Black;
            // 3. размер маркера данных
            bp.MarkerSize = 5;
            // связывание серии с данными
            bp.Points.DataBindXY(xval, new double[] { yval[1, 0], yval[1, 1], yval[1, 2], yval[1, 3], yval[1, 4], yval[1, 5], yval[1, 6], yval[1, 7], yval[1, 8], yval[1, 9] });
            // добавление созданной серии в коллекцию серий элемента chart1
            chartInsert.Series.Add(bp);

            Series ba = new Series();
            ba.Name = "Бинарное дерево на массиве";
            // тип диаграммы - колонки
            ba.ChartType = SeriesChartType.Line;
            ba.Color = Color.DarkBlue; // цвет диаграммы
            ba.MarkerStyle = MarkerStyle.Circle;
            // 2. цвет маркера данных
            ba.MarkerColor = Color.Black;
            // 3. размер маркера данных
            ba.MarkerSize = 5;
            // связывание серии с данными
            ba.Points.DataBindXY(xval, new double[] { yval[2, 0], yval[2, 1], yval[2, 2], yval[2, 3], yval[2, 4], yval[2, 5], yval[2, 6], yval[2, 7], yval[2, 8], yval[2, 9] });
            // добавление созданной серии в коллекцию серий элемента chart1
            chartInsert.Series.Add(ba);

            dataGridView2.RowCount = 30;
            for (int i = 0; i < 10; i++)
            {
                dataGridView2[0, i].Value = "АВЛ-дерево";
                dataGridView2[1, i].Value = yval[0, i];
            }
            for (int i = 10; i < 20; i++)
            {
                dataGridView2[0, i].Value = "Бинарное дерево поиска на указателях";
                dataGridView2[1, i].Value = yval[1, i%10];
            }
            for (int i = 20; i < 30; i++)
            {
                dataGridView2[0, i].Value = "Бинарное дерево поиска на массиве";
                dataGridView2[1, i].Value = yval[2, i % 10];
            }
            for (int i = 0; i < 30;i++)
            {
                dataGridView2[2, i].Value = xval[i%10];
            }
        }

        private void LineDiagramRemove()
        {
            label3.Text = label3.Text + Environment.NewLine + "АВЛ-дерево" + Environment.NewLine + "y = 9E-06x^2 + 0.1213x + 10.83" + Environment.NewLine + "Бинарное дерево на указателях" + Environment.NewLine + "y = 5E-06x^2 + 0.2282x + 12.939" + Environment.NewLine + "Бинарное дерево на массиве" + Environment.NewLine + "y = 9E-06x^2 + 0.1213x + 10.83";
            int size = 10;
            // данные по оси Y
            double[,] yval = new double[3, size];
            yval[0, 0] = 10.951;
            yval[0, 1] = 11.0724;
            yval[0, 2] = 11.1938;
            yval[0, 3] = 11.3152;
            yval[0, 4] = 11.4366;
            yval[0, 5] = 11.558;
            yval[0, 6] = 11.6794;
            yval[0, 7] = 11.8008;
            yval[0, 8] = 11.9222;
            yval[0, 9] = 12.044;

            yval[1, 0] = 13.167;
            yval[1, 1] = 13.3952;
            yval[1, 2] = 13.6234;
            yval[1, 3] = 13.8516;
            yval[1, 4] = 14.0798;
            yval[1, 5] = 14.308;
            yval[1, 6] = 14.5362;
            yval[1, 7] = 14.7644;
            yval[1, 8] = 14.9926;
            yval[1, 9] = 15.221;

            yval[2, 0] = 17.45;
            yval[2, 1] = 17.816;
            yval[2, 2] = 18.182;
            yval[2, 3] = 18.548;
            yval[2, 4] = 18.914;
            yval[2, 5] = 19.28;
            yval[2, 6] = 19.646;
            yval[2, 7] = 20.012;
            yval[2, 8] = 20.378;
            yval[2, 9] = 20.744;

            // значения по оси X
            int[] xval = new int[size];
            xval[0] = 1000;
            xval[1] = 2000;
            xval[2] = 3000;
            xval[3] = 4000;
            xval[4] = 5000;
            xval[5] = 6000;
            xval[6] = 7000;
            xval[7] = 8000;
            xval[8] = 9000;
            xval[9] = 10000;

            chartRemove.Series[0].ChartType = SeriesChartType.Line;
            chartRemove.Series[0].Color = Color.Black; // цвет диаграммы
            // 1. вид маркера данных
            chartRemove.Series[0].MarkerStyle = MarkerStyle.Circle;
            // 2. цвет маркера данных
            chartRemove.Series[0].MarkerColor = Color.Red;
            // 3. размер маркера данных
            chartRemove.Series[0].MarkerSize = 5;

            chartRemove.Titles.Add(" Оценка производительности деревьев ");
            // установка шрифта названия графика
            chartRemove.Titles[0].Font = new Font("Verdana", 12.0f, FontStyle.Bold);
            // координаты вывода названия графика
            chartRemove.Titles[0].Position.X = 40;
            chartRemove.Titles[0].Position.Y = 2;

            chartRemove.ChartAreas[0].AxisX.Title = "Размерность";
            chartRemove.ChartAreas[0].AxisY.Title = "Время выполнения в миллисекундах";
            // выравнивание строки текста
            chartRemove.ChartAreas[0].AxisY.TitleAlignment = StringAlignment.Center; // по центру
            chartRemove.ChartAreas[0].AxisX.TitleAlignment = StringAlignment.Center;
            // установка шрифта по оси Y
            chartRemove.ChartAreas[0].AxisY.TitleFont = new Font("Verdana", 10.0f, FontStyle.Regular);
            // установка шрифта по оси X
            chartRemove.ChartAreas[0].AxisX.TitleFont = new Font("Verdana", 10.0f, FontStyle.Regular);

            // задание имени серии
            chartRemove.Series[0].Name = "АВЛ-дерево";
            // связывание данных с исходной серией
            chartRemove.Series[0].Points.DataBindXY(xval, new double[] { yval[0, 0], yval[0, 1], yval[0, 2], yval[0, 3], yval[0, 4], yval[0, 5], yval[0, 6], yval[0, 7], yval[0, 8], yval[0, 9] });

            Series bp = new Series();
            bp.Name = "Бинарное дерево на указателях";
            // тип диаграммы - колонки
            bp.ChartType = SeriesChartType.Line;
            bp.Color = Color.Red; // цвет диаграммы
            bp.MarkerStyle = MarkerStyle.Circle;
            // 2. цвет маркера данных
            bp.MarkerColor = Color.Black;
            // 3. размер маркера данных
            bp.MarkerSize = 5;
            // связывание серии с данными
            bp.Points.DataBindXY(xval, new double[] { yval[1, 0], yval[1, 1], yval[1, 2], yval[1, 3], yval[1, 4], yval[1, 5], yval[1, 6], yval[1, 7], yval[1, 8], yval[1, 9] });
            // добавление созданной серии в коллекцию серий элемента chart1
            chartRemove.Series.Add(bp);

            Series ba = new Series();
            ba.Name = "Бинарное дерево на массиве";
            // тип диаграммы - колонки
            ba.ChartType = SeriesChartType.Line;
            ba.Color = Color.DarkBlue; // цвет диаграммы
            ba.MarkerStyle = MarkerStyle.Circle;
            // 2. цвет маркера данных
            ba.MarkerColor = Color.Black;
            // 3. размер маркера данных
            ba.MarkerSize = 5;
            // связывание серии с данными
            ba.Points.DataBindXY(xval, new double[] { yval[2, 0], yval[2, 1], yval[2, 2], yval[2, 3], yval[2, 4], yval[2, 5], yval[2, 6], yval[2, 7], yval[2, 8], yval[2, 9] });
            // добавление созданной серии в коллекцию серий элемента chart1
            chartRemove.Series.Add(ba);

            dataGridView3.RowCount = 30;
            for (int i = 0; i < 10; i++)
            {
                dataGridView3[0, i].Value = "АВЛ-дерево";
                dataGridView3[1, i].Value = yval[0, i];
            }
            for (int i = 10; i < 20; i++)
            {
                dataGridView3[0, i].Value = "Бинарное дерево поиска на указателях";
                dataGridView3[1, i].Value = yval[1, i % 10];
            }
            for (int i = 20; i < 30; i++)
            {
                dataGridView3[0, i].Value = "Бинарное дерево поиска на массиве";
                dataGridView3[1, i].Value = yval[2, i % 10];
            }
            for (int i = 0; i < 30; i++)
            {
                dataGridView3[2, i].Value = xval[i % 10];
            }
        }

        private void LineDiagramFind()
        {
            label4.Text = label4.Text + Environment.NewLine + "АВЛ-дерево" + Environment.NewLine + "y = 5E-05x^2 + 0.1816x + 5.1676" + Environment.NewLine + "Бинарное дерево на указателях" + Environment.NewLine + "y = 1E-05x^2 + 0.2715x + 7.3396" + Environment.NewLine + "Бинарное дерево на массиве" + Environment.NewLine + "y = 0.0002x^2 + 0.4256x + 10.598";
            int size = 10;
            // данные по оси Y
            double[,] yval = new double[3, size];
            yval[0, 0] = 5.349;
            yval[0, 1] = 5.531;
            yval[0, 2] = 5.713;
            yval[0, 3] = 5.895;
            yval[0, 4] = 6.077;
            yval[0, 5] = 6.259;
            yval[0, 6] = 6.441;
            yval[0, 7] = 6.623;
            yval[0, 8] = 6.805;
            yval[0, 9] = 6.989;

            yval[1, 0] = 7.611;
            yval[1, 1] = 7.8826;
            yval[1, 2] = 8.1542;
            yval[1, 3] = 8.4258;
            yval[1, 4] = 8.6974;
            yval[1, 5] = 8.969;
            yval[1, 6] = 9.2406;
            yval[1, 7] = 9.5122;
            yval[1, 8] = 9.7838;
            yval[1, 9] = 10.056;

            yval[2, 0] = 11.023;
            yval[2, 1] = 11.45;
            yval[2, 2] = 11.877;
            yval[2, 3] = 12.304;
            yval[2, 4] = 12.731;
            yval[2, 5] = 13.158;
            yval[2, 6] = 13.585;
            yval[2, 7] = 14.012;
            yval[2, 8] = 14.439;
            yval[2, 9] = 14.873;

            // значения по оси X
            int[] xval = new int[size];
            xval[0] = 1000;
            xval[1] = 2000;
            xval[2] = 3000;
            xval[3] = 4000;
            xval[4] = 5000;
            xval[5] = 6000;
            xval[6] = 7000;
            xval[7] = 8000;
            xval[8] = 9000;
            xval[9] = 10000;

            chartFind.Series[0].ChartType = SeriesChartType.Line;
            chartFind.Series[0].Color = Color.Black; // цвет диаграммы
            // 1. вид маркера данных
            chartFind.Series[0].MarkerStyle = MarkerStyle.Circle;
            // 2. цвет маркера данных
            chartFind.Series[0].MarkerColor = Color.Red;
            // 3. размер маркера данных
            chartFind.Series[0].MarkerSize = 5;

            chartFind.Titles.Add(" Оценка производительности деревьев ");
            // установка шрифта названия графика
            chartFind.Titles[0].Font = new Font("Verdana", 12.0f, FontStyle.Bold);
            // координаты вывода названия графика
            chartFind.Titles[0].Position.X = 40;
            chartFind.Titles[0].Position.Y = 2;

            chartFind.ChartAreas[0].AxisX.Title = "Размерность";
            chartFind.ChartAreas[0].AxisY.Title = "Время выполнения в миллисекундах";
            // выравнивание строки текста
            chartFind.ChartAreas[0].AxisY.TitleAlignment = StringAlignment.Center; // по центру
            chartFind.ChartAreas[0].AxisX.TitleAlignment = StringAlignment.Center;
            // установка шрифта по оси Y
            chartFind.ChartAreas[0].AxisY.TitleFont = new Font("Verdana", 10.0f, FontStyle.Regular);
            // установка шрифта по оси X
            chartFind.ChartAreas[0].AxisX.TitleFont = new Font("Verdana", 10.0f, FontStyle.Regular);

            // задание имени серии
            chartFind.Series[0].Name = "АВЛ-дерево";
            // связывание данных с исходной серией
            chartFind.Series[0].Points.DataBindXY(xval, new double[] { yval[0, 0], yval[0, 1], yval[0, 2], yval[0, 3], yval[0, 4], yval[0, 5], yval[0, 6], yval[0, 7], yval[0, 8], yval[0, 9] });

            Series bp = new Series();
            bp.Name = "Бинарное дерево на указателях";
            // тип диаграммы - колонки
            bp.ChartType = SeriesChartType.Line;
            bp.Color = Color.Red; // цвет диаграммы
            bp.MarkerStyle = MarkerStyle.Circle;
            // 2. цвет маркера данных
            bp.MarkerColor = Color.Black;
            // 3. размер маркера данных
            bp.MarkerSize = 5;
            // связывание серии с данными
            bp.Points.DataBindXY(xval, new double[] { yval[1, 0], yval[1, 1], yval[1, 2], yval[1, 3], yval[1, 4], yval[1, 5], yval[1, 6], yval[1, 7], yval[1, 8], yval[1, 9] });
            // добавление созданной серии в коллекцию серий элемента chart1
            chartFind.Series.Add(bp);

            Series ba = new Series();
            ba.Name = "Бинарное дерево на массиве";
            // тип диаграммы - колонки
            ba.ChartType = SeriesChartType.Line;
            ba.Color = Color.DarkBlue; // цвет диаграммы
            ba.MarkerStyle = MarkerStyle.Circle;
            // 2. цвет маркера данных
            ba.MarkerColor = Color.Black;
            // 3. размер маркера данных
            ba.MarkerSize = 5;
            // связывание серии с данными
            ba.Points.DataBindXY(xval, new double[] { yval[2, 0], yval[2, 1], yval[2, 2], yval[2, 3], yval[2, 4], yval[2, 5], yval[2, 6], yval[2, 7], yval[2, 8], yval[2, 9] });
            // добавление созданной серии в коллекцию серий элемента chart1
            chartFind.Series.Add(ba);

            dataGridView4.RowCount = 30;
            for (int i = 0; i < 10; i++)
            {
                dataGridView4[0, i].Value = "АВЛ-дерево";
                dataGridView4[1, i].Value = yval[0, i];
            }
            for (int i = 10; i < 20; i++)
            {
                dataGridView4[0, i].Value = "Бинарное дерево поиска на указателях";
                dataGridView4[1, i].Value = yval[1, i % 10];
            }
            for (int i = 20; i < 30; i++)
            {
                dataGridView4[0, i].Value = "Бинарное дерево поиска на массиве";
                dataGridView4[1, i].Value = yval[2, i % 10];
            }
            for (int i = 0; i < 30; i++)
            {
                dataGridView4[2, i].Value = xval[i % 10];
            }
        }

        private void ColumnDiagram()
        {
            int size = 3;
            // данные по оси Y
            long[,] yval = new long[size,size];
            yval[0, 0] = AVL.insert;
            yval[0, 1] = AVL.remove;
            yval[0, 2] = AVL.find;
            yval[1, 0] = BP.insert;
            yval[1, 1] = BP.remove;
            yval[1, 2] = BP.find;
            yval[2, 0] = BA.insert;
            yval[2, 1] = BA.remove;
            yval[2, 2] = BA.find;
            // значения по оси X
            string[] xval = new string[size];
            xval[0] = "Insert";
            xval[1] = "Remove";
            xval[2] = "Search";

            chart.Series[0].ChartType = SeriesChartType.Column;
            chart.Series[0].Color = Color.Black; // цвет диаграммы
            chart.Series[0].BackGradientStyle = GradientStyle.TopBottom;
            // 1. вид маркера данных
            chart.Series[0].MarkerStyle = MarkerStyle.Circle;
            // 2. цвет маркера данных
            chart.Series[0].MarkerColor = Color.Red;
            // 3. размер маркера данных
            chart.Series[0].MarkerSize = 10;

            chart.Titles.Add(" Оценка производительности деревьев ");
            // установка шрифта названия графика
            chart.Titles[0].Font = new Font("Verdana", 12.0f, FontStyle.Bold);
            // координаты вывода названия графика
            chart.Titles[0].Position.X = 40;
            chart.Titles[0].Position.Y = 2;

            chart.ChartAreas[0].AxisX.Title = "Операция";
            chart.ChartAreas[0].AxisY.Title = "Время выполнения в тиках";
            // выравнивание строки текста
            chart.ChartAreas[0].AxisY.TitleAlignment = StringAlignment.Center; // по центру
            chart.ChartAreas[0].AxisX.TitleAlignment = StringAlignment.Center; // около оси
            // установка шрифта по оси Y
            chart.ChartAreas[0].AxisY.TitleFont = new Font("Verdana", 10.0f, FontStyle.Regular);
            // установка шрифта по оси X
            chart.ChartAreas[0].AxisX.TitleFont = new Font("Verdana", 10.0f, FontStyle.Regular);

            // задание имени серии
            chart.Series[0].Name = "АВЛ-дерево";
            // связывание данных с исходной серией
            chart.Series[0].Points.DataBindXY(xval, new long[] { yval[0, 0], yval[0, 1], yval[0, 2] });

            Series bp = new Series();
            bp.Name = "Бинарное дерево на указателях";
            // тип диаграммы - колонки
            bp.ChartType = SeriesChartType.Column;
            bp.BackGradientStyle = GradientStyle.TopBottom; // градиентная заливка
            bp.Color = Color.Red; // цвет диаграммы
            bp.MarkerStyle = MarkerStyle.Circle;
            // 2. цвет маркера данных
            bp.MarkerColor = Color.Black;
            // 3. размер маркера данных
            bp.MarkerSize = 10;
            // связывание серии с данными
            bp.Points.DataBindXY(xval, new double[] { yval[1, 0], yval[1, 1], yval[1, 2] });
            // добавление созданной серии в коллекцию серий элемента chart1
            chart.Series.Add(bp);

            Series ba = new Series();
            ba.Name = "Бинарное дерево на массиве";
            // тип диаграммы - колонки
            ba.ChartType = SeriesChartType.Column;
            ba.BackGradientStyle = GradientStyle.TopBottom; // градиентная заливка
            ba.Color = Color.DarkBlue; // цвет диаграммы
            ba.MarkerStyle = MarkerStyle.Circle;
            // 2. цвет маркера данных
            ba.MarkerColor = Color.Black;
            // 3. размер маркера данных
            ba.MarkerSize = 10;
            // связывание серии с данными
            ba.Points.DataBindXY(xval, new double[] { yval[2, 0], yval[2, 1], yval[2, 2] });
            // добавление созданной серии в коллекцию серий элемента chart1
            chart.Series.Add(ba);

            dataGridView1.RowCount = 9;
            dataGridView1[0, 0].Value = "АВЛ-дерево";
            dataGridView1[0, 1].Value = "АВЛ-дерево";
            dataGridView1[0, 2].Value = "АВЛ-дерево";
            dataGridView1[0, 3].Value = "Бинарное дерево поиска на указателях";
            dataGridView1[0, 4].Value = "Бинарное дерево поиска на указателях";
            dataGridView1[0, 5].Value = "Бинарное дерево поиска на указателях";
            dataGridView1[0, 6].Value = "Бинарное дерево поиска на массиве";
            dataGridView1[0, 7].Value = "Бинарное дерево поиска на массиве";
            dataGridView1[0, 8].Value = "Бинарное дерево поиска на массиве";
            for (int i = 0; i < 7;)
            {
                dataGridView1[1, i].Value = "Вставка";
                i++;
                dataGridView1[1, i].Value = "Удаление";
                i++;
                dataGridView1[1, i].Value = "Поиск";
                i++;
            }
            for(int i = 0, j = 0; i < size*3; j++)
            {
                dataGridView1[2, i].Value = yval[0,j];
                i++;
                dataGridView1[2, i].Value = yval[1, j];
                i++;
                dataGridView1[2, i].Value = yval[2, j];
                i++;
            }
        }
    }
}
