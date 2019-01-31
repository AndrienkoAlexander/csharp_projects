using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickGraph;
using QuickGraph.Graphviz;
using QuickGraph.Graphviz.Dot;
using System.Windows.Forms;


namespace BinaryTree
{
    public class GraphvizImage
    {
        /// <summary>
        /// Объект графа для генерации dot файла
        /// </summary>
        private AdjacencyGraph<string, Edge<string>> graph;

        /// <summary>
        /// Метод для формирования dot файла и изображения
        /// </summary>
        /// <param name="tree"></param>
        public void DrawTreeQuickGraph( object tree)
        {
            graph = new AdjacencyGraph<string, Edge<string>>();
            //Взависимости от выбранной реализации
            if(tree is AVLTree)
            {
                FormAVLTree((AVLTree)tree);
            }
            else if (tree is BinaryTreeP)
            {
                FormPTree((BinaryTreeP)tree);
            }
            else
            {
                FormArrTree((BinaryTreeArray)tree);
            }

            var graphViz = new GraphvizAlgorithm<string, Edge<string>>(graph, @".\", GraphvizImageType.Gif);
            graphViz.FormatVertex += FormatVertex;
            graphViz.FormatEdge += FormatEdge;
            graphViz.Generate(new FileDotEngine(), "graph.dot");
        }

        private static void FormatVertex(object sender, FormatVertexEventArgs<string> e)
        {
            e.VertexFormatter.Label = e.Vertex;
            //Форма узла
            e.VertexFormatter.Shape = GraphvizVertexShape.Circle;
            //Цвет узора
            e.VertexFormatter.StrokeColor = GraphvizColor.Black;
            //Настройки шрифта
            e.VertexFormatter.Font = new GraphvizFont("Calibri", 11);
        }

        private static void FormatEdge(object sender, FormatEdgeEventArgs<string, Edge<string>> e)
        {
            e.EdgeFormatter.FontGraphvizColor = GraphvizColor.Black;
            e.EdgeFormatter.StrokeGraphvizColor = GraphvizColor.Black;
        }

        private void FormAVLTree( AVLTree node)
        {
            var queue = new Queue<AVLTree>(); // создать новую очередь
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
                graph.AddVertex(queue.Peek().Data.ToString()); // убрать последний элемент очереди
                if (queue.Peek().Parent != null)
                    graph.AddEdge(new Edge<string>(queue.Peek().Parent.Data.ToString(), queue.Peek().Data.ToString()));
                queue.Dequeue();
            }
        }

        private void FormPTree(BinaryTreeP node)
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
                graph.AddVertex(queue.Peek().Data.ToString()); // убрать последний элемент очереди
                if (queue.Peek().Parent != null)
                    graph.AddEdge(new Edge<string>(queue.Peek().Parent.Data.ToString(), queue.Peek().Data.ToString()));
                queue.Dequeue();
            }
        }

        private void FormArrTree(BinaryTreeArray treeobj)
        {
            List<int?> tree = treeobj.tree;
            var queue = new Queue<int>(); // создать новую очередь
            int addr = 1;
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
                graph.AddVertex(tree[queue.Peek()].ToString()); // убрать последний элемент очереди
                if(addr/2 >= 1)
                {
                    graph.AddEdge(new Edge<string>(queue.Peek().ToString(), queue.Peek().ToString()));
                }
                queue.Dequeue();
            }
        }
    }
}
