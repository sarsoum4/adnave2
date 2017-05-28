using ClientGUI.M;
using MazeLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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
        private Position otherPlayerPosition ;


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

        public MultiplayerVM(string name, int port, string ip)
        {
            this.model = new MultiplayerModel();
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };

            this.VM_Name = name;
            this.port = port;
            this.ip = ip;

            model.connect(ip, port);
        }

        public void startGame(string name, int row, int col)
        {
            string s = "start " + name + " " + row + " " + col;
            model.send(s);

            // Run the receiving task.
            Task recv = new Task(() =>
            {
                this.VM_Json = model.Recieve();

            });
            recv.Start();
            recv.Wait();

            StartParseMaze(this.VM_Json);
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

        ///get the maze representation
        private void StartParseMaze(string json)
        {

            string newjson = json.Substring(31);
            Maze maze = MazeLib.Maze.FromJSON(newjson);
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

        internal void Join(string gameName)
        {
            string s = "join " + gameName;
            model.send(s);
            this.VM_Json = model.Recieve();
            parseMaze(this.VM_Json);
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

        public List<String> VM_GamesList
        {
            get { return model.GamesList; }
            set
            {
                model.GamesList = value;
                NotifyPropertyChanged("VM_GamesList");
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

        public Position VM_OtherPlayerPosition
        {
            get
            {
                return otherPlayerPosition;
            }

            set
            {
                otherPlayerPosition = value;
            }
        }
    }
}
