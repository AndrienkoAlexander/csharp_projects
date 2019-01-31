using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Microsoft.Glee.Drawing;
using QuickGraph;

namespace BinaryTree
{
    public partial class BinaryTreeForm : Form
    {
        /// <summary>
        /// Форма для отображения диаграммы сравнения реализаций 
        /// </summary>
        private Diagram diagram;
        /// <summary>
        /// Форма с информацией о проекте и авторе проекта
        /// </summary>
        private AboutProgramForm about;
        /// <summary>
        /// АВЛ-дерево
        /// </summary>
        private AVLTree AVLtree;
        /// <summary>
        /// Бинарное дерево поиска на указателях
        /// </summary>
        private BinaryTreeP BinaryTree;
        /// <summary>
        /// Бинарное дерево поиска на массиве 
        /// </summary>
        private BinaryTreeArray BinaryTreeA;
        private ErrorProvider errorInput, errorOperation, errorRealisation;
        /// <summary>
        /// Граф для вывода дерева в MSAGL
        /// </summary>
        private Graph Mgraph;
        /// <summary>
        /// Время выполнения операций в АВЛ-дереве
        /// </summary>
        private OperationTime timeAVL;
        /// <summary>
        /// Время выполнения операций в бинарном дереве поиска на указателях
        /// </summary>
        private OperationTime timeBP;
        /// <summary>
        /// Время выполнения операций в бинарном дереве поиска на массиве
        /// </summary>
        private OperationTime timeBA;

        public BinaryTreeForm()
        {
            InitializeComponent();
            AVLtree = new AVLTree();
            errorInput = new ErrorProvider();
            errorOperation = new ErrorProvider();
            errorRealisation = new ErrorProvider();
            Mgraph = new Graph("Tree");
            BinaryTree = new BinaryTreeP();
            BinaryTreeA = new BinaryTreeArray();
            timeAVL = new OperationTime();
            timeBP = new OperationTime();
            timeBA = new OperationTime();
            Operations.SelectedIndex = 0;
            Realisations.SelectedIndex = 0;
        }

