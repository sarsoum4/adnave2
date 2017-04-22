
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
using SearchAlgorithmsLib;

namespace Server.TheModel
{
    public class Model : IModel
    {
        //a dictionary with the maze's name as the key, and the maze object
        private Dictionary<string, GameMaze> mazes;
        
        //a dictionary with the maze's name as the key, and its solution.
        private Dictionary<string, Solution<State<Position>>> solvedMaze;

        

        public Model()
        {
 
            this.solvedMaze = new Dictionary<string, Solution<State<Position>>>();
            this.mazes = new Dictionary<string, GameMaze>();
        }




        public GameMaze GenerateMaze(string name, int rows, int cols , int maxPlayers)
        {
            if (mazes.ContainsKey(name))
            {
                throw new ArgumentException("name already taken, re-enter a command");
            }
            MazeGeneratorLib.DFSMazeGenerator generator = new MazeGeneratorLib.DFSMazeGenerator();
            Maze maze = generator.Generate(rows, cols);
            maze.Name = name;
            GameMaze game = new GameMaze(maze, null, maxPlayers);
            mazes.Add(name, game);
            return game;
        }


        public Solution<State<Position>> Solve(string name, string solution) {
            this.solvedMaze.Add(name,solution);
        }
        
        /**
         * add the maze itself to the mazes dictionary.
         */
        public void addMaze(string name, GameMaze maze) {
            this.mazes.Add(name, maze);
        }

        public GameMaze getMaze(string name){
            //return this.mazes.TryGetValue(name);

            GameMaze mazeToReturn;
            if (!mazes.TryGetValue(name, out mazeToReturn)) {
                // there in no maze with that name
                return null;
            }
            return mazeToReturn;
        }





        public Solution<State<Position>> Solve(string name, string algo)
        {
            throw new NotImplementedException();
        }

        public List<string> GetGamesList()
        {
            throw new NotImplementedException();
        }

        public void AddGame(string name, int rows, int columns, TcpClient host)
        {
            throw new NotImplementedException();
        }

        public GameMaze JoinAGame(string name, TcpClient guest)
        {
            throw new NotImplementedException();
        }

        public void RemoveGame(string name)
        {
            throw new NotImplementedException();
        }

        public GameMaze GetMazeGame(string name)
        {
            throw new NotImplementedException();
        }



    }
}
