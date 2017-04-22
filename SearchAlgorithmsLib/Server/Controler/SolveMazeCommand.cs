using System;
using MazeLib;
using Server.Adapter;
using Server.TheModel;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using SearchAlgorithmsLib;

namespace Server.Controler
{
    public class SolveMazeCommand : ICommand
    {

        private IModel model;
        private MazeAdapter<int> adapter;
        private ISearcher<int> ser;
        private Solution<int> sol;
        private SolutionAdapter solAdapter;

        private SolutionJson solJson;

        public SolveMazeCommand(IModel model)
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
            else if (algorithm.Equals(1))
            {
                ser = new DFS<int>();
            }
            else
            {
                //return algorithm input invalid
            }

            sol = ser.search(adapter);
            solAdapter = new SolutionAdapter<T>(sol);
            //add the solved maze to the solved mazes dictionary in the model
            this.model.addSolvedMaze(name, solAdapter.ToString());
            solJson = new SolutionJson(name, solAdapter.ToString(), ser.getNumberOfNodesEvaluated);
            return solJson.solveToJSON();
        }
    }
}