        /// <summary>
        /// Обработчик нажатия на кнопку Выполнить
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Calculate_Click(object sender, EventArgs e)
        {
            int k = Operations.SelectedIndex;
            int r = Realisations.SelectedIndex;
            string result = "";

            // Если дерево пустое, то разрешается только вставка
            if ((AVLtree.Data == null && k != 0 && r == 0) || (BinaryTree.Data == null && k != 0 && r == 1) || (BinaryTreeA.tree[1] == null && k != 0 && r == 2))
            {
                MessageBox.Show("Дерево пусто!", "Ошибка");
                return;
            }

            switch (k)
            {
                case 0: // Вставка
                    if(!CheckInput()) { return; } // Проверка вводимых данных
                    switch (r)
                    {
                        case 0:
                            timeAVL.TimeStart(); // запуск времени
                            AVLtree = AVLtree.Insert(Convert.ToInt32(DataInput.Text));
                            timeAVL.InsertTimeStop(); // остановка времени
                            break;
                        case 1:
                            timeBP.TimeStart(); // запуск времени
                            BinaryTree.Insert(Convert.ToInt32(DataInput.Text));
                            timeBP.InsertTimeStop(); // остановка времени
                            break;
                        case 2:
                            timeBA.TimeStart(); // запуск времени
                            BinaryTreeA.Insert(Convert.ToInt32(DataInput.Text));
                            timeBA.InsertTimeStop(); // остановка времени
                            break;
                    }
                    break;
                case 1:
                    if (!CheckInput()) { return; }
                    switch (r) // Удаление
                    {
                        case 0:
                            timeAVL.TimeStart();// запуск времени
                            AVLtree = AVLtree.Remove(Convert.ToInt32(DataInput.Text));
                            timeAVL.RemoveTimeStop(); // остановка времени
                            break;
                        case 1:
                            timeBP.TimeStart();// запуск времени
                            BinaryTree.Remove(Convert.ToInt32(DataInput.Text));
                            timeBP.RemoveTimeStop(); // остановка времени
                            break;
                        case 2:
                            timeBA.TimeStart();
                            BinaryTreeA.RemoveNodeData(Convert.ToInt32(DataInput.Text));
                            timeBA.RemoveTimeStop(); // остановка времени
                            break;
                    }
                    break;
                case 2:
                    int height = 0;
                    switch (r) // Высота дерева
                    {
                        case 0:
                            height = AVLtree.Height(AVLtree);
                            break;
                        case 1:
                            height = BinaryTree.Height(BinaryTree);
                            break;
                        case 2:
                            height = BinaryTreeA.Height(1);
                            break;
                    }
                    result = "Высота дерева = " + height;
                    break;
                case 3:
                    switch (r) // Удаление дерева
                    {
                        case 0:
                            AVLtree = new AVLTree();
                            break;
                        case 1:
                            BinaryTree = new BinaryTreeP();
                            break;
                        case 2:
                            BinaryTreeA = new BinaryTreeArray();
                            break;
                    }
                    Mgraph = new Graph("Tree");
                    gViewer.Graph = Mgraph;
                    break;
                case 4:
                    int width = 0;
                    switch (r) // Максимальная ширина
                    {
                        case 0:
                            width = AVLtree.MaxWidth(AVLtree);
                            break;
                        case 1:
                            width = BinaryTree.MaxWidth(BinaryTree);
                            break;
                        case 2:
                            width = BinaryTreeA.MaxWidth(1);
                            break;
                    }
                    result = "Максимальная ширина дерева = " + width;
                    break;
                case 5:
                    int nodes = 0;
                    switch (r) // Количество узлов 
                    {
                        case 0:
                            nodes = AVLtree.NumNodes(AVLtree);
                            break;
                        case 1:
                            nodes = BinaryTree.NumNodes(BinaryTree);
                            break;
                        case 2:
                            nodes = BinaryTreeA.CountElements();
                            break;
                    }
                    result = "Количество узлов в дереве = " + nodes;
                    break;
                case 6:
                    if (!CheckInput()) { return; }
                    Mgraph = new Graph("Tree");
                    switch (r) // Поиск узла
                    {
                        case 0:
                            timeAVL.TimeStart(); // запуск времени
                            if (AVLtree.Find(Convert.ToInt32(DataInput.Text)) == null)
                            {
                                timeAVL.FindTimeStop();  // остановка времени
                                result = "Элемент не найден!";
                                DrawAVLTree(AVLtree, null);
                            }
                            else
                            {
                                timeAVL.FindTimeStop();  // остановка времени
                                result = "Элемент найден!"; 
                                DrawAVLTree(AVLtree, Convert.ToInt32(DataInput.Text));
                            }
                            break;
                        case 1:
                            timeBP.TimeStart(); // запуск времени
                            if (BinaryTree.Find(Convert.ToInt32(DataInput.Text)) == null)
                            {
                                timeBP.FindTimeStop();  // остановка времени
                                result = "Элемент не найден!";
                                DrawBTree(BinaryTree, null);
                            }
                            else
                            {
                                timeBP.FindTimeStop();  // остановка времени
                                result = "Элемент найден!";
                                DrawBTree(BinaryTree, Convert.ToInt32(DataInput.Text));
                            }
                            break;
                        case 2:
                            timeBA.TimeStart(); // запуск времени
                            if (BinaryTreeA.Find(Convert.ToInt32(DataInput.Text)) == -1)
                            {
                                timeBA.FindTimeStop();  // остановка времени
                                result = "Элемент не найден!";
                                DrawBTree(BinaryTree, null);
                            }
                            else
                            {
                                timeBA.FindTimeStop();  // остановка времени
                                result = "Элемент найден!";
                                DrawBATree(1, Convert.ToInt32(DataInput.Text));
                            }
                            break;
                    }
                    gViewer.Graph = Mgraph;
                    break;
                case 7:
                    int max = 0;
                    Mgraph = new Graph("Tree");
                    switch (r) // Поиск максимального значения
                    {
                        case 0:
                            max =(int)AVLtree.FindMax(AVLtree).Data;
                            DrawAVLTree(AVLtree, max);
                            break;
                        case 1:
                            max = (int)BinaryTree.FindMax(BinaryTree).Data;
                            DrawBTree(BinaryTree, max);
                            break;
                        case 2:
                            max = (int)BinaryTreeA.tree[BinaryTreeA.FindMax(1)];
                            DrawBATree(1, max);
                            break;
                    }
                    gViewer.Graph = Mgraph;
                    result = "Максимальный элемент = " + max;
                    break;
                case 8:
                    int min = 0;
                    Mgraph = new Graph("Tree");
                    switch (r) // Поиск минимального значения
                    {
                        case 0:
                            min = (int)AVLtree.FindMin(AVLtree).Data;
                            DrawAVLTree(AVLtree, min);
                            break;
                        case 1:
                            min = (int)BinaryTree.FindMin(BinaryTree).Data;
                            DrawBTree(BinaryTree, min);
                            break;
                        case 2:
                            min = (int)BinaryTreeA.tree[BinaryTreeA.FindMin(1)];
                            DrawBATree(1, min);
                            break;
                    }
                    gViewer.Graph = Mgraph;
                    result = "Минимальный элемент = " + min;
                    break;
                case 9:
                    switch (r) // Обход в глубину
                    {
                        case 0:
                            AVLtree.CLR(AVLtree, ref result, false);
                            break;
                        case 1:
                            BinaryTree.CLR(BinaryTree, ref result, false);
                            break;
                        case 2:
                            BinaryTreeA.CLR(1, ref result, false);
                            break;
                    }
                    break;
                case 10:
                    switch (r) // Обход в глубину
                    {
                        case 0:
                            AVLtree.LCR(AVLtree, ref result, false);
                            break;
                        case 1:
                            BinaryTree.LCR(BinaryTree, ref result, false);
                            break;
                        case 2:
                            BinaryTreeA.LCR(1, ref result, false);
                            break;
                    }
                    break;
                case 11:
                    switch (r) // Обход в глубину
                    {
                        case 0:
                            AVLtree.RCL(AVLtree, ref result, false);
                            break;
                        case 1:
                            BinaryTree.RCL(BinaryTree, ref result, false);
                            break;
                        case 2:
                            BinaryTreeA.RCL(1, ref result, false);
                            break;
                    }
                    break;
                case 12:
                    switch (r) // Обход в ширину
                    {
                        case 0:
                            AVLtree.Across(AVLtree, ref result, false);
                            break;
                        case 1:
                            BinaryTree.Across(BinaryTree, ref result, false);
                            break;
                        case 2:
                            BinaryTreeA.Across(1, ref result, false);
                            break;
                    }
                    break;
                case 13:
                    switch (r) // Зеркальное отражение дерева
                    {
                        case 0:
                            AVLtree.MirrorTree(AVLtree);
                            break;
                        case 1:
                            BinaryTree.MirrorTree(BinaryTree);
                            break;
                        case 2:
                            BinaryTreeA.MirrorTree(1);
                            break;
                    }
                    break;
                default:
                    return;
            }
            if (k == 0 || k == 1 || k == 13) // Если внешний вид дерева изменился, то перерисовываем дерево
            {
                Mgraph = new Graph("Tree");
                switch (r)
                {
                    case 0:
                        DrawAVLTree(AVLtree, null);
                        break;
                    case 1:
                        DrawBTree(BinaryTree, null);
                        break;
                    case 2:
                        DrawBATree(1, null);
                        break;
                }
                gViewer.Graph = Mgraph;
            }
            else 
            {
                Results.Text = result;
            }
        }

