using SearchAlgorithmsLib;
using System;
using System.Collections.Generic;
using MazeLib;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Adapter
{
    public class MazeAdapter<T> : ISearchable<Position>
    {
        private MazeLib.Maze maze;


        public MazeAdapter(MazeLib.Maze maze)
        {
            this.maze = maze;
        }

        public List<State<MazeLib.Position>> getAllPossibleStates(State<MazeLib.Position> state)
        {
            List<State<MazeLib.Position>> neighbors = new List<State<MazeLib.Position>>();
            int row = state.currentState.Row;
            int col = state.currentState.Col;

            //left neighbor
            if (col > 0 && col - 1 <= maze.Cols)
            {
                if (maze[row, col - 1] == CellType.Free)
                {
           
                    State<MazeLib.Position> leftNeighbor = new State<MazeLib.Position>(new Position(row, col - 1));
                    
                    if (state.Cost + 1 < leftNeighbor.Cost)
                    {
                       //leftNeighbor.Cost = state.Cost + 1;
                       //leftNeighbor.CameFrom = state;
                    }
                    neighbors.Add(leftNeighbor);

                }
            }



            if (col + 1 < maze.Cols)
            {
                if (maze[row, col + 1] == CellType.Free)
                {
                    State<MazeLib.Position> rightNeighbor = new State<MazeLib.Position>(new Position(row, col + 1));

                    if (state.Cost + 1 < rightNeighbor.Cost)
                    {
                        //rightNeighbor.Cost = state.Cost + 1;
                        //rightNeighbor.CameFrom = state;
                    }
                    neighbors.Add(rightNeighbor);
                }
            }


            // UP
            if ( row + 1 < maze.Rows)
            {
                if (maze[row+1, col ] == CellType.Free)
                {
                    State<MazeLib.Position> upNeighbor = new State<MazeLib.Position>(new Position(row+1, col));

                    if (state.Cost + 1 < upNeighbor.Cost)
                    {
                        //upNeighbor.Cost = state.Cost + 1;
                        //upNeighbor.CameFrom = state;
                    }
                    neighbors.Add(upNeighbor);
                }
            }

            //Down
            if (row - 1 >= 0)
            {
                if (maze[row-1, col] == CellType.Free)
                {
                    State<MazeLib.Position> downNeighbor = new State<MazeLib.Position>(new Position(row-1, col));

                    if (state.Cost + 1 < downNeighbor.Cost)
                    {
                        //downNeighbor.Cost = state.Cost + 1;
                        //downNeighbor.CameFrom = state;
                    }
                    neighbors.Add(downNeighbor);
                }
            }


            return neighbors;
        }


        public State<MazeLib.Position> getGoalState()
        {
            return new State<Position>(maze.GoalPos);

        }

        public State<MazeLib.Position> getInitialState()
        {
            State<Position> s = new State<Position>(maze.InitialPos);
            s.Cost = 0;
            return s;
        }

        public Maze GetMaze()
        {
            return this.maze;
        }
    }
}