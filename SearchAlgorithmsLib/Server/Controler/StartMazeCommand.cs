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
            int rows = int.Parse(args[1]);
            int cols = int.Parse(args[2]);

            //check if the maze is already in the model. if not - generate it
            if(!this.model.CheckIfMazeInDictionary(name))
            {
                GenerateMazeCommand generate = new GenerateMazeCommand(this.model);
                generate.Execute(args, null);
            }

            //add the maze to the list of games ready to be played
            this.model.AddGameToBePlayed(name);

            return "";
        }
    }
}
