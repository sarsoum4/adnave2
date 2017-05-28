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


        public MultiplayerVM(string name, int row, int col, int port, string ip)
        {
            this.model = new MultiplayerModel();
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };

            this.VM_Name = name;
            this.VM_Rows = row;
            this.VM_Cols = col;
            this.port = port;
            this.ip = ip;

            model.connect(ip, port);
        }



        public void startGame(string name, int row, int col)
        {
            string s = "generate " + name + " " + row + " " + col;
            //model.send(s);
            model.generateNewMaze(name, row, col);
            //model.start();
        }




        public string VM_Json
        {
            get { return model.Json; }
            set
            {
                json = value;
                model.Json = value;
                NotifyPropertyChanged("VM_Json");
            }
        }


        public Maze VM_Maze
        {
            get { return maze; }
            set
            {
                maze = value;
            }
        }

        public Position VM_PlayerPosition
        {
            get { return playerPosition; }
            set
            {
                playerPosition = value;

            }
        }




        public string VM_Name
        {
            get { return name; }
            set
            {
                name = value;
                NotifyPropertyChanged("VM_Name");
            }
        }

        public int VM_Cols
        {
            get { return cols; }
            set
            {
                cols = value;
                NotifyPropertyChanged("VM_Cols");
            }
        }



        public int VM_Rows
        {
            get { return rows; }
            set
            {
                rows = value;
                NotifyPropertyChanged("VM_Rows");
            }
        }

        public int VM_StartRow
        {
            get { return startRow; }
            set
            {
                startRow = value;
                NotifyPropertyChanged("VM_StartRow");
            }
        }



        public int VM_StartCol
        {
            get { return startCol; }
            set
            {
                startCol = value;
                NotifyPropertyChanged("VM_StartCol");
            }
        }

        public int VM_EndRow
        {
            get { return endRow; }
            set
            {
                endRow = value;
                NotifyPropertyChanged("VM_EndRow");
            }
        }


        public int VM_EndCol
        {
            get { return endCol; }
            set
            {
                endCol = value;
                NotifyPropertyChanged("VM_EndCol");
            }
        }

        public string VM_MazeRep
        {
            get { return mazeRep; }
            set
            {
                mazeRep = value;
                //  NotifyPropertyChanged("VM_MazeRep");
            }
        }



        public bool IsConnecting
        {
            get { return isConnecting; }
            set { isConnecting = value; }
        }

    }
}
