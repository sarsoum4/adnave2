using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Controler;
using MazeLib;
using MazeGeneratorLib;
using Newtonsoft.Json.Linq;
using System.ComponentModel;

namespace ClientGUI.M
{
    class Model : IModel
    {
        private int row;
        private int col;
        private string name;
        private string mazeRepresentation;
        private string json;
        private string startRep;
        private string endRep;
        private int startRow;
        private int startCol;
        private int endRow;
        private int endCol;
        private string currentCommand;
        private MvvmClient client;

        public event PropertyChangedEventHandler PropertyChanged;

        public Model()
        {
            this.client = new MvvmClient();
        }

        public string mazeName
        {
            get { return name; }
            set { this.name = value; }
        }

        int IModel.startRow
        {
            get { return this.startRow; }
            set { this.startRow = value; }
        }

        int IModel.startCol
        {
            get { return this.startCol; }
            set { this.startCol = value; }
        }

        int IModel.endRow
        {
            get { return this.endRow; }
            set { this.endRow = value; }
        }

        int IModel.endCol
        {
            get { return this.endCol; }
            set { this.endCol = value; }
        }

        public int rows
        {
            get { return this.rows; }
            set { this.rows = value; }
        }

        public int cols
        {
            get { return this.cols; }
            set { this.cols = value; }
        }


        public void getCommandFromServer(string command)
        {
            this.currentCommand = command;
        }

        public String commandToSend()
        {
            return this.currentCommand;
        }

        ///get the maze representation, the
        public void parseMaze()
        {
            MazeGeneratorLib.IMazeGenerator generator = new DFSMazeGenerator();
            Maze maze = generator.Generate(5, 5);
            this.json = maze.ToJSON();

            //use the FromJson method. then this.maze.row is the rows etc
            //this.maze = Maze.FromJSON(jsonFormatStr);

            JObject ob = JObject.Parse(this.json);
            this.mazeRepresentation = ob.GetValue("Maze").ToString();
            //get the start row
            this.startRep = ob.SelectToken("Start.Row").ToString();
            this.startRow = Int32.Parse(this.startRep);
            //get the start col
            this.startRep = ob.SelectToken("Start.Col").ToString();
            this.startCol = Int32.Parse(this.startRep);
            //get the end row
            this.endRep = ob.GetValue("End.Row").ToString();
            this.endRow = Int32.Parse(this.endRep);
            //get the end col
            this.endRep = ob.GetValue("End.Row").ToString();
            this.endCol = Int32.Parse(this.endRep);


        }

        public void connect(string ip, int port)
        {
            throw new NotImplementedException();
        }

        public void disconnect()
        {
            throw new NotImplementedException();
        }

        public void start()
        {
            throw new NotImplementedException();
        }

        public void generateNewMazeMaze(string name, int rows, int cols)
        {
            this.currentCommand = "generate " + name + row.ToString() + " " + col.ToString();
            //Server.Controler.Controller 
        }

        public void getGamesList()
        {
            this.currentCommand = "list";
        }

        public void movePlayer()
        {
            throw new NotImplementedException();
        }
    }
}