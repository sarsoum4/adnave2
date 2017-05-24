using ClientGUI.M;
using MazeLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientGUI.VM
{
    public class MultiplayerVM : ViewModel
    {
        private string name;
        private int cols;
        private int rows;
        private Maze maze;
        private Position playerPosition;

        private bool isConnecting;
        private int port;
        private string ip;

        private IModel model;

        private string json;


        public MultiplayerVM(string name, int row, int col, int port, string ip)
        {
            this.name = name;
            this.rows = row;
            this.cols = col;
            this.port = port;
            this.ip = ip;
            this.model = new Model();
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged(e.PropertyName);
            };

            model.connect(ip, port);
        }


        public string Json
        {
            get { return model.Json; }
            set
            {
                model.Json = value;
                NotifyPropertyChanged("Json");
            }
        }

        public void startGame(string name, int row, int col)
        {
            string s = "generate " + name + " " + row + " " + col;
            //model.send(s);
            model.generateNewMaze(name, row, col);
            //model.start();
        }

        public Maze Maze
        {
            get { return maze; }
            set { maze = value; }
        }

        public Position PlayerPosition
        {
            get { return playerPosition; }
            set { playerPosition = value; }
        }

        public bool IsConnecting
        {
            get { return isConnecting; }
            set { isConnecting = value; }
        }

    }
}
