using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickGraph;
using QuickGraph.Graphviz;
using QuickGraph.Graphviz.Dot;
using System.Diagnostics;
using System.Windows.Forms;

namespace BinaryTree
{
    public sealed class FileDotEngine : IDotEngine
    {
        /// <summary>
        /// Метод запуска приложения для генерации изображения
        /// </summary>
        /// <param name="imageType"></param>
        /// <param name="dot"></param>
        /// <param name="outputFileName"></param>
        /// <returns></returns>
        public string Run(GraphvizImageType imageType, string dot, string outputFileName)
        {
            string output = outputFileName;
            System.IO.File.WriteAllText(output, dot);

            try
            {
                Process process = new Process();
                // Путь к приложению для генерации изображения дерева
                process.StartInfo = new ProcessStartInfo("C:\\Users\\aandr\\source\\repos\\BinaryTree\\packages\\Graphviz.2.38.0.2\\dot.exe");
                // Аргументы командной строки запуска приложения
                process.StartInfo.Arguments = @"dot -Tgif graph.dot -o " + GetPath();
                process.Start();
            }
            catch (Exception)
            {
                MessageBox.Show("Пакет Graphviz отсутвствует!", "Error");
            }

            return output;
        }

        /// <summary>
        /// Метод для получения пути, где необходимо сохранить изображение
        /// </summary>
        /// <returns></returns>
        private string GetPath()
        {
            SaveFileDialog save = new SaveFileDialog(); // save - имя компонента SaveFileDialog
            // задание начальной директории
            save.InitialDirectory = @"С:\";
            // задание свойства Filter
            save.Filter = "png files (*.png)|*.png";
            // задание свойства FilterIndex – выбор типа файла
            save.FilterIndex = 2;
            // свойство Title - название окна диалога выбора файла
            save.Title = "Сохранить файл";
            if (save.ShowDialog() == DialogResult.OK)
                return save.FileName;
            else
                return "graph.png";
        }
    }
}
