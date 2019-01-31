using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace BinaryTree
{
    /// <summary>
    /// Класс описывающий бинарное дерево поиска
    /// </summary>
    public class BinaryTreeP
    {
        /// <summary>
        /// Значение узла
        /// </summary>
        public long? Data { get; set; }
        /// <summary>
        /// Левый потомок
        /// </summary>
        public BinaryTreeP Left { get; set; }
        /// <summary>
        /// Правый потомок
        /// </summary>
        public BinaryTreeP Right { get; set; }
        /// <summary>
        /// Родитель
        /// </summary>
        public BinaryTreeP Parent { get; set; }

        /// <summary>
        /// Вставляет целочисленное значение в дерево
        /// </summary>
        /// <param name="data">Значение, которое добавится в дерево</param>
        public void Insert(long data)
        {
            // Если найден свободный узел для вставки значения или значения равны
            if (Data == null || Data == data)
            {
                Data = data;
                return;
            }
            if (Data > data) // Если вставляемое значение меньше значения узла
            {
                if (Left == null) Left = new BinaryTreeP();
                Insert(data, Left, this);
            }
            else // Если вставляемое значение больше значения узла
            {
                if (Right == null) Right = new BinaryTreeP();
                Insert(data, Right, this);
            }

        }

        /// <summary>
        /// Вставляет значение в определённый узел дерева
        /// </summary>
        /// <param name="data">Значение</param>
        /// <param name="node">Целевой узел для вставки</param>
        /// <param name="parent">Родительский узел</param>
        private void Insert(long data, BinaryTreeP node, BinaryTreeP parent)
        {

            if (node.Data == null || node.Data == data)
            {
                node.Data = data;
                node.Parent = parent;
                return;
            }
            if (node.Data > data)
            {
                if (node.Left == null) node.Left = new BinaryTreeP();
                Insert(data, node.Left, node);
            }
            else
            {
                if (node.Right == null) node.Right = new BinaryTreeP();
                Insert(data, node.Right, node);
            }
        }
        /// <summary>
        /// Уставляет узел в определённый узел дерева
        /// </summary>
        /// <param name="data">Вставляемый узел</param>
        /// <param name="node">Целевой узел</param>
        /// <param name="parent">Родительский узел</param>
        private void Insert(BinaryTreeP data, BinaryTreeP node, BinaryTreeP parent)
        {

            if (node.Data == null || node.Data == data.Data)
            {
                node.Data = data.Data;
                node.Left = data.Left;
                node.Right = data.Right;
                node.Parent = parent;
                return;
            }
            if (node.Data > data.Data)
            {
                if (node.Left == null) node.Left = new BinaryTreeP();
                Insert(data, node.Left, node);
            }
            else
            {
                if (node.Right == null) node.Right = new BinaryTreeP();
                Insert(data, node.Right, node);
            }
        }
        /// <summary>
        /// Определяет, в какой ветви для родительского лежит данный узел
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private BinSide? MeForParent(BinaryTreeP node)
        {
            if (node.Parent == null) return null;
            if (node.Parent.Left == node) return BinSide.Left;
            if (node.Parent.Right == node) return BinSide.Right;
            return null;
        }

        /// <summary>
        /// Удаляет узел из дерева
        /// </summary>
        /// <param name="node">Удаляемый узел</param>
        public void Remove(BinaryTreeP node)
        {
            if (node == null) return;
            var me = MeForParent(node);
            //Если у узла нет дочерних элементов, его можно смело удалять
            if (node.Left == null && node.Right == null)
            {
                if (me == BinSide.Left)
                {
                    node.Parent.Left = null;
                }
                else
                {
                    node.Parent.Right = null;
                }
                return;
            }
            //Если нет левого дочернего, то правый дочерний становится на место удаляемого
            if (node.Left == null)
            {
                if (me == BinSide.Left)
                {
                    node.Parent.Left = node.Right;
                }
                else
                {
                    node.Parent.Right = node.Right;
                }

                node.Right.Parent = node.Parent;
                return;
            }
            //Если нет правого дочернего, то левый дочерний становится на место удаляемого
            if (node.Right == null)
            {
                if (me == BinSide.Left)
                {
                    node.Parent.Left = node.Left;
                }
                else
                {
                    node.Parent.Right = node.Left;
                }

                node.Left.Parent = node.Parent;
                return;
            }

            //Если присутствуют оба дочерних узла
            //то правый ставим на место удаляемого
            //а левый вставляем в правый

            if (me == BinSide.Left)
            {
                node.Parent.Left = node.Right;
            }
            if (me == BinSide.Right)
            {
                node.Parent.Right = node.Right;
            }
            if (me == null)
            {
                var bufLeft = node.Left;
                var bufRightLeft = node.Right.Left;
                var bufRightRight = node.Right.Right;
                node.Data = node.Right.Data;
                node.Right = bufRightRight;
                node.Left = bufRightLeft;
                Insert(bufLeft, node, node);
            }
            else
            {
                node.Right.Parent = node.Parent;
                Insert(node.Left, node.Right, node.Right);
            }
        }
        /// <summary>
        /// Удаляет значение из дерева
        /// </summary>
        /// <param name="data">Удаляемое значение</param>
        public void Remove(long data)
        {
            var removeNode = Find(data);
            if (removeNode != null)
            {
                Remove(removeNode);
            }
        }
        /// <summary>
        /// Ищет узел с заданным значением
        /// </summary>
        /// <param name="data">Значение для поиска</param>
        /// <returns></returns>
        public BinaryTreeP Find(long data)
        {
            if (Data == data) return this;
            if (Data > data)
            {
                return Find(data, Left);
            }
            return Find(data, Right);
        }
        /// <summary>
        /// Ищет значение в определённом узле
        /// </summary>
        /// <param name="data">Значение для поиска</param>
        /// <param name="node">Узел для поиска</param>
        /// <returns></returns>
        private BinaryTreeP Find(long data, BinaryTreeP node)
        {
            if (node == null) return null;

            if (node.Data == data) return node;
            if (node.Data > data)
            {
                return Find(data, node.Left);
            }
            return Find(data, node.Right);
        }

        /// <summary>
        /// Количество элементов в дереве
        /// </summary>
        /// <returns></returns>
        public long CountElements()
        {
            return CountElements(this);
        }
        /// <summary>
        /// Количество элементов в определённом узле
        /// </summary>
        /// <param name="node">Узел для подсчета</param>
        /// <returns></returns>
        private long CountElements(BinaryTreeP node)
        {
            long count = 1;
            if (node.Right != null)
            {
                count += CountElements(node.Right);
            }
            if (node.Left != null)
            {
                count += CountElements(node.Left);
            }
            return count;
        }

        /// <summary>
        /// Поиск максимального значения в дереве
        /// </summary>
        /// <param name="node">Узел</param>
        /// <returns>Максимальный узел</returns>
        public BinaryTreeP FindMax(BinaryTreeP node) // Максимальное значение у самого правого
        {
            if (node.Right != null)
                return FindMax(node.Right);
            return node;
        }

        /// <summary>
        /// Поиск минимального значения в дереве
        /// </summary>
        /// <param name="node">Узел</param>
        /// <returns>Минимальный узел</returns>
        public BinaryTreeP FindMin(BinaryTreeP node) // Минимальное значение у самого левого
        {
            if (node.Left != null)
                return FindMin(node.Left);
            return node;
        }

        public int MaxWidth(BinaryTreeP root)
        {
            int maxWidth = 0;
            int width = 0;
            int h = Height(root);
            for (int i = 1; i < h; i++)
            {
                width = getWidth(root, i);
                if (width > maxWidth)
                    maxWidth = width;
            }
            return maxWidth;
        }

        private int getWidth(BinaryTreeP root, int level)
        {
            if (root == null)
                return 0;
            if (level == 1)
                return 1;
            else if (level > 1)
                return getWidth(root.Left, level - 1) + getWidth(root.Right, level - 1);
            return 0;
        }

        /// <summary>
        /// Порядок узла
        /// </summary>
        /// <param name="node">Узел</param>
        /// <param name="order">0</param>
        /// <returns>Порядок узла</returns>
        public int Height(BinaryTreeP node)
        {
            if (node == null)
                return 0;
            else
            {
                int lheight = Height(node.Left);
                int rheight = Height(node.Right);

                if (lheight > rheight)
                    return (lheight + 1);
                else
                    return (rheight + 1);
            }
        }
        /// <summary>
        /// Правый поворот вокруг узла node
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private BinaryTreeP RotateRight(BinaryTreeP node)
        {
            if (node.Parent == null)
            {
                node.Left.Parent = null;
            }
            BinaryTreeP q = node.Left;
            node.Left = q.Right;
            q.Right = node;
            node.Parent = q;
            return q;
        }
        /// <summary>
        /// Левый поворот вокруг узла node
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private BinaryTreeP RotateLeft(BinaryTreeP node)
        {
            if (node.Parent == null)
            {
                node.Right.Parent = null;
            }
            BinaryTreeP p = node.Right;
            node.Right = p.Left;
            p.Left = node;
            node.Parent = p;
            return p;
        }
        /// <summary>
        /// Вычисляет фактор баланса для заданного узла
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private int BalanceFactor(BinaryTreeP node)
        {
            return Height(node.Right) - Height(node.Left);
        }
        /// <summary>
        /// Метод выполнающий балансировку
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public BinaryTreeP Balance(BinaryTreeP node)
        {
            if (BalanceFactor(node) == 2)
            {
                if (BalanceFactor(node.Right) < 0)
                    node.Right = RotateRight(node.Right);
                return RotateLeft(node);
            }
            if (BalanceFactor(node) == -2)
            {
                if (BalanceFactor(node.Left) > 0)
                    node.Left = RotateLeft(node.Left);
                return RotateRight(node);
            }
            return node;
        }
        /// <summary>
        /// Прямой обход (CLR - center, left, right)
        /// </summary>
        /// <param name="node">текущий "элемент дерева" (ref  передача по ссылке)</param>
        /// <param name="s">строка, в которой накапливается результат (ref - передача по ссылке)</param>
        /// <param name="detailed"></param>
        public void CLR(BinaryTreeP node, ref string s, bool detailed)
        {
            if (node != null)
            {
                s += node.Data.ToString() + " "; // запомнить текущее значение
                CLR(node.Left, ref s, detailed); // обойти левое поддерево
                CLR(node.Right, ref s, detailed); // обойти правое поддерево
            }
        }

        /// <summary>
        /// Обратный обход (LCR - left, center, right) 
        /// </summary>
        /// <param name="node">текущий "элемент дерева" (ref - передача по ссылке)</param>
        /// <param name="s">строка, в которой накапливается результат (ref - передача по ссылке)</param>
        /// <param name="detailed"></param>
        public void LCR(BinaryTreeP node, ref string s, bool detailed)
        {
            if (node != null)
            {
                LCR(node.Left, ref s, detailed); // обойти левое поддерево
                s += node.Data.ToString() + " "; // запомнить текущее значение
                LCR(node.Right, ref s, detailed); // обойти правое поддерево
            }
        }


        /// <summary>
        /// Концевой обход (RCL -right, center, left)
        /// </summary>
        /// <param name="node">текущий "элемент дерева" (ref - передача по ссылке)</param>
        /// <param name="s">строка, в которой накапливается результат (ref - передача по ссылке)</param>
        /// <param name="detailed"></param>
        public void RCL(BinaryTreeP node, ref string s, bool detailed)
        {
            if (node != null)
            {
                RCL(node.Right, ref s, detailed); // обойти правое поддерево
                s += node.Data.ToString() + " "; // запомнить текущее значение
                RCL(node.Left, ref s, detailed); // обойти левое поддерево
            }
        }
        /// <summary>
        /// Обход дерева в ширину (итерационно, используется очередь)
        /// </summary>
        /// <param name="node">текущий "элемент дерева" </param>
        /// <param name="s">строка, в которой накапливается результат (ref - передача по ссылке)</param>
        /// <param name="detailed"></param>
        public void Across(BinaryTreeP node, ref string s, bool detailed)
        {
            var queue = new Queue<BinaryTreeP>(); // создать новую очередь
            queue.Enqueue(node); // поместить в очередь первый уровень
            while (queue.Count != 0) // пока очередь не пуста
            {
                //если у текущей ветви есть листья, их тоже добавить в очередь
                if (queue.Peek().Left != null)
                {
                    queue.Enqueue(queue.Peek().Left);
                }
                if (queue.Peek().Right != null)
                {
                    queue.Enqueue(queue.Peek().Right);
                }
                //извлечь из очереди информационное поле последнего элемента
                s += queue.Peek().Data.ToString() + " "; // убрать последний элемент очереди
                queue.Dequeue();
            }
        }

        /// <summary>
        /// Зеркальное отражение дерева
        /// </summary>
        /// <param name="node">Корень дерева</param>
        /// <returns></returns>
        public BinaryTreeP MirrorTree(BinaryTreeP node)
        {
            if (node.Left != null && node.Right != null)
            {
                BinaryTreeP temp = new BinaryTreeP();
                temp = node.Left;
                node.Left = node.Right;
                node.Right = temp;
                MirrorTree(node.Right);
                MirrorTree(node.Left);
            }
            else
            {
                if (node.Left == null && node.Right != null)
                    return MirrorTree(node.Right);
                else if (node.Right == null && node.Left != null)
                    return MirrorTree(node.Left);
                else return null;
            }
            return null;
        }
        /// <summary>
        /// Количество узлов в дереве
        /// </summary>
        /// <param name="node">Корень дерева</param>
        /// <returns></returns>
        public int NumNodes(BinaryTreeP node)
        {
            if (node == null) return 0;
            return (NumNodes(node.Left) + 1 + NumNodes(node.Right));
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
                    FileData(this, ref s);
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

        private void FileData(BinaryTreeP node, ref List<int> s)
        {
            if (node != null)
            {
                var queue = new Queue<BinaryTreeP>(); // создать новую очередь
                queue.Enqueue(node); // поместить в очередь первый уровень
                while (queue.Count != 0) // пока очередь не пуста
                {
                    //если у текущей ветви есть листья, их тоже добавить в очередь
                    if (queue.Peek().Left != null)
                    {
                        queue.Enqueue(queue.Peek().Left);
                    }
                    if (queue.Peek().Right != null)
                    {
                        queue.Enqueue(queue.Peek().Right);
                    }
                    //извлечь из очереди информационное поле последнего элемента
                    s.Add((int)queue.Peek().Data); // убрать последний элемент очереди
                    queue.Dequeue();
                }
            }
        }

        /// <summary>
        /// Считывание бинарного дерева из файла
        /// </summary>
        /// <returns></returns>
        public BinaryTreeP ReadFile()
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
                    BinaryTreeP newTree = new BinaryTreeP();
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
