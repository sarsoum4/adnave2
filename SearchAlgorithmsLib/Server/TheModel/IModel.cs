using MazeLib;

namespace Server.TheModel
{
    public interface IModel
    {
        Maze GenerateMaze(string name, int rows, int cols);


        void addSolvedMaze(string name, string solution);

        /**
         * add the maze itself to the mazes dictionary.
         */
        void addMaze(string name, Maze maze);

        Maze getMaze(string name);
    }

}
