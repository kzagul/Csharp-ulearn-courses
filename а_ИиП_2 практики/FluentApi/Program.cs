using System;
using System.Diagnostics;
using System.IO;

namespace FluentApi.Graph
{
    class Program
    {
        // Для решения этой задачи установленный graphviz не нужен. 
        // Однако этот Main демонстрирует ради чего всё это делается.
        // Чтобы этот проект заработал, установите себе graphviz.
        // Инструкции есть на сайте https://www.graphviz.org/download/
        // Укажите путь до исполняемого файла dot в константе ниже:

        private const string PathToGraphviz = @"c:\Program Files (x86)\Graphviz2.38\bin\dot.exe";

        static void Main(string[] args)
        {
            var dot =
                DotGraphBuilder.DirectedGraph("CommentParser")
                    .AddNode("START").With(a => a.Shape(NodeShape.Ellipse).Color("green"))
                    .AddNode("comment").With(a => a.Shape(NodeShape.Box))
                    .AddEdge("START", "slash").With(a => a.Label("'/'"))
                    .AddEdge("slash", "comment").With(a => a.Label("'/'"))
                    .AddEdge("comment", "comment").With(a => a.Label("other chars"))
                    .AddEdge("comment", "START").With(a => a.Label("'\\\\n'"))
                    .Build();
            Console.WriteLine(dot);
            ShowRenderedGraph(dot);
        }

        private static void ShowRenderedGraph(string dot)
        {
            File.WriteAllText("comment.dot", dot);
            var processStartInfo = new ProcessStartInfo(PathToGraphviz)
            {
                UseShellExecute = false,
                Arguments = "comment.dot -Tpng -o comment.png",
                RedirectStandardError = true,
                RedirectStandardOutput = true,
            };
            var p = Process.Start(processStartInfo);
            p.WaitForExit();
            Console.WriteLine(p.StandardError.ReadToEnd());
            Console.WriteLine("Result is saved to comment.png");
            //Process.Start("comment.png");
        }
    }
}