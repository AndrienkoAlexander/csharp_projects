using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LINQ
{
    public partial class AboutProgramForm : Form
    {
        public AboutProgramForm()
        {
            InitializeComponent();
            label1.Text = "Л/р №7 по ТП\r\nВыполнил ст.гр. 525\r\nАндриенко А.И.\r\n2018";
        }
    }
}
