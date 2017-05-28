
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using Server.TheModel;
using Server.View;

namespace Server.Controler
{
    public class Controller : IController
    {

        private Dictionary<string, ICommand> commands;
        private IModel model;
        private IView view;


        public Controller(IModel model)
        {
            this.model = model;
            commands = new Dictionary<string, ICommand>();
            commands.Add("generate", new GenerateMazeCommand(this.model));
            commands.Add("solve", new SolveMazeCommand(this.model));
            commands.Add("start", new StartMazeCommand(this.model));
            commands.Add("list", new ListCommand(this.model));
            commands.Add("join", new JoinCommaned(this.model));
            commands.Add("play", new PlayCommand(this.model));
            commands.Add("close", new CloseCommand(this.model));
        }

        public void SetView(IView view)
        {
            this.view = view;
        }

        public void SetModel(IModel model)
        {
            this.model = model;
        }

        public string ExecuteCommand(string commandLine, TcpClient client)
        {
            string[] arr = commandLine.Split(' ');
            string commandKey = arr[0];
            if (!commands.ContainsKey(commandKey))
                return "Command not found";
            string[] args = arr.Skip(1).ToArray();
            ICommand command = commands[commandKey];
            string s = command.Execute(args, client);
            return s;
        }
    }
}
