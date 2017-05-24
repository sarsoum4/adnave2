using ClientGUI.M;
using MazeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;

namespace ClientGUI.VM
{


    public class SinglePlayerVM : ViewModel
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




        public SinglePlayerVM(string name, int row, int col, int port, string ip)
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



        ///get the maze representation
        private void parseMaze(string json)
        {
            //char[] detlimiter = { '\\' };
            string[] words = json.Split('\\');

                 
            

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



        public void startGame(string name, int row , int col)
        {
            string s = "generate " + name +" "+ row +" "+ col;
            model.send(s);
            this.Json = model.Recieve();
            parseMaze(json);
        }
        
            



        public Maze Maze
        {
            get{return maze;}
            set{maze = value;}
        }

        public Position PlayerPosition
        {
            get{return playerPosition;}
            set{playerPosition = value;}
        }

        public bool IsConnecting
        {
            get{return isConnecting;}
            set{isConnecting = value;}
        }



    }
}
