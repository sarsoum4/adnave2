using MazeLib;
using MazeGeneratorLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchAlgorithmsLib;

namespace TestConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            CompareSolvers();
        }



        public static void CompareSolvers()
        {
            DFSMazeGenerator generator = new DFSMazeGenerator();
            Maze m = generator.Generate(5, 6);
            Console.WriteLine(m.ToString());

            BestFirstSearch<CellType> bfs = new BestFirstSearch<CellType>();
            DFS<CellType> dfs = new DFS<CellType>();

            Solution<CellType> SolBFS = bfs.search(m);
            Solution<CellType> SolDFS = dfs.search(m);

            Console.ReadLine();
        }

    }
}
