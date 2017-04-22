using System;
using MazeLib;
using Server.TheModel;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Server.Adapter;
using SearchAlgorithmsLib;

namespace Server.Controler
{
    public class StartMazeCommand : ICommand
    {

        private IModel model;
        private MazeAdapter<int> adapter;
        private ISearcher<int> ser;
        private Solution<int> sol;
        private SolutionAdapter solAdapter;

        public StartMazeCommand(IModel model)
        {
            this.model = model;
        }

        public string Execute(string[] args, TcpClient client = null)
        {
            string name = args[0];
            string algorithm = args[1];
            //get the maze from the model
            Maze mazeFromModel = this.model.getMaze(name);
            if (mazeFromModel == null)
            {
                //return there is no maze
            }

            //create new adapter
            adapter = new MazeAdapter<int>(mazeFromModel);

            //if 0 then bfs, if 1 dfs, otherwise print error
            if (algorithm.Equals(0))
            {
                ser = new BestFirstSearch<int>();
            }
            else if (algorithm.Equals(0))
            {
                ser = new DFS<int>();
            }
            else
            {
                //return algorithm input invalid
            }

            sol = ser.search(adapter.GetMaze);
            solAdapter = new SolutionAdapter<int>(sol);
            this.model.addSolvedMaze(name, solAdapter.ToString());
            return solAdapter.ToString();
        }
    }
}
