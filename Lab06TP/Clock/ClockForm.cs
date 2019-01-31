using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Clock
{
    public partial class Clock : Form
    {
        /// <summary>
        /// Поле для реализации непрямоугольной формы
        /// </summary>
        private GraphicsPath gPath;
        /// <summary>
        /// Координаты мыши
        /// </summary>
        private Point MousePoint;
        /// <summary>
        /// Форма с информацией о программе
        /// </summary>
        private AboutProgram about;
        /// <summary>
        /// Графика для прорисовки
        /// </summary>
        private Graphics graphics;
        /// <summary>
        /// Размер циферблата
        /// </summary>
        private int Lenght;
        /// <summary>
        /// Вспомогательное поле с предыдущим временем
        /// </summary>
        private DateTime initialDT;
        /// <summary>
        /// Объект с настройками часов
        /// </summary>
        private Settings settings;

        public Clock()
        {
            InitializeComponent();
            gPath = new GraphicsPath();
            MousePoint = new Point();
            ContextMenuStrip = contextMenuStrip1;
            graphics = this.CreateGraphics();
            graphics.SmoothingMode = SmoothingMode.HighQuality; // Режим сглаживания
            timer1 = new Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1000; // Интервал таймера 1 секунда
            timer1.Enabled = true; // Таймер включен
            settings = new Settings();
            settings.SaveInitialSettings(); // Сохранить исходные настройки
            if (!settings.LoadUserSettings()) // Загрузить настройки пользователя 
                settings.ResetSettings(); // Если произошла ошибка, то загрузить базовые настройки
            BackColor = Color.FromArgb(settings.CForm); // Установка размеров и цвета формы
            Width = settings.SForm.Width;
            Height = settings.SForm.Height;
            Lenght = settings.ClockLenght;
        }



        private Point RadiaPoint(Point ptCenter, int R, int seconds) // Вспомогательные метод для получения координат при прорисовке цифр
        {
            double angle = -((seconds - 15) % 60) * Math.PI / 30;
            return new Point(ptCenter.X + (int)(R * Math.Cos(angle)),
                ptCenter.Y - (int)(R * Math.Sin(angle)));
        }

        private void Clock_MouseMove(object sender, MouseEventArgs e) // Метод для перемещения формы
        {
            if (e.Button == MouseButtons.Left)
            {
                Location = new Point(Location.X + (e.X - MousePoint.X), Location.Y + (e.Y - MousePoint.Y));

            }
        }

        private void Clock_MouseDown(object sender, MouseEventArgs e)
        {
            MousePoint.X = e.X; MousePoint.Y = e.Y;
        }

        /// <summary>
        /// Обработчик нажатия на элемент контекстного меню "Выход"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitStripMenuItem1_Click(object sender, EventArgs e)
        {
            settings.SaveUserSettings();
            Close();
        }
        /// <summary>
        /// Обработчик нажатия на элемент контекстного меню "О программе"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AboutProgramStripMenuItem1_Click(object sender, EventArgs e)
        {
            about = new AboutProgram();
            about.Show();
        }

        //общая прорисовка часов
        private void PaintClock(DateTime dtArg)
        {
            //циферблат
            PaintCircle();
            //Цифры
            PaintDigits();
            //стрелки
            PaintArrows(dtArg);
            //Цифровое время
            if(settings.DigitalCl)
                PaintStringTime(DateTime.Now);

        }
        /// <summary>
        /// Обработчик тика таймера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            // Прорисовываем стрелки
            PaintArrows(DateTime.Now);
            if(settings.DigitalCl)
                // Прорисовываем цифровые часы
                PaintStringTime(DateTime.Now);
            // Прорисовываем цифры
            PaintDigits();
        }

        // Прорисовка циферблата
        private void PaintCircle()
        {
            int Mx = ClientRectangle.Width;
            int My = ClientRectangle.Height;
            int R = Math.Min(Mx, My) / 2 - 1;
            Point ptCenter = new Point(Mx / 2, My / 2);
            gPath.Reset();
            if (settings.FormStyle == 1)
            {
                gPath.AddEllipse(
                    (int)(this.ClientRectangle.Width / 2 - Lenght),
                    (int)(this.ClientRectangle.Height / 2 - Lenght),
                    (int)Lenght * 2, (int)Lenght * 2);
                Region = new Region(gPath);
            }
            else
            {
                Rectangle rec = new Rectangle(
                    (int)(this.ClientRectangle.Width / 2 - Lenght),
                    (int)(this.ClientRectangle.Height / 2 - Lenght),
                    (int)Lenght * 2, (int)Lenght * 2);
                gPath.AddRectangle(rec);
                Region = new Region(gPath);
            }

            if (settings.Division == 1)
            {
                //прорисовка линий, который указывают на деления минут
                for (int i = 0; i < 60; i++)
                {
                    graphics.DrawLine(new Pen(new SolidBrush(Color.FromArgb(settings.CDivision)), 1),
                        new Point((int)(ClientRectangle.Width / 2), (int)(ClientRectangle.Height / 2)),
                        new Point((int)(ClientRectangle.Width / 2 + Lenght * Math.Cos(Math.PI / 30 * i)), (int)(ClientRectangle.Height / 2 + Lenght * Math.Sin(Math.PI / 30 * i))));
                }

                //прорисовка круга, который закрывает внутреннюю часть линий чтобы остались только черточки
                //этот круг меньше диаметром внешней окружности
                graphics.FillEllipse(
                    new SolidBrush(BackColor),
                    new Rectangle(
                        new Point(
                            (int)(this.ClientRectangle.Width / 2 - Lenght + 10),
                            (int)(this.ClientRectangle.Height / 2 - Lenght + 10)),
                            new Size((int)(Lenght - 10) * 2, (int)(Lenght - 10) * 2)));

                //прорисовка линий, который указывают на деления часов
                for (int i = 0; i < 12; i++)
                {
                    graphics.DrawLine(new Pen(new SolidBrush(Color.FromArgb(settings.CDivision)), 3),
                        new Point((int)(ClientRectangle.Width / 2), (int)(ClientRectangle.Height / 2)),
                        new Point((int)(ClientRectangle.Width / 2 + Lenght * Math.Cos(Math.PI / 6 * i)), (int)(ClientRectangle.Height / 2 + Lenght * Math.Sin(Math.PI / 6 * i))));
                }

                //прорисовка круга, который закрывает внутреннюю часть линий чтобы остались только черточки
                //этот круг меньше диаметром внешней окружности
                graphics.FillEllipse(
                    new SolidBrush(BackColor),
                    new Rectangle(
                        new Point(
                            (int)(this.ClientRectangle.Width / 2 - Lenght + 15),
                            (int)(this.ClientRectangle.Height / 2 - Lenght + 15)),
                            new Size((int)(Lenght - 15) * 2, (int)(Lenght - 15) * 2)));
            }
            else
            {
                for (int minute = 0; minute < 60; minute++)
                {
                    Point pt = RadiaPoint(ptCenter, R - 25, minute);
                    using (SolidBrush BS = new SolidBrush(Color.FromArgb(settings.CDivision)))
                    {
                        if ((minute % 5) == 0) graphics.FillRectangle(BS, pt.X - 3, pt.Y - 3, 7, 7);
                        else graphics.FillRectangle(BS, pt.X - 1, pt.Y - 1, 2, 2);
                    }
                }
            }

            // Прорисовка окантовки часов
            if (settings.FormStyle == 1)
            {
                graphics.DrawEllipse(
                    new Pen(
                        new SolidBrush(Color.Black), 8),
                    new Rectangle(
                        new Point(
                            (int)(this.ClientRectangle.Width / 2 - Lenght),
                            (int)(this.ClientRectangle.Height / 2 - Lenght)),
                        new Size((int)Lenght * 2, (int)Lenght * 2)));
            }
            else
            {
                graphics.DrawRectangle(
                    new Pen(
                        new SolidBrush(Color.Black), 8),
                    new Rectangle(
                        new Point(
                            (int)(this.ClientRectangle.Width / 2 - Lenght),
                            (int)(this.ClientRectangle.Height / 2 - Lenght)),
                    new Size((int)Lenght * 2, (int)Lenght * 2)));
            }

        }

        // Прорисовка цифр на циферблате
        private void PaintDigits()
        {
            int Mx = ClientRectangle.Width;
            int My = ClientRectangle.Height;
            int R = Math.Min(Mx, My) / 2 - 1;
            Font font;
            Point ptCenter = new Point(Mx / 2, My / 2);
            font = new Font("Times New Roman", 15, FontStyle.Bold);
            int hour = 1;
            for (int minute = 5; minute <= 60; minute = minute + 5)
            {
                Point pt = RadiaPoint(ptCenter, R - 40, minute);
                using (SolidBrush BS = new SolidBrush(Color.FromArgb(settings.Digit)))
                {
                    graphics.DrawString(hour.ToString(), font, BS, pt.X - 10, pt.Y - 10);
                }
                hour++;
            }
        }

        //прорисовка стрелок часов
        private void PaintArrows(DateTime dt)
        {
            if (settings.DigitalCl)
            {
                graphics.FillEllipse(
                    new SolidBrush(BackColor),
                    new Rectangle(
                        new Point(
                    (int)(this.ClientRectangle.Width / 2 - Lenght / 2),
                    (int)(this.ClientRectangle.Height / 2 - Lenght / 2)),
                    new Size((int)(Lenght / 2) * 2, (int)(Lenght / 2) * 2)));
            }

            //очистка секундной стрелки
            graphics.DrawLine(
                new Pen(new SolidBrush(BackColor), 3.8F),
                new Point((int)(ClientRectangle.Width / 2), (int)(ClientRectangle.Height / 2)),
                new Point((int)(ClientRectangle.Width / 2 + (Lenght - 15) * Math.Sin(2 * Math.PI / 60 * (initialDT.Second))), (int)(ClientRectangle.Height / 2 - (Lenght - 15) * Math.Cos(2 * Math.PI / 60 * (initialDT.Second)))));
            //очистка минутной стрелки
                graphics.DrawLine(
                    new Pen(new SolidBrush(BackColor), 5),
                    new Point((int)(ClientRectangle.Width / 2), (int)(ClientRectangle.Height / 2)),
                    new Point((int)(ClientRectangle.Width / 2 + (Lenght - 20) * Math.Sin(2 * Math.PI / 60 * (initialDT.Minute))), (int)(ClientRectangle.Height / 2 - (Lenght - 20) * Math.Cos(2 * Math.PI / 60 * (initialDT.Minute)))));
            //определения количества часов, прошедших после полудня или после полуночи
            //фактически перевод 23=>11 и так далее
            int initialhour;
            if (dt.Hour <= 12)
            {
                initialhour = initialDT.Hour;
            }
            else
            {
                initialhour = initialDT.Hour - 12;
            }
            //очистка часовой стрелки
                graphics.DrawLine(
                    new Pen(new SolidBrush(BackColor), 6),
                    new Point((int)(ClientRectangle.Width / 2), (int)(ClientRectangle.Height / 2)),
                    new Point((int)(ClientRectangle.Width / 2 + (Lenght - 30) * Math.Sin(2 * Math.PI / 12 * (initialhour) + 2 * Math.PI / (12 * 60) * initialDT.Minute)), (int)(ClientRectangle.Height / 2 - (Lenght - 30) * Math.Cos(2 * Math.PI / 12 * (initialhour-1) + 2 * Math.PI / (12 * 60) * initialDT.Minute))));

            //определения количества часов, прошедших после полудня или после полуночи
            //фактически перевод 23=>11 и так далее
            int hour;
            if (dt.Hour <= 12)
            {
                hour = dt.Hour;
            }
            else
            {
                hour = dt.Hour - 12;
            }
            //прорисовка секундной стрелки
            graphics.DrawLine(
                new Pen(new SolidBrush(Color.FromArgb(settings.Second)), 2),
                new Point((int)(ClientRectangle.Width / 2), (int)(ClientRectangle.Height / 2)),
                new Point((int)(ClientRectangle.Width / 2 + (Lenght - 16) * Math.Sin(2 * Math.PI / 60 * dt.Second)), (int)(ClientRectangle.Height / 2 - (Lenght - 16) * Math.Cos(2 * Math.PI / 60 * dt.Second))));
            //прорисовка минутной стрелки
            graphics.DrawLine(
                new Pen(new SolidBrush(Color.FromArgb(settings.Minute)), 3),
                new Point((int)(ClientRectangle.Width / 2), (int)(ClientRectangle.Height / 2)),
                new Point((int)(ClientRectangle.Width / 2 + (Lenght - 20) * Math.Sin(2 * Math.PI / 60 * dt.Minute)), (int)(ClientRectangle.Height / 2 - (Lenght - 20) * Math.Cos(2 * Math.PI / 60 * dt.Minute))));
            //прорисовка часовой стрелки
            graphics.DrawLine(
                new Pen(new SolidBrush(Color.FromArgb(settings.Hour)), 4),
                new Point((int)(ClientRectangle.Width / 2), (int)(ClientRectangle.Height / 2)),
                new Point((int)(ClientRectangle.Width / 2 + (Lenght - 30) * Math.Sin(2 * Math.PI / 12 * hour + 2 * Math.PI / (12 * 60) * dt.Minute)), (int)(ClientRectangle.Height / 2 - (Lenght - 30) * Math.Cos(2 * Math.PI / 12 * hour + 2 * Math.PI / (12 * 60) * dt.Minute))));
            initialDT = dt;
        }

        // При первом показе формы
        private void Clock_Shown(object sender, EventArgs e)
        {
            initialDT = DateTime.Now;
            PaintClock(DateTime.Now);
        }

        // Прорисовка цифровых часов
        private void PaintStringTime(DateTime dt)
        {
            Font font;
            SolidBrush brush = new SolidBrush(Color.FromArgb(settings.CDigitalClock));
            if(settings.SForm.Width == 150)
                font = new Font("Times New Roman", 8, FontStyle.Regular);
            else
                font = new Font("Times New Roman", 12, FontStyle.Regular);
            graphics.DrawString(dt.ToLongTimeString(), font, brush, new Point(ClientRectangle.Width / 2 - Lenght/2, ClientRectangle.Height / 2 + Lenght/4));
        }

        private void Clock_Load(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.DoubleBuffer, true);
        }

        /// <summary>
        /// Обработчик нажатия на элемент контекстного меню "2 стиль"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            settings.Division = 2;
            Refresh();
            PaintClock(DateTime.Now);
        }

        /// <summary>
        /// Обработчик нажатия на элемент контекстного меню "Часовая стрелка"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HourArrowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // создание диалога выбора цвета
            ColorDialog cd = new ColorDialog();
            DialogResult r;
            // вызов диалога выбора цвета
            r = cd.ShowDialog();
            // выход из обработчика если DialogResult=Cancel
            if (r == DialogResult.Cancel) return;
            // присвоения выбранного цвета значению backColor
            settings.Hour = cd.Color.ToArgb();
            PaintArrows(DateTime.Now);
        }

        /// <summary>
        /// Обработчик нажатия на элемент контекстного меню "Сброс настроек"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settings.ResetSettings();
            BackColor = Color.FromArgb(settings.CForm);
            Width = settings.SForm.Width;
            Height = settings.SForm.Height;
            Lenght = settings.ClockLenght;
            Refresh();
            PaintClock(DateTime.Now);
            DigitalClockToolStripMenuItem.Checked = false;
        }
        /// <summary>
        /// Обработчик нажатия на элемент контекстного меню "Минутная стрелка"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MinuteArrowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // создание диалога выбора цвета
            ColorDialog cd = new ColorDialog();
            DialogResult r;
            // вызов диалога выбора цвета
            r = cd.ShowDialog();
            // выход из обработчика если DialogResult=Cancel
            if (r == DialogResult.Cancel) return;
            // присвоения выбранного цвета значению backColor
            settings.Minute = cd.Color.ToArgb();
            PaintArrows(DateTime.Now);
        }

        /// <summary>
        /// Обработчик нажатия на элемент контекстного меню "Секундная стрелка"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SecondArrowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // создание диалога выбора цвета
            ColorDialog cd = new ColorDialog();
            DialogResult r;
            // вызов диалога выбора цвета
            r = cd.ShowDialog();
            // выход из обработчика если DialogResult=Cancel
            if (r == DialogResult.Cancel) return;
            // присвоения выбранного цвета значению backColor
            settings.Second = cd.Color.ToArgb();
            PaintArrows(DateTime.Now);
        }
        /// <summary>
        /// Обработчик нажатия на элемент контекстного меню "Цифры"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DigitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // создание диалога выбора цвета
            ColorDialog cd = new ColorDialog();
            DialogResult r;
            // вызов диалога выбора цвета
            r = cd.ShowDialog();
            // выход из обработчика если DialogResult=Cancel
            if (r == DialogResult.Cancel) return;
            // присвоения выбранного цвета значению backColor
            settings.Digit = cd.Color.ToArgb();
            PaintDigits();
        }
        /// <summary>
        /// Обработчик нажатия на элемент контекстного меню "Форма"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // создание диалога выбора цвета
            ColorDialog cd = new ColorDialog();
            DialogResult r;
            // вызов диалога выбора цвета
            r = cd.ShowDialog();
            // выход из обработчика если DialogResult=Cancel
            if (r == DialogResult.Cancel) return;
            // присвоения выбранного цвета значению backColor
            settings.CForm = cd.Color.ToArgb();
            BackColor = Color.FromArgb(settings.CForm);
            Refresh();
            PaintClock(DateTime.Now);
        }
        /// <summary>
        /// Обработчик нажатия на элемент контекстного меню "Деления"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DivisionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // создание диалога выбора цвета
            ColorDialog cd = new ColorDialog();
            DialogResult r;
            // вызов диалога выбора цвета
            r = cd.ShowDialog();
            // выход из обработчика если DialogResult=Cancel
            if (r == DialogResult.Cancel) return;
            // присвоения выбранного цвета значению backColor
            settings.CDivision = cd.Color.ToArgb();
            PaintClock(DateTime.Now);
        }
        /// <summary>
        /// Обработчик нажатия на элемент контекстного меню "Цифровые часы"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DigitalClockColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // создание диалога выбора цвета
            ColorDialog cd = new ColorDialog();
            DialogResult r;
            // вызов диалога выбора цвета
            r = cd.ShowDialog();
            // выход из обработчика если DialogResult=Cancel
            if (r == DialogResult.Cancel) return;
            // присвоения выбранного цвета значению backColor
            settings.CDigitalClock = cd.Color.ToArgb();
            PaintClock(DateTime.Now);
        }
        /// <summary>
        /// Обработчик нажатия на элемент контекстного меню "Цифровые часы"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DigitalClockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settings.DigitalCl = !settings.DigitalCl;
            PaintClock(DateTime.Now);
        }
        /// <summary>
        /// Обработчик нажатия на элемент контекстного меню "1 стиль"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FirstStyletoolStripMenuItem2_Click(object sender, EventArgs e)
        {
            settings.Division = 1;
            Refresh();
            PaintClock(DateTime.Now);
        }
        /// <summary>
        /// Обработчик нажатия на элемент контекстного меню "Средний размер"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MidleSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settings.SForm = new Size(180, 198);
            settings.ClockLenght = 75;
            Width = settings.SForm.Width;
            Height = settings.SForm.Height;
            Lenght = settings.ClockLenght;
            gPath.Reset();
            Refresh();
            PaintClock(DateTime.Now);
         }
        /// <summary>
        /// Обработчик нажатия на элемент контекстного меню "Маленький размер"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SmalSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settings.SForm = new Size(150, 168);
            settings.ClockLenght = 60;
            Width = settings.SForm.Width;
            Height = settings.SForm.Height;
            Lenght = settings.ClockLenght;
            gPath.Reset();
            Refresh();
            PaintClock(DateTime.Now);
        }
        /// <summary>
        /// Обработчик нажатия на элемент контекстного меню "Большой размер"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BigSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settings.SForm = new Size(210, 228);
            settings.ClockLenght = 90;
            Width = settings.SForm.Width;
            Height = settings.SForm.Height;
            Lenght = settings.ClockLenght;
            gPath.Reset();
            Refresh();
            PaintClock(DateTime.Now);
        }
        /// <summary>
        /// Обработчик нажатия на элемент контекстного меню "Окружность"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CircleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settings.FormStyle = 1;
            gPath.Reset();
            Refresh();
            PaintClock(DateTime.Now);
        }
        /// <summary>
        /// Обработчик нажатия на элемент контекстного меню "Квадрат"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SquareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settings.FormStyle = 2;
            gPath.Reset();
            Refresh();
            PaintClock(DateTime.Now);
        }
    }
}
