
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeLib;

namespace Server.TheModel
{
    public class Model : IModel
    {
        //a dictionary with the maze's name as the key, and its solution.
        private Dictionary<string, Maze> mazes;
        
        //a dictionary with the maze's name as the key, and its solution.
        private Dictionary<string, string> solvedMaze;

        public Model()
        {

        }

        public Maze GenerateMaze(string name, int rows, int cols)
        {
            throw new NotImplementedException();
        }

        public void addSolvedMaze(string name, string solution) {
            this.solvedMaze.Add(name,solution);
        }
        
        /**
         * add the maze itself to the mazes dictionary.
         */
        public void addMaze(string name, Maze maze) {
            this.mazes.Add(name, maze);
        }

        public Maze getMaze(string name){
            //return this.mazes.TryGetValue(name);

            Maze mazeToReturn;
            if (!mazes.TryGetValue(name, out mazeToReturn)) {
                // there in no maze with that name
                return null;
            }
            return mazeToReturn;
        }
    }
}
