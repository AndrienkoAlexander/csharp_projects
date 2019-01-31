using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Runtime.Serialization;

namespace BinaryTree
{
    public class BinaryTreeArray
    {
        /// <summary>
        /// Колекция для дерева
        /// </summary>
        public List<int?> tree { get; set; }
        /// <summary>
        /// Максимальное количество узлов дерева
        /// </summary>
        private const int NumNodes = int.MaxValue/100;

        public BinaryTreeArray()
        {
            ClearTree();
        }

        /// <summary>
        /// Метод вставки узла в дерево
        /// </summary>
        /// <param name="data">Значение узла</param>
        public void Insert(int data)
        {
            if(tree[1] == null) // Если корня нет
            {
                tree[1] = data;
                return;
            }

            int addrp = 1; // Адрес родителя
            int addrc = 1; // Адрес потомка
            for (; ; )
            {
                if (data < tree[addrp]) // Если вставляемое значение меньше значения узла
                {
                    addrc = addrc*2; // левый потомок
                    if (tree[addrc] == null) // Если узел для вставки найден
                    {
                        tree[addrc] = data;
                        return;
                    }
                    else
                    {
                        addrp = addrc;
                    }
                }
                else if(data > tree[addrp]) // Если вставляемое значение больше значения узла
                {
                    addrc = addrc*2+1; // правый потомок
                    if (tree[addrc] == null) // Если узел для вставки найден
                    {
                        tree[addrc] = data;
                        return;
                    }
                    else
                    {
                        addrp = addrc;
                    }
                }
                else
                {
                    return;
                }
            }
        }

        /// <summary>
        /// Поиск узла в дереве
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Адрес узла</returns>
        public int Find(int data)
        {
            int addr = 1;
            while(data != tree[addr])
            {
                if (tree[addr] == null)
                    return -1;
                else if (tree[addr] > data)
                {
                    addr = addr*2;
                }
                else
                {
                    addr = addr*2 + 1;
                }
            }
            return addr;
        }

        /// <summary>
        /// Удаление узла по значению
        /// </summary>
        /// <param name="data"></param>
        public void RemoveNodeData(int data)
        {
            int remove_node_addr = Find(data);
            RemoveNodeAddr(remove_node_addr);
        }

        /// <summary>
        /// Удаление узла по адресу
        /// </summary>
        /// <param name="remove_node_addr"></param>
        private void RemoveNodeAddr(int remove_node_addr)
        {
            if (remove_node_addr == -1) // Если указаного значения не было найдено
                return;
            else
            {
                int addrc_r = remove_node_addr*2+1; // Адрес правого потомка
                int addrc_l = remove_node_addr * 2; // Адрес левого потомка 
                if (tree[addrc_r] == null && tree[addrc_l] == null) // Если потомки отсутствуют
                {
                    tree[remove_node_addr] = null;
                }
                else if(tree[addrc_r] == null) // Если отсутствует правый потомок
                {
                    tree[remove_node_addr] = tree[addrc_l];
                    FixTree(remove_node_addr, addrc_l);
                }
                else if(tree[addrc_l] == null) // Если отсутствует левый потомок
                {
                    tree[remove_node_addr] = tree[addrc_r];
                    FixTree(remove_node_addr, addrc_r);
                }
                else // Если есть оба потомка
                {
                    int new_node = FindMax(remove_node_addr * 2); // Находим максимальное значение в левом потомке
                    tree[remove_node_addr] = tree[new_node]; // Заменяем удаляемый узел на максимальный найденный 
                    RemoveNodeAddr(new_node); // Удаляемый максимальный найденный
                }
            }
        }

        /// <summary>
        /// Вспомогательный метод для корректного удаления узла
        /// </summary>
        /// <param name="addrp"></param>
        /// <param name="node_addr"></param>
        private void FixTree(int addrp, int node_addr)
        {
            tree[addrp * 2] = tree[node_addr * 2];
            tree[node_addr * 2] = null;
            tree[addrp * 2 + 1] = tree[node_addr * 2 + 1];
            tree[node_addr * 2 + 1] = null;
            addrp = addrp * 2;
            node_addr = node_addr * 2;
            if (tree[addrp] != null)
                FixTree(addrp, node_addr);
            if (tree[addrp + 1] != null)
                FixTree(addrp + 1, node_addr + 1);
        }

        /// <summary>
        /// Поиск максимального значения в дереве
        /// </summary>
        /// <param name="addr"></param>
        /// <returns></returns>
        public int FindMax(int addr)
        {
            if (tree[addr] == null) return -1;
            while(tree[addr*2+1] != null)
            {
                addr = addr * 2 + 1;
            }
            return addr;
        }

        /// <summary>
        /// Поиск минимального значения в дереве
        /// </summary>
        /// <param name="addr"></param>
        /// <returns></returns>
        public int FindMin(int addr)
        {
            if (tree[addr] == null) return -1;
            while (tree[addr * 2] != null)
            {
                addr = addr * 2;
            }
            return addr;
        }

