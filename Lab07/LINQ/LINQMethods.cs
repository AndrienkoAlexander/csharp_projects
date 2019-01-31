using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class LINQMethods
    {
        /// <summary>
        /// Сортировка массива объектов по заданому параметру
        /// </summary>
        /// <param name="param"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public IEnumerable<Student> Sort(int kind, bool descending, Student[] data)
        {
            switch (kind)
            {
                case 0: //id
                    if(descending)
                        return data.OrderBy(d => d.id);
                    else
                        return data.OrderByDescending(d => d.id);
                case 1: //average_point
                    if (descending)
                        return data.OrderBy(d => d.average_point);
                    else
                        return data.OrderByDescending(d => d.average_point);
                case 2: //second_name
                    if (descending)
                        return data.OrderBy(d => d.second_name);
                    else
                        return data.OrderByDescending(d => d.second_name);
                case 3: //DOB
                    if (descending)
                        return data.OrderBy(d => d.DOB);
                    else
                        return data.OrderByDescending(d => d.DOB);
            }
            return null;
        }

        /// <summary>
        /// Фильтрация массива объектов по заданаму параметру
        /// </summary>
        /// <param name="param"></param>
        /// <param name="data"></param>
        /// <returns>Возвращает массив индексов элементов исходного массива, которые прошли фильтрацию</returns>
        public IEnumerable<Student> Filtration(int kind, string param, Student[] data)
        {
            List<int> index = new List<int>();
            switch (kind)
            {
                case 0: //id
                    return data.Where(d => d.id % 2 == 0);
                case 1: //average_point
                    return data.Where(d => d.average_point >= Convert.ToDouble(param));
                case 2: //second_name
                    return data.Where(d => d.second_name.StartsWith(param));
                case 3: //DOB
                    return data.Where(d => d.DOB >= Convert.ToDateTime(param));
                case 4: //scholarship
                    return data.Where(d => d.scholarship >= Convert.ToInt32(param));
            }
            return null;
        }

        /// <summary>
        /// Группировка массива объекта по заданому параметру
        /// </summary>
        /// <param name="kind"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public IEnumerable<IGrouping<string, Student>> Grouping(int kind, Student[] data)
        {
            switch (kind)
            {
                case 0: //group
                    return data.GroupBy(d => d.group);
                case 1: //average_point
                    return data.GroupBy(d => d.average_point.ToString());
                case 2: //scholarship
                    return data.GroupBy(d => d.scholarship.ToString());
                case 3:
                    return data.GroupBy(d => d.first_name);
            }
            return null;
        }

        public double Aggregate(int kind, Student[] data)
        {
            double result = 0;

            switch (kind)
            {
                case 0: //Max average_point
                    return data.Max(d => d.average_point);
                case 1: //avr average_point
                    return data.Average(d => d.average_point);
                case 2: //sum scholarship
                    return data.Sum(d => d.scholarship);
            }
            return result;
        }

    }
}
