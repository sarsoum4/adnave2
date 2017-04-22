using SearchAlgorithmsLib;
using MazeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Adapter
{
    class SolutionAdapter
    {

        private Solution<State<Position>> solution;

        public SolutionAdapter(Solution<State<Position>> solution)
        {
            this.solution = solution;

        }


        public override string ToString()
        {
            StringBuilder stringSolution = new StringBuilder();
            for (int i = 1; i < solution.Size(); i++)

            {
                State<MazeLib.Position> prev = solution.GetItemAt(i - 1);

                State<MazeLib.Position> curr = solution.GetItemAt(i);

                if (curr.currentState.Col > prev.currentState.Col)
                {
                    stringSolution.Append((int)MazeLib.Direction.Right);
                }
                if (curr.currentState.Col < prev.currentState.Col)
                {
                    stringSolution.Append((int)MazeLib.Direction.Left);
                }
                if (curr.currentState.Row > prev.currentState.Row)
                {
                    stringSolution.Append((int)MazeLib.Direction.Down);
                }
                if (curr.currentState.Row < prev.currentState.Row)
                {
                    stringSolution.Append((int)MazeLib.Direction.Up);
                }

            }
            return stringSolution.ToString();

        }



    }
}
