using MazeLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server.TheModel
{
    public class MultyplayerGame
    {
        private Maze maze;
        private TcpClient firstPlayer ;
        private TcpClient secondPlayer;
        private string name;
        private int numberOfPlayers;
 




        public TcpClient FirstPlayer
        {
            get
            {
                return firstPlayer;
            }

            set
            {
                firstPlayer = value;
            }
        }

        public TcpClient SecondPlayer
        {
            get
            {
                return secondPlayer;
            }

            set
            {
                secondPlayer = value;
                numberOfPlayers++;
                SendMessageToPlayer();
            }
        }





        public void play(string move, TcpClient client)
        {
            TcpClient player = null;
            if (client == FirstPlayer)
                player = secondPlayer;
            else
                player = firstPlayer;

            NetworkStream stream = player.GetStream();
            BinaryReader reader = new BinaryReader(stream);
            BinaryWriter writer = new BinaryWriter(stream);
            {
                writer.Write(move);
            }
        }


        private void SendMessageToPlayer()
        {
            string str = maze.ToJSON();
            NetworkStream stream = firstPlayer.GetStream();
            BinaryReader reader = new BinaryReader(stream);
            BinaryWriter writer = new BinaryWriter(stream);
            {
                writer.Write(str);
            }
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

        public int NumberOfPlayers
        {
            get
            {
                return numberOfPlayers;
            }
        }

        public MultyplayerGame(TcpClient firstPlayer, string name, Maze maze)
        {
            this.maze = maze;
            this.FirstPlayer = firstPlayer;
            this.SecondPlayer = null;
            this.Name = name;
            this.numberOfPlayers = 1;

        }


    }
}
