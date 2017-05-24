using MazeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientGUI.VM
{


    public class SinglePlayerVM
    {
        private string name;
        private int cols;
        private int rows;
        private Maze maze;
        private Position playerPosition;

        private bool isConnecting;
        private int port;
        private string ip;

        private Client client;

        public SinglePlayerVM(string name, int row, int col, int port, string ip)
        {
            this.name = name;
            this.rows = row;
            this.cols = col;
            this.port = port;
            this.ip = ip;

           this.client = new Client(port);
        }

       
        public string startGame(string name, int row , int col)
        {
            return null;
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
