using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{
    public partial class AboutProgram : Form
    {
        public AboutProgram()
        {
            InitializeComponent();
            label1.Text = "Л/р №6 по ТП\r\nВыполнил ст.гр. 525\r\nАндриенко А.И.\r\n2018";
        }
    }
}
