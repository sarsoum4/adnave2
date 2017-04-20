using SearchAlgorithmsLib;
using System;
using System.Collections.Generic;
using MazeLib;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Adapter
{
    class MazeAdapter<T> : ISearchable<MazeLib.Position>
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
            if (col >= 0 && col-1 < maze.Cols) {
                if (maze[row, col - 1] == CellType.Free)
                {
                    State<MazeLib.Position> leftNeighbor = new State<MazeLib.Position>(new Position(row, col - 1));   
                        
                    if (state.Cost + 1 < leftNeighbor.Cost)
                    {
                        leftNeighbor.Cost = state.Cost + 1;
                        leftNeighbor.CameFrom = state;
                    }
                    neighbors.Add(leftNeighbor);
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
    }
}
