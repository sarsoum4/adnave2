using System;
using MazeLib;
using Server.TheModel;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server.Controler
{
    public class CloseCommand : ICommand
    {
        private IModel model;


        public CloseCommand(IModel model)
        {
            this.model = model;
        }

        public string Execute(string[] args, TcpClient client = null)
        {
            this.model.CloseGame(args[0]);
            return "-1";
        }
    }
}