        /// <summary>
        /// Количество узлов в дереве
        /// </summary>
        /// <returns></returns>
        public int CountElements()
        {
            int n = 0;
            for(int i = 1, k = 0; i < NumNodes && i != k; i++)
            {
                if(tree[i] != null)
                {
                    n++;
                    k = 0;
                }
                else
                    k++;
            }
            return n;
        }

        /// <summary>
        /// Максимальная ширина дерева
        /// </summary>
        /// <param name="addr"></param>
        /// <returns></returns>
        public int MaxWidth(int addr)
        {
            int maxWidth = 0;
            int width = 0;
            int h = Height(addr);
            for (int i = 1; i < h; i++)
            {
                width = getWidth(addr, i);
                if (width > maxWidth)
                    maxWidth = width;
            }
            return maxWidth;
        }

        /// <summary>
        /// Ширина уровня в дереве
        /// </summary>
        /// <param name="addr"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        private int getWidth(int addr, int level)
        {
            if (tree[addr] == null)
                return 0;
            if (level == 1)
                return 1;
            else if (level > 1)
                return getWidth(addr*2, level - 1) + getWidth(addr*2+1, level - 1);
            return 0;
        }

        /// <summary>
        /// Высота узла
        /// </summary>
        /// <param name="addr"></param>
        /// <returns></returns>
        public int Height(int addr)
        {
            if (tree[addr] == null)
                return 0;
            else
            {
                int lheight = Height(addr*2);
                int rheight = Height(addr * 2+1);

                if (lheight > rheight)
                    return (lheight + 1);
                else
                    return (rheight + 1);
            }
        }

        /// <summary>
        /// Прямой обход (CLR - center, left, right)
        /// </summary>
        /// <param name="addr">текущий "элемент дерева" (ref  передача по ссылке)</param>
        /// <param name="s">строка, в которой накапливается результат (ref - передача по ссылке)</param>
        /// <param name="detailed"></param>
        public void CLR(int addr, ref string s, bool detailed)
        {
            if (tree[addr] != null)
            {
                s += tree[addr].ToString() + " "; // запомнить текущее значение
                CLR(addr*2, ref s, detailed); // обойти левое поддерево
                CLR(addr*2+1, ref s, detailed); // обойти правое поддерево
            }
        }

        /// <summary>
        /// Обратный обход (LCR - left, center, right) 
        /// </summary>
        /// <param name="addr">текущий "элемент дерева" (ref - передача по ссылке)</param>
        /// <param name="s">строка, в которой накапливается результат (ref - передача по ссылке)</param>
        /// <param name="detailed"></param>
        public void LCR(int addr, ref string s, bool detailed)
        {
            if (tree[addr] != null)
            {
                LCR(addr*2, ref s, detailed); // обойти левое поддерево
                s += tree[addr].ToString() + " "; // запомнить текущее значение
                LCR(addr*2+1, ref s, detailed); // обойти правое поддерево
            }
        }

        /// <summary>
        /// Концевой обход (RCL -right, center, left)
        /// </summary>
        /// <param name="addr">текущий "элемент дерева" (ref - передача по ссылке)</param>
        /// <param name="s">строка, в которой накапливается результат (ref - передача по ссылке)</param>
        /// <param name="detailed"></param>
        public void RCL(int addr, ref string s, bool detailed)
        {
            if (tree[addr] != null)
            {
                RCL(addr * 2+1, ref s, detailed); // обойти правое поддерево
                s += tree[addr].ToString() + " "; // запомнить текущее значение
                RCL(addr * 2, ref s, detailed); // обойти левое поддерево
            }
        }

        /// <summary>
        /// Обход дерева в ширину (итерационно, используется очередь)
        /// </summary>
        /// <param name="addr">текущий "элемент дерева" </param>
        /// <param name="s">строка, в которой накапливается результат (ref - передача по ссылке)</param>
        /// <param name="detailed"></param>
        public void Across(int addr, ref string s, bool detailed)
        {
            var queue = new Queue<int>(); // создать новую очередь
            queue.Enqueue(addr); // поместить в очередь первый уровень
            while (queue.Count != 0) // пока очередь не пуста
            {
                //если у текущей ветви есть листья, их тоже добавить в очередь
                if (tree[queue.Peek()*2] != null)
                {
                    queue.Enqueue(queue.Peek()*2);
                }
                if (tree[queue.Peek() * 2+1] != null)
                {
                    queue.Enqueue(queue.Peek()*2+1);
                }
                //извлечь из очереди информационное поле последнего элемента
                s += tree[queue.Peek()].ToString() + " "; // убрать последний элемент очереди
                queue.Dequeue();
            }
        }

