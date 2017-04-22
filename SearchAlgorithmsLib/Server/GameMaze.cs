using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class GameMaze
    {


        private MazeLib.Maze maze;
        private int currentPlayers;
        private int maxPlayers;

        private TcpClient host;
        private TcpClient guest;


        public GameMaze(MazeLib.Maze maze, TcpClient host, int maxPlayers)
        {
            this.maze = maze;
            this.host = host;
            this.maxPlayers = maxPlayers;
            this.currentPlayers = 1;
        }


        public TcpClient Host
        {
            get{return this.host;}

        }


        public TcpClient Guest
        {
            get{return this.guest;}
        }

        public MazeLib.Maze Maze
        {
            get{return maze;}
        }



        public int CurrentPlayers
        {
            get { return this.currentPlayers; }
        }


        public string GetName()
        {
            return this.maze.Name;
        }




        public int Join(TcpClient guest)
        {
            if (currentPlayers == 2)
            {
                return 0;
            }
            if (Host == guest )
            {
                return -1;
            }
            this.currentPlayers++;
            this.guest = guest;
            return 1;

        }


        public string ToJSON()
        {
            return this.maze.ToJSON();
        }



    }
}
