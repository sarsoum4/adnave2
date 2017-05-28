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
        private Position previousPlayerPosition;
        private string playerPositionStr;

        private bool isConnecting;
        private int port;
        private string ip;

        private IModel model;

        private string json;
        //private Jobject j;



        public SinglePlayerVM(string name, int row, int col, int port, string ip)
        {
            this.model = new Model();
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


        ///get the maze representation
        private void parseMaze(string json)
        {

            Maze maze = MazeLib.Maze.FromJSON(json);
            VM_Cols = maze.Cols;
            VM_Rows = maze.Rows;
            mazeRep = maze.ToString();
            mazeRep = mazeRep.Replace('\n', ' ');
            mazeRep = mazeRep.Replace('\r', ' ');
            string current = "";
            foreach (char c in mazeRep)
            {
                if (c != ' ')
                {
                    current += c;
                }
            }
            VM_MazeRep = current;

            VM_Name = maze.Name;

            startRow = maze.InitialPos.Row;
            startCol = maze.InitialPos.Col;
            endRow = maze.GoalPos.Row;
            endCol = maze.GoalPos.Col;
            VM_PlayerPosition = maze.InitialPos;

        }



        private char CellAtPosition(int i, int j)
        {

            int count = 0;
            foreach (char c in mazeRep)
            {
                if (count == i * VM_Cols + j)
                {
                    return c;
                }
                count++;
            }
            return ' ';
        }


        internal void PlayerMoveDown()
        {
            int newCol = playerPosition.Col;
            int newRow = playerPosition.Row + 1;

            char newPosition = CellAtPosition(newRow, newCol);
            if ((newPosition == '0') || (newCol == VM_EndCol && newRow == VM_EndRow))
            {
                playerPosition.Row++;
                model.movePlayer(newRow, newCol);
                //VM_PlayerPosition = new Position(newRow, newCol);

            }
        }

        internal void PlayerMoveRight()
        {
            int newCol = playerPosition.Col + 1;
            int newRow = playerPosition.Row;

            
            char newPosition = CellAtPosition(newRow, newCol);
            if ((newPosition == '0') || (newCol == VM_EndCol && newRow == VM_EndRow))
            {
                playerPosition.Col++;
                model.movePlayer(newRow, newCol);
                //VM_PlayerPosition = new Position(newRow, newCol);

            }
        }

        internal void PlayerMoveLeft()
        {
            int newCol = playerPosition.Col - 1;
            int newRow = playerPosition.Row;


            char newPosition = CellAtPosition(newRow, newCol);
            if ((newPosition == '0') || (newCol == VM_EndCol && newRow == VM_EndRow))
            {
                playerPosition.Col--;
                model.movePlayer(newRow, newCol);
                //VM_PlayerPosition = new Position(newRow, newCol);

            }
        }

        internal void PlayerMoveUp()
        {
            int newCol = playerPosition.Col;
            int newRow = playerPosition.Row - 1;


            char newPosition = CellAtPosition(newRow, newCol);
            if ((newPosition == '0') || (newCol == VM_EndCol && newRow == VM_EndRow))
            {
                playerPosition.Row--;
                model.movePlayer(newRow, newCol);
                //VM_PlayerPosition = new Position(newRow, newCol);

            }
        }


        public void GenerateGame(string name, int row, int col)
        {
            string s = "generate " + name + " " + row + " " + col;
            model.send(s);
            this.VM_Json = model.Recieve();
            parseMaze(this.VM_Json);
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
            get { return this.playerPosition; }
            set
            {
                playerPosition = value;
                //VM_PlayerPositionStr = playerPosition.ToString();
                NotifyPropertyChanged("VM_PlayerPosition");
            }
        }

        public Position VM_PreviousPlayerPosition
        {
            get { return this.previousPlayerPosition; }
            set
            {
                playerPosition = value;
                //VM_PlayerPositionStr = playerPosition.ToString();
                NotifyPropertyChanged("VM_PreviousPlayerPosition");
            }
        }

        public string VM_PlayerPositionStr
        {
            get { return this.playerPositionStr; }
            set
            {
                playerPositionStr = value;
                NotifyPropertyChanged("VM_PlayerPositionStr");

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

        public bool VM_IsConnecting
        {
            get { return isConnecting; }
            set { isConnecting = value; }
        }


    }
}