        /// <summary>
        /// Зеркальное отображение дерева
        /// </summary>
        /// <param name="addr"></param>
        public void MirrorTree(int addr)
        {
            int h = Height(1);
            while (h != 0) {
                List<int?> temp = new List<int?>();
                for (int l = h, k = 1; k <= (int)Math.Pow(2, l - 1); k++){
                    temp.Add(tree[k + (int)Math.Pow(2, l-1) - 1]);
                    tree[k + (int)Math.Pow(2, l - 1) - 1] = null;
                }
                temp.Reverse();
                for (int l = h, k = 1; k <= (int)Math.Pow(2, l - 1); k++)
                {
                    tree[k + (int)Math.Pow(2, l-1) - 1] = temp[k-1];
                }
                h--;
            }
        }

        /// <summary>
        /// Очистка массива для дерева
        /// </summary>
        private void ClearTree()
        {
            tree = new List<int?>(NumNodes);
            for (int i = 0; i < NumNodes; i++)
                tree.Add(null);
        }

        /// <summary>
        /// Запись бинарного дерева в файл
        /// </summary>
        /// <returns></returns>
        public bool WriteFile()
        {
            SaveFileDialog save = new SaveFileDialog(); // save - имя компонента SaveFileDialog
            string Fname = ""; // для имени файла
            // задание начальной директории
            save.InitialDirectory = @"С:\";
            // задание свойства Filter
            save.Filter = "txt files (*.txt)|*.txt";
            // задание свойства FilterIndex – выбор типа файла
            save.FilterIndex = 2;
            // свойство Title - название окна диалога выбора файла
            save.Title = "Сохранить файл";

            if (save.ShowDialog() == DialogResult.OK)
            { // получаем имя файла для сохранения данных
                Fname = save.FileName;
                // выделяем память для потока - объекта типа FileStream
                FileStream fs = new FileStream(Fname, FileMode.Create, FileAccess.Write);

                if (fs != null) // в случае успеха создаем объект
                { // типа StreamWriter и ассоциируем его с объектом fs
                    StreamWriter wr = new StreamWriter(fs);
                    List<int> s = new List<int>();
                    FileData(1, ref s);
                    for (int i = 0; i < s.Count; i++)
                    {
                        wr.WriteLine(s[i]);
                    }

                    // переносим данные из потока fs в файл
                    wr.Flush();
                    // закрываем объекты wr и fs
                    wr.Close();
                    fs.Close();
                    return true;
                }
                else return false;
            }
            else return false;
        }

        private void FileData(int addr, ref List<int> s)
        {
            if (tree[addr] != null)
            {
                var queue = new Queue<int>(); // создать новую очередь
                queue.Enqueue(addr); // поместить в очередь первый уровень
                while (queue.Count != 0) // пока очередь не пуста
                {
                    //если у текущей ветви есть листья, их тоже добавить в очередь
                    if (tree[queue.Peek() * 2] != null)
                    {
                        queue.Enqueue(queue.Peek() * 2);
                    }
                    if (tree[queue.Peek() * 2 + 1] != null)
                    {
                        queue.Enqueue(queue.Peek() * 2 + 1);
                    }
                    //извлечь из очереди информационное поле последнего элемента
                    s.Add((int)tree[queue.Peek()]); // убрать последний элемент очереди
                    queue.Dequeue();
                }
            }
        }

        /// <summary>
        /// Считывание бинарного дерева из файла
        /// </summary>
        /// <returns></returns>
        public BinaryTreeArray ReadFile()
        {
            OpenFileDialog open = new OpenFileDialog(); // save - имя компонента SaveFileDialog
            string Fname = ""; // для имени файла
                               // задание начальной директории
            open.InitialDirectory = @"С:\";
            // задание свойства Filter
            open.Filter = "txt files (*.txt)|*.txt";
            // задание свойства FilterIndex – выбор типа файла
            open.FilterIndex = 2;
            // свойство Title - название окна диалога выбора файла
            open.Title = "Открыть файл";

            if (open.ShowDialog() == DialogResult.OK)
            { // получаем имя файла для сохранения данных
                Fname = open.FileName;
                FileStream fs = new FileStream(Fname, FileMode.Open, FileAccess.Read);

                if (fs != null) // в случае успеха создания объекта fs
                { // создаем объект типа StreamReader и

                    // ассоциируем его с объектом fs

                    StreamReader r = new StreamReader(fs);
                    // коллекция для данных из файла
                    List<int> array = new List<int>();
                    int i = 0;
                    while (!r.EndOfStream) // пока нет конца потока
                    {
                        try
                        {
                            array.Add(Convert.ToInt32(r.ReadLine()));
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Ошибка чтения массива из файла!", "Error");
                        }
                    }
                    r.Close(); fs.Close();
                    BinaryTreeArray newTree = new BinaryTreeArray();
                    for (int j = 0; j < array.Count; j++)
                    {
                        newTree.Insert(array[j]);
                    }
                    return newTree;
                }
                else { MessageBox.Show("Ошибка чтения из файла!", "Ошибка"); return this; }

            }
            else return this;
        }
    }
}
