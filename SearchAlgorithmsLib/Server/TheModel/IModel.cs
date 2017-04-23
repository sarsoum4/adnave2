using MazeLib;

namespace Server.TheModel
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

        string GamesList();
    }

}
