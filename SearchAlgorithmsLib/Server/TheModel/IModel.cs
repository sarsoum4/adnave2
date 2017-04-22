using MazeLib;
using SearchAlgorithmsLib;
using System.Collections.Generic;
using System.Net.Sockets;

namespace Server.TheModel
{
    public interface IModel
    {
        GameMaze GenerateMaze(string name, int rows, int cols, int maxPlayers);


        Solution<State<Position>> Solve(string name, string algo);


        List<string> GetGamesList();


        void AddGame(string name, int rows, int columns, TcpClient host);


        GameMaze JoinAGame(string name, TcpClient guest);


        void RemoveGame(string name);


        GameMaze GetMazeGame(string name);



    









    }
}