using MazeLib;
using Server.TheModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;


namespace Server.Controler
{
    public class JoinCommaned : ICommand
    {

        private IModel model;


        public JoinCommaned(IModel model)
        {
            this.model = model;
        }

        public string Execute(string[] args, TcpClient client = null)
        {
            string name = args[0];
            //check if the given game exist.
            if(!this.model.CheckIfMazeInDictionary(name))
            {
                return "maze does not exist";
            }

            return this.model.GetMaze(name).ToJSON();
        }
    }
}