        /// <summary>
        /// Обработчик нажатия на элемент меню About program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            about = new AboutProgramForm();
            about.Show();
        }

        /// <summary>
        /// Формирование графа АВЛ-дерева
        /// </summary>
        /// <param name="node"></param>
        /// <param name="select"></param>
        private void DrawAVLTree(AVLTree node, int? select)
        {
            if (node.Data != null)
            {
                Mgraph.GraphAttr.NodeAttr.Shape = Shape.Circle;
                Node gnode;
                if (node.Parent == null && node.Data != null)
                {
                    gnode = Mgraph.AddNode(node.Data.ToString());
                    if (node.Data == select)
                        gnode.Attr.Fillcolor = Microsoft.Glee.Drawing.Color.Red;
                }
                else
                {
                    if (node.Parent.Left == node)
                    {
                        gnode = Mgraph.AddNode(node.Data.ToString());
                        if (node.Data == select)
                            gnode.Attr.Fillcolor = Microsoft.Glee.Drawing.Color.Red;
                        Edge edge = Mgraph.AddEdge(node.Parent.Data.ToString(), "L" ,node.Data.ToString());
                        edge.Attr.ArrowHeadAtSource = ArrowStyle.None;
                    }

                    if (node.Parent.Right == node)
                    {
                        gnode = Mgraph.AddNode(node.Data.ToString());
                        if (node.Data == select)
                            gnode.Attr.Fillcolor = Microsoft.Glee.Drawing.Color.Red;
                        Edge edge = Mgraph.AddEdge(node.Parent.Data.ToString(), "R", node.Data.ToString());
                        edge.Attr.ArrowHeadAtSource = ArrowStyle.None;
                    }
                }
                if (node.Left != null)
                {
                    DrawAVLTree(node.Left, select);
                }
                if (node.Right != null)
                {
                    DrawAVLTree(node.Right, select);
                }
            }
        }

