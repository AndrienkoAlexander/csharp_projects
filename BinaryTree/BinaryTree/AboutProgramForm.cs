using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinaryTree
{
    public partial class AboutProgramForm : Form // Форма с информацией о проекте
    {
        public AboutProgramForm()
        {
            InitializeComponent();
            label1.Text = "Курсовой проект на тему:" + Environment.NewLine + 
                        "\"Разработка класса "+ Environment.NewLine +
                          "бинарного дерева поиска\"." +Environment.NewLine + 
                          "Выполнил студент гр. 525 Андриенко А.И." + Environment.NewLine +
                          "Руководитель: доцент Шостак А.В."; // Задание текста с информацией о проекте
        }
    }
}
