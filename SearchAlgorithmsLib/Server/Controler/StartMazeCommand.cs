using System;
using MazeLib;
using MazeAdapter;
using Server.TheModel;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server.Controler
{
    public class StartMazeCommand : ICommand
    {

        private IModel model;
        private MazeAdapter adapter;
        private Isearchable<T> ser;
        private Solution<T> sol;
        private SolutionAdapter<T> solAdapter;

        public StartMazeCommand(IModel model)
        {
            this.model = model;
        }

        public string Execute(string[] args, TcpClient client = null)
        {
            string name = args[0];
            int algorithm = args[1];
            //get the maze from the model
            Maze mazeFromModel = this.model.getMaze(name);
            if (mazeFromModel == null)
            {
                //return there is no maze
            }

            //create new adapter
            adapter = new MazeAdapter(mazeFromModel);

            //if 0 then bfs, if 1 dfs, otherwise print error
            if (algorithm == 0)
            {
                ser = new BestFirstSearch<T>();
            }
            else if (algorithm == 1)
            {
                ser = new DFS<T>();
            }
            else
            {
                //return algorithm input invalid
            }

            sol = ser.search(adapter);
            solAdapter = new SolutionAdapter<T>(sol);
            this.model.addSolvedMaze(name, solAdapter.toString());
            return solAdapter.toString();
        }
    }
}
