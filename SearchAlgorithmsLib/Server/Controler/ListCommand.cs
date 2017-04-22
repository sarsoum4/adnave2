using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
using Server.Adapter;
using Server.TheModel;
using System.Net.Sockets;
using SearchAlgorithmsLib;
using Newtonsoft.Json.Linq;

namespace Server.Controler
{
    public class ListCommand : ICommand
    {

        private IModel model;

        private SolutionJson solJson;

        public ListCommand(IModel model)
        {
            this.model = model;
        }


        public string Execute(string[] args, TcpClient client = null)
        {
            return this.model.GamesList();
        }
    }
}
