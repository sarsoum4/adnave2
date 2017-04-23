
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
using System.Net.Sockets;
using MazeGeneratorLib;

namespace Server.TheModel
{
    public class Model : IModel
    {
        //a dictionary with the maze's name as the key, and its solution.
        private Dictionary<string, Maze> mazes;
        
        //a dictionary with the maze's name as the key, and its solution.
        private Dictionary<string, string> solvedMaze;

        //a set of all the names of games that can be multiplayed
        HashSet<string> games;

        private Dictionary<TcpClient, MultyplayerGame> MazesByClients;


        private Dictionary<string, MultyplayerGame> MultyplayerGames;


        public Model()
        {
            this.mazes = new Dictionary<string, Maze>();
            this.solvedMaze = new Dictionary<string, string>();
            this.MazesByClients = new Dictionary<TcpClient, MultyplayerGame>();
            this.MultyplayerGames = new Dictionary<string, MultyplayerGame>();
            this.games = new HashSet<string>();
            
        }



        public void CloseGame(string name)
        {
            // the maze is in the multplayer option
            if (this.games.Contains(name))
            {
                games.Remove(name);
                TcpClient first;
                TcpClient second = null;

                MultyplayerGame game;
                MultyplayerGames.TryGetValue(name, out game);

                first = game.FirstPlayer;
                if (game.NumberOfPlayers == 2)
                    second = game.SecondPlayer;
                    
                MultyplayerGames.Remove(name);

                MazesByClients.Remove(first);
                if(game.NumberOfPlayers == 2)
                    MazesByClients.Remove(second);
                    
            }
        
        }


        public void AddMultyplayerGame(string name, TcpClient client)
        {
            Maze maze = this.GetMaze(name);
            MultyplayerGame game = new MultyplayerGame(client, name, maze);
            MultyplayerGames.Add(name, game);
            MazesByClients.Add(client, game);
        }

        public void AddSecondPlayer(string name, TcpClient client)
        {
            MultyplayerGame game = null;
            MultyplayerGames.TryGetValue(name, out game);
            game.SecondPlayer = client;
            games.Remove(name);
            MazesByClients.Add(client, game);

        }


        public void play(string move, TcpClient client)
        {
            MultyplayerGame game;
            MazesByClients.TryGetValue(client, out game);
            game.play(move, client);

        }


        public Maze GenerateMaze(string name, int rows, int cols)
        {
            MazeGeneratorLib.IMazeGenerator generator = new DFSMazeGenerator();
            Maze maze = generator.Generate(rows, cols);
            maze.Name = name;
            mazes.Add(name, maze);
            return maze;
        }

        public void AddSolvedMaze(string name, string solution) {
            this.solvedMaze.Add(name,solution);
        }
        
        /**
         * add the maze itself to the mazes dictionary.
         */
        public void AddMaze(string name, Maze maze) {
            this.mazes.Add(name, maze);
        }

        public Maze GetMaze(string name){
            //return this.mazes.TryGetValue(name);

            Maze mazeToReturn;
            if (!mazes.TryGetValue(name, out mazeToReturn)) {
                // there in no maze with that name
                return null;
            }
            return mazeToReturn;
        }

        public bool CheckIfMazeInDictionary(string name)
        {
            if (this.mazes.ContainsKey(name))
                return true;
            return false;
        }

        public void AddGameToList(string name)
        {
            this.games.Add(name);
        }

        public string GamesList()
        {
            return this.games.ToString();
        }

        public bool GameIsFull(string name)
        {
            MultyplayerGame game = null;
            MultyplayerGames.TryGetValue(name, out game);
            int num = game.NumberOfPlayers;

            // if num == 1 then the game is not full
            if (num == 1)
                return false;
            return false;
        }
    }
}
