using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace BinaryTree
{
    /// <summary>
    /// Класс с информацией о среднем времени выполнения основных операций в тиках
    /// </summary>
    public class OperationTime
    {
        private Stopwatch sw;
        /// <summary>
        /// Среднее время вставки узла
        /// </summary>
        public long insert { get; set; }
        /// <summary>
        /// Количество вставок
        /// </summary>
        public int insertcount { get; set; }
        /// <summary>
        /// Среднее время удаления узла
        /// </summary>
        public long remove { get; set; }
        /// <summary>
        /// Количество удалений
        /// </summary>
        public int removecount { get; set; }
        /// <summary>
        /// Среднее время поиска узла
        /// </summary>
        public long find { get; set; }
        /// <summary>
        /// Количество поисков
        /// </summary>
        public int findcount { get; set; }

        /// <summary>
        /// Конструктор с инициализацией 
        /// </summary>
        public OperationTime()
        {
            sw = new Stopwatch();
            insertcount = 0;
            removecount = 0;
            findcount = 0;
        }

        /// <summary>
        /// Начало отсчета времени
        /// </summary>
        public void TimeStart()
        {
            sw.Reset();
            sw.Start();
        }

        /// <summary>
        /// Остановка отсчета времени вставки
        /// </summary>
        public void InsertTimeStop()
        {
            sw.Stop();
            insertcount++;
            bool temp = (insert == 0);
            insert = insert + sw.Elapsed.Ticks;
            if(!temp)
                insert = insert / 2;
        }

        /// <summary>
        /// Остановка отсчета времени удаления
        /// </summary>
        public void RemoveTimeStop()
        {
            sw.Stop();
            removecount++;
            bool temp = (remove == 0);
            remove = remove + sw.Elapsed.Ticks;
            if (!temp)
                remove = remove / 2;
        }

        /// <summary>
        /// Остановка отсчета времени поиска
        /// </summary>
        public void FindTimeStop()
        {
            sw.Stop();
            findcount++;
            bool temp = (find == 0);
            find = find + sw.Elapsed.Ticks;
            if (!temp)
                find = find / 2;
        }
    }
}
