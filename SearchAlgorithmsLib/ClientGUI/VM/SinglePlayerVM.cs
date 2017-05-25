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
        private int startRow;
        private int startCol;
        private int endRow;
        private int endCol;
        private string mazeRep;

        private Maze maze;
        private Position playerPosition;

        private bool isConnecting;
        private int port;
        private string ip;

        private IModel model;

        private string json;
        //private Jobject j;



        public SinglePlayerVM(string name, int row, int col, int port, string ip)
        {
            this.Name = name;
            this.Rows = row;
            this.Cols = col;
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

            Maze maze = MazeLib.Maze.FromJSON(json);
            Cols =  maze.Cols;
            Rows = maze.Rows;
            mazeRep = maze.ToString();
            mazeRep = mazeRep.Replace('\n', ' ');
            mazeRep = mazeRep.Replace('\r', ' ');
            
            Name = maze.Name;

            startRow = maze.InitialPos.Row;
            startCol = maze.InitialPos.Col;
            endRow = maze.GoalPos.Row;
            endCol = maze.GoalPos.Col;
            playerPosition = maze.InitialPos;

    }







        public string Json
        {
            get { return model.Json; }
            set
            {
                json = value;
                model.Json = value;
                
            }
        }



        public void startGame(string name, int row , int col)
        {
            string s = "generate " + name +" "+ row +" "+ col;
            model.send(s);
            this.Json = model.Recieve();
            parseMaze(this.Json);
        }
        
            



        public Maze Maze
        {
            get{return maze;}
            set
            {
                maze = value;
            }
        }

        public Position PlayerPosition
        {
            get{return playerPosition;}
            set{playerPosition = value;}
        }


        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public int Cols
        {
            get
            {
                return cols;
            }

            set
            {
                cols = value;
                NotifyPropertyChanged("Cols");
            }
        }

        public int Rows
        {
            get
            {
                return rows;
            }

            set
            {
                rows = value;
            }
        }

        public int StartRow
        {
            get
            {
                return startRow;
            }

            set
            {
                startRow = value;
            }
        }

        public int StartCol
        {
            get
            {
                return startCol;
            }

            set
            {
                startCol = value;
            }
        }

        public int EndRow
        {
            get
            {
                return endRow;
            }

            set
            {
                endRow = value;
            }
        }

        public int EndCol
        {
            get
            {
                return endCol;
            }

            set
            {
                endCol = value;
            }
        }

        public string MazeRep
        {
            get
            {
                return mazeRep;
            }

            set
            {
                mazeRep = value;
                NotifyPropertyChanged("MazeRep");

            }
        }

        public bool IsConnecting
        {
            get
            {
                return isConnecting;
            }

            set
            {
                isConnecting = value;
            }
        }






    }
}
