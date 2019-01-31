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
    public partial class ResultsForm : Form
    {
        private Student[] data;
        private int kind;
        private string param;
        private int oper;
        private LINQMethods LINQMethods;

        public ResultsForm(int oper, int kind, Student[] data, string param)
        {
            InitializeComponent();
            this.data = data;
            this.kind = kind;
            this.param = param;
            this.oper = oper;
        }

        private void ResultsForm_Shown(object sender, EventArgs e)
        {
            LINQMethods = new LINQMethods();
            int i = 0;
            switch (oper)
            {
                case 0:
                    var results1 = LINQMethods.Sort(kind / 2, Convert.ToBoolean(kind % 2), data);
                    foreach (Student s in results1)
                    {
                        if (s == null)
                            return;
                        DGV.RowCount++;
                        DGV["id", i].Value = s.id;
                        DGV["first_name", i].Value = s.first_name;
                        DGV["second_name", i].Value = s.second_name;
                        DGV["patronymic", i].Value = s.patronymic;
                        DGV["group", i].Value = s.group;
                        DGV["scholarship", i].Value = s.scholarship;
                        DGV["average_point", i].Value = s.average_point;
                        DGV["DOB", i].Value = s.DOB.Date;
                        i++;
                    }
                    break;
                case 1:
                    var results2 = LINQMethods.Filtration(kind, param, data);
                    foreach (Student s in results2)
                    {
                        DGV.RowCount++;
                        DGV["id", i].Value = s.id;
                        DGV["first_name", i].Value = s.first_name;
                        DGV["second_name", i].Value = s.second_name;
                        DGV["patronymic", i].Value = s.patronymic;
                        DGV["group", i].Value = s.group;
                        DGV["scholarship", i].Value = s.scholarship;
                        DGV["average_point", i].Value = s.average_point;
                        DGV["DOB", i].Value = s.DOB.Date;
                        i++;
                    }
                    break;
                case 2:
                    var results3 = LINQMethods.Grouping(kind, data);
                    foreach (var g in results3)
                    {
                        foreach (var s in g)
                        {
                            DGV.RowCount++;
                            DGV["id", i].Value = s.id;
                            DGV["first_name", i].Value = s.first_name;
                            DGV["second_name", i].Value = s.second_name;
                            DGV["patronymic", i].Value = s.patronymic;
                            DGV["group", i].Value = s.group;
                            DGV["scholarship", i].Value = s.scholarship;
                            DGV["average_point", i].Value = s.average_point;
                            DGV["DOB", i].Value = s.DOB.Date;
                            i++;
                        }
                    }
                    break;
            }
        }

    }
}