        /// <summary>
        /// Формирование графа бинарного дерева поиска на указателях
        /// </summary>
        /// <param name="node"></param>
        /// <param name="select"></param>
        private void DrawBTree(BinaryTreeP node, int? select)
        {
            if (node != null)
            {
                Mgraph.GraphAttr.NodeAttr.Shape = Shape.Circle;
                Node gnode;
                if (node.Parent == null)
                {
                    gnode = Mgraph.AddNode(node.Data.ToString());
                    if (node.Data == select)
                        gnode.Attr.Fillcolor = Microsoft.Glee.Drawing.Color.Red;
                }
                else
                {
                    if (node.Parent.Left == node)
                    {
                        gnode = Mgraph.AddNode(node.Data.ToString());
                        if (node.Data == select)
                            gnode.Attr.Fillcolor = Microsoft.Glee.Drawing.Color.Red;
                        Edge edge = Mgraph.AddEdge(node.Parent.Data.ToString(), "L", node.Data.ToString());
                        edge.Attr.ArrowHeadAtSource = ArrowStyle.None;
                    }

                    if (node.Parent.Right == node)
                    {
                        gnode = Mgraph.AddNode(node.Data.ToString());
                        if (node.Data == select)
                            gnode.Attr.Fillcolor = Microsoft.Glee.Drawing.Color.Red;
                        Edge edge = Mgraph.AddEdge(node.Parent.Data.ToString(), "R", node.Data.ToString());
                        edge.Attr.ArrowHeadAtSource = ArrowStyle.None;
                    }
                }
                if (node.Left != null)
                {
                    DrawBTree(node.Left, select);
                }
                if (node.Right != null)
                {
                    DrawBTree(node.Right, select);
                }
            }
        }

        /// <summary>
        /// Формирование графа бинарного дерева поиска на массиве
        /// </summary>
        /// <param name="node"></param>
        /// <param name="select"></param>
        private void DrawBATree(int addr, int? select)
        {
            if (BinaryTreeA.tree[addr] != null)
            {
                Mgraph.GraphAttr.NodeAttr.Shape = Shape.Circle;
                Node gnode;
                if (addr == 1)
                {
                    gnode = Mgraph.AddNode(BinaryTreeA.tree[addr].ToString());
                    if (BinaryTreeA.tree[addr] == select)
                        gnode.Attr.Fillcolor = Microsoft.Glee.Drawing.Color.Red;
                }
                else
                {
                    if ((addr/2)*2 == addr)
                    {
                        gnode = Mgraph.AddNode(BinaryTreeA.tree[addr].ToString());
                        if (BinaryTreeA.tree[addr] == select)
                            gnode.Attr.Fillcolor = Microsoft.Glee.Drawing.Color.Red;
                        Edge edge = Mgraph.AddEdge(BinaryTreeA.tree[addr/2].ToString(), "L", BinaryTreeA.tree[addr].ToString());
                        edge.Attr.ArrowHeadAtSource = ArrowStyle.None;
                    }

                    if ((addr / 2) * 2 + 1 == addr)
                    {
                        gnode = Mgraph.AddNode(BinaryTreeA.tree[addr].ToString());
                        if (BinaryTreeA.tree[addr] == select)
                            gnode.Attr.Fillcolor = Microsoft.Glee.Drawing.Color.Red;
                        Edge edge = Mgraph.AddEdge(BinaryTreeA.tree[addr / 2].ToString(), "R", BinaryTreeA.tree[addr].ToString());
                        edge.Attr.ArrowHeadAtSource = ArrowStyle.None;
                    }
                }
                if (BinaryTreeA.tree[addr*2] != null)
                {
                    DrawBATree(addr * 2, select);
                }
                if (BinaryTreeA.tree[addr * 2+1] != null)
                {
                    DrawBATree(addr * 2+1, select);
                }
            }
        }

