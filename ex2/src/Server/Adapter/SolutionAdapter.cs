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

        private Solution<Position> solution;

        public SolutionAdapter(Solution<Position> solution)
        {
            this.solution = solution;
            

        }


        public override string ToString()
        {
            int size = solution.Path.Count();




            StringBuilder stringSolution = new StringBuilder();
            for (int i = size-1; i > 0; i--)

            {
                State<MazeLib.Position> prev = solution.GetItemAt(i);

                State<MazeLib.Position> curr = solution.GetItemAt(i-1);

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
