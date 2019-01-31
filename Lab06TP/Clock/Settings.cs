using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;
using System.Drawing;
using System.Xml.Serialization;

namespace Clock
{
    [Serializable]
    public class Settings
    {
        private int HourArrow; // Цвет часовой стрелки
        public int Hour { get { return HourArrow; } set { HourArrow = value; } }
        private int MinuteArrow;// Цвет минутной стрелки
        public int Minute { get { return MinuteArrow; } set { MinuteArrow = value; } }
        private int SecondArrow;// Цвет секундной стрелки
        public int Second { get { return SecondArrow; } set { SecondArrow = value; } }
        private int Digits;// Цвет цифр
        public int Digit { get { return Digits; } set { Digits = value; } }
        private int ColorForm;// Цвет формы
        public int CForm { get { return ColorForm; } set { ColorForm = value; } }
        private int ColorDivision;// Цвет делений
        public int CDivision { get { return ColorDivision; } set { ColorDivision = value; } }
        private int ColorDigitalClock;// Цвет цифровых часов
        public int CDigitalClock { get { return ColorDigitalClock; } set { ColorDigitalClock = value; } }
        private Size Size; // размер формы
        public Size SForm { get { return Size; } set { Size = value; } }
        private int Lenght; // Размер часов
        public int ClockLenght { get { return Lenght; }  set { Lenght = value; } }
        private int Divisions; // Стиль делений
        public int Division { get { return Divisions; } set { Divisions = value; } }
        private int StyleForm; // Стиль формы
        public int FormStyle{ get { return StyleForm; } set { StyleForm = value; } }
        private bool DigitalClock; // Наличие цифровых часов
        public bool DigitalCl { get { return DigitalClock; } set { DigitalClock = value; } }
    
        public Settings()
        {
            // Базовые настройки
            Hour = Color.Black.ToArgb();
            Minute = Color.Black.ToArgb();
            Second = Color.Red.ToArgb();
            Digit = Color.Black.ToArgb();
            CForm = Color.White.ToArgb();
            CDivision = Color.Black.ToArgb();
            CDigitalClock = Color.Black.ToArgb();
            SForm = new Size(210, 228);
            ClockLenght = 90;
            Division = 1;
            FormStyle = 1;
            DigitalCl = false;
        }

        /// <summary>
        /// Сохранений базовых настроек
        /// </summary>
        public void SaveInitialSettings()
        {
            try
            {
                XmlSerializer xmlFormatter = new XmlSerializer(typeof(Settings));
                using(FileStream fs = new FileStream("DefaultSettings.xml", FileMode.Create))
                {
                    xmlFormatter.Serialize(fs, this);
                }
            }
            catch
            {
                MessageBox.Show("Ошибка сохранения файла с настройками!");
                return;
            }
        }
        /// <summary>
        /// Сброс настроек на базовые
        /// </summary>
        /// <returns></returns>
        public bool ResetSettings()
        {
            Settings DefaultSettings;
            XmlSerializer xmlFormatter = new XmlSerializer(typeof(Settings));
            try
            {
                using (FileStream fs = new FileStream("DefaultSettings.xml", FileMode.Open))
                {
                    DefaultSettings = (Settings)xmlFormatter.Deserialize(fs);
                }
            }
            catch
            {
                MessageBox.Show("Ошибка чтения файла с настройками!");
                return false;
            }

            Hour = DefaultSettings.Hour;
            Minute = DefaultSettings.Minute;
            Second = DefaultSettings.Second;
            Digit = DefaultSettings.Digit;
            CForm = DefaultSettings.CForm;
            CDivision = DefaultSettings.CDivision;
            CDigitalClock = DefaultSettings.CDigitalClock;
            SForm = DefaultSettings.SForm;
            ClockLenght = DefaultSettings.ClockLenght;
            Division = DefaultSettings.Division;
            FormStyle = DefaultSettings.FormStyle;
            DigitalCl = DefaultSettings.DigitalCl;
            return true;
        }
        /// <summary>
        /// Загрузка пользовательских настроек
        /// </summary>
        /// <returns></returns>
        public bool LoadUserSettings()
        {
            Settings UserSettings;
            XmlSerializer xmlFormatter = new XmlSerializer(typeof(Settings));
            try
            {
                using (FileStream fs = new FileStream("UserSettings.xml", FileMode.Open))
                {
                    UserSettings = (Settings)xmlFormatter.Deserialize(fs);
                }

            }
            catch
            {
                return false;
            }

            Hour = UserSettings.Hour;
            Minute = UserSettings.Minute;
            Second = UserSettings.Second;
            Digit = UserSettings.Digit;
            CForm = UserSettings.CForm;
            CDivision = UserSettings.CDivision;
            CDigitalClock = UserSettings.CDigitalClock;
            SForm = UserSettings.SForm;
            ClockLenght = UserSettings.ClockLenght;
            Division = UserSettings.Division;
            FormStyle = UserSettings.FormStyle;
            DigitalCl = UserSettings.DigitalCl;
            return true;
        }

        /// <summary>
        /// Сохранение пользовательских настроек
        /// </summary>
        public void SaveUserSettings()
        {
            try
            {
                XmlSerializer xmlFormatter = new XmlSerializer(typeof(Settings));
                using (FileStream fs = new FileStream("UserSettings.xml", FileMode.Create))
                {
                    xmlFormatter.Serialize(fs, this);
                }
            }
            catch
            {
                MessageBox.Show("Ошибка сохранения файла с настройками!");
                return;
            }
        }
    }
}