        /// <summary>
        /// Обработчик события смены значения в ComboBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mgraph = new Graph("Tree"); 
            switch (Realisations.SelectedIndex) // Если поменялась реализация, то меняем изображение
            {
                case 0:
                    AVLtree = AVLtree.ReadFile();
                    DrawAVLTree(AVLtree, null);
                    break;
                case 1:
                    BinaryTree = BinaryTree.ReadFile();
                    DrawBTree(BinaryTree, null);
                    break;
                case 2:
                    BinaryTreeA = BinaryTreeA.ReadFile();
                    DrawBATree(1, null);
                    break;
            }
            gViewer.Graph = Mgraph;
        }

        /// <summary>
        /// Обработчик нажатия на элемент меню Save tree
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveBinaryTree_Click(object sender, EventArgs e)
        {
            switch (Realisations.SelectedIndex)
            {
                case 0:
                    if (AVLtree.Data == null)
                    {
                        MessageBox.Show("Дерево пусто!", "Ошибка!");
                        break;
                    }
                    AVLtree.WriteFile();
                    break;
                case 1:
                    if (BinaryTree.Data == null)
                    {
                        MessageBox.Show("Дерево пусто!", "Ошибка!");
                        break;
                    }
                    BinaryTree.WriteFile();
                    break;
                case 2:
                    if (BinaryTreeA.tree[1] == null)
                    {
                        MessageBox.Show("Дерево пусто!", "Ошибка!");
                        break;
                    }
                    BinaryTreeA.WriteFile();
                    break;
            }
        }

        /// <summary>
        /// Обработчик нажатия на элемент меню Open file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Realisations_SelectedIndexChanged(object sender, EventArgs e)
        {
            Mgraph = new Graph("Tree");
            switch (Realisations.SelectedIndex)
            {
                case 0:
                    if (AVLtree.Data == null)
                        break;
                    DrawAVLTree(AVLtree, null);
                    break;
                case 1:
                    if (BinaryTree.Data == null)
                        break;
                    DrawBTree(BinaryTree, null);
                    break;
                case 2:
                    if (BinaryTreeA.tree[1] == null)
                        break;
                    DrawBATree(1, null);
                    break;
            }
            gViewer.Graph = Mgraph;
        }

        /// <summary>
        /// Обработчик нажатия на кнопку Диаграмма сравнения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Diagramm_Click(object sender, EventArgs e)
        {
            diagram = new Diagram(timeAVL, timeBP, timeBA);
            diagram.Show();
        }

        /// <summary>
        /// Обработчик нажатия на кнопку GraphViz изображение
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Graphvizbutton_Click(object sender, EventArgs e)
        {
            GraphvizImage image = new GraphvizImage();
            switch (Realisations.SelectedIndex)
            {
                case 0:
                    if (AVLtree.Data == null)
                    {
                        MessageBox.Show("Дерево пусто!", "Ошибка!");
                        break;
                    }
                    image.DrawTreeQuickGraph(AVLtree);
                    break;
                case 1:
                    if (BinaryTree.Data == null)
                    {
                        MessageBox.Show("Дерево пусто!", "Ошибка!");
                        break;
                    }
                    image.DrawTreeQuickGraph(BinaryTree);
                    break;
                case 2:
                    if (BinaryTreeA.tree[1] == null)
                    {
                        MessageBox.Show("Дерево пусто!", "Ошибка!");
                        break;
                    }
                    image.DrawTreeQuickGraph(BinaryTreeA);
                    break;
            }
        }

        /// <summary>
        /// Метод проверяющий корректность введенных данных
        /// </summary>
        /// <returns></returns>
        public bool CheckInput()
        {
            if(DataInput.Text.Length == 0)
            {
                errorInput.SetError(DataInput, "Сперва введите значение узла!");
                DataInput.Focus();
                return false;
            }
            else
            {
                Regex reg = new Regex(@"^[\+-]?\d{1,9}$");
                if (reg.IsMatch(DataInput.Text))
                {
                    errorInput.SetError(DataInput, "");
                    DataInput.Focus();
                    return true;
                }
                else
                {
                    errorInput.SetError(DataInput, "Сперва введите значение узла!");
                    return false;
                }
            }
        }

        private void DataInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar == (char)Keys.Back) && !((e.KeyChar == '-') && DataInput.Text.Length == 0))
            {
                Regex reg = new Regex(@"^[\+-]?\d{1,9}$");
                string s = DataInput.Text + e.KeyChar.ToString();
                // проверка строки+символа на соответствие шаблону
                if (!reg.IsMatch(s))
                    // игнорирование "плохих" символов
                    e.Handled = true;
            }
        }
    }
}
                    