using System.Net.Sockets;
using MazeLib;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace WebMaze.Models
{
    public interface IModel
    {
        Maze GenerateMaze(string name, int rows, int cols);

        void AddGameToList(string name);

        void AddSolvedMaze(string name, string solution);

        /**
         * add the maze itself to the mazes dictionary.
         */
        void AddMaze(string name, Maze maze);

        Maze GetMaze(string name);

        bool CheckIfMazeInDictionary(string name);
        void CloseGame(string name);
        string GamesList();

        void AddMultyplayerGame(string name, TcpClient client);
        void play(string move, TcpClient client);
        void AddSecondPlayer(string name, TcpClient client);

        bool GameIsFull(string name);
        JObject SolveMaze(string name);

        IEnumerable<Maze> GetAllMazesList();
    }

}
