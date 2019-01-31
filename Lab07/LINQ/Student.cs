using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class Student
    {
        public int id { get; set; }
        public string second_name { get; set; }
        public string first_name { get; set; }
        public string patronymic { get; set; }
        public DateTime DOB { get; set; }
        public string group { get; set; }
        public double average_point { get; set; }
        public int scholarship { get; set; }

        public Student()
        {

        }

        public Student(int id, string second_name, string first_name, string patronymic, DateTime DOB, string group, double average_point, int scholarship)
        {
            this.id = id;
            this.second_name = second_name;
            this.first_name = first_name;
            this.patronymic = patronymic;
            this.DOB = DOB;
            this.group = group;
            this.average_point = average_point;
            this.scholarship = scholarship;
        }
    }
}
