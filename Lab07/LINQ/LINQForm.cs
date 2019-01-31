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
    public partial class LINQForm : Form
    {
        private AboutProgramForm AboutProgram;
        private ResultsForm Results;
        private LINQMethods LINQMethods;
        private Student[] data;
        private ComparisonForm Comparison;

        public LINQForm()
        {
            InitializeComponent();
            ShowDGV();
        }

        private void ShowDGV()
        {
            DGV.RowCount = 15;
            for (int i = 1; i <= DGV.RowCount; i++)
            {
                DGV[0, i - 1].Value = i;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutProgram = new AboutProgramForm();
            AboutProgram.Show();
        }

        private void DGV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!(Char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void DGV_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(DGV_KeyPress);
            TextBox tb = e.Control as TextBox;
            if (tb != null)
            {
                tb.KeyPress += new KeyPressEventHandler(DGV_KeyPress);
            }
        }

        private void OperationsCB_DropDownClosed(object sender, EventArgs e)
        {
            OperationsMCB.Items.Clear();
            switch (OperationsCB.SelectedIndex)
            {
                case 0:
                    OperationsMCB.Items.AddRange(new object[] { "id(по убыванию)", "id(по возрастанию)", "Средний балл(по убыванию)" ,
                        "Средний балл(по возрастанию)", "Фамилия(по убыванию)", "Фамилия(по возрастанию)", "Дата рождения(по убыванию)",
                        "Дата рождения(по возрастанию)" });
                    break;
                case 1:
                    OperationsMCB.Items.AddRange(new object[] { "id с четным значением", "А => Ср. балл",
                        "Фамилия начинается с А строки", "А => Дата рождения", "А => Стипендия"});
                    break;
                case 2:
                    OperationsMCB.Items.AddRange(new object[] { "Группа", "Средний балл", "Стипендия", "Имя" });
                    break;
                case 3:
                    OperationsMCB.Items.AddRange(new object[] { "Максимальный балл", "Средний балл студентов", "Сумма стипендий"});
                    break;
                default:
                    return;
            }
        }

        private void resultsTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void execute_Click(object sender, EventArgs e)
        {
            if(OperationsCB.SelectedIndex == -1 || OperationsMCB.SelectedIndex == -1)
            {
                MessageBox.Show("Сперва выберите операцию!", "Error");
                return;
            }
                
            LINQMethods = new LINQMethods();
            data = new Student[0];
            try
            {
                int k = 0;
                for(int i = 0; i < DGV.RowCount; i++)
                {
                    if (DGV[1, i].Value == null && DGV[2, i].Value == null && DGV[3, i].Value == null && DGV[4, i].Value == null && DGV[5, i].Value == null && DGV[6, i].Value == null && DGV[7, i].Value == null)
                    {
                        k++;
                        if (k == 2)
                            break;
                        else
                            continue;
                    }
                    else
                    {
                        if (i + 1 > data.Count())
                            Array.Resize(ref data, data.Count()+1);
                        data[i] = new Student();
                    }
                    data[i].id = Convert.ToInt32(DGV["id", i].Value.ToString());
                    data[i].first_name = DGV["first_name", i].Value.ToString();
                    data[i].second_name = DGV["second_name", i].Value.ToString();
                    data[i].patronymic = DGV["patronymic", i].Value.ToString();
                    data[i].group = DGV["group", i].Value.ToString();
                    data[i].scholarship = Convert.ToInt32(DGV["scholarship", i].Value.ToString());
                    data[i].average_point = Convert.ToDouble(DGV["average_point", i].Value.ToString());
                    data[i].DOB = Convert.ToDateTime(DGV["DOB", i].Value.ToString());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка! Проверьте введенные данные!", "Error");
                return;
            }

            if(data.Count() == 0)
            {
                MessageBox.Show("Сперва заполните таблицу", "Error");
                return;
            }

            string param = null;
            if(OperationsCB.SelectedIndex == 1)
            {
                try
                {
                    switch (OperationsMCB.SelectedIndex)
                    {
                        case 1:
                            Convert.ToDouble(A.Text);
                            break;
                        case 3:
                            Convert.ToDateTime(A.Text);
                            break;
                        case 4:
                            Convert.ToInt32(A.Text);
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка! Проверьте введенные данные!", "Error");
                    return;
                }
                param = A.Text;
            }
            else if(OperationsCB.SelectedIndex == 3)
            {
                var tmp = LINQMethods.Aggregate(OperationsMCB.SelectedIndex, data);
                resultsTB.Text = tmp.ToString();
                return;
            }

            Results = new ResultsForm(OperationsCB.SelectedIndex, OperationsMCB.SelectedIndex, data, param);
            Results.Show();
        }

        private void comparation_Click(object sender, EventArgs e)
        {
            Comparison = new ComparisonForm();
            Comparison.Show();
        }
    }
}
