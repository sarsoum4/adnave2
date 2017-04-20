using MazeLib;

namespace Server.TheModel
{
    public interface IModel
    {
        Maze GenerateMaze(string name, int rows, int cols);
    }
}