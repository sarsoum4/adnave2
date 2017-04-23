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
    public class PlayCommand : ICommand
    {
        private IModel model;


        public PlayCommand(IModel model)
        {
            this.model = model;
        }

        public string Execute(string[] args, TcpClient client = null)
        {
            string move = args[0];
            this.model.play(move, client);
            return move;
        }
    }
}
