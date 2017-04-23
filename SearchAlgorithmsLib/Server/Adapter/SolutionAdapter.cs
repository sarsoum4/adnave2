using SearchAlgorithmsLib;
using MazeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Adapter
{
    class SolutionAdapter<T>
    {

        private Solution<Position> solution;

        public SolutionAdapter(Solution<Position> solution)
        {
            this.solution = solution;
            

        }


        public override string ToString()
        {
            int size = solution.toString().Length;

            StringBuilder stringSolution = new StringBuilder();
            for (int i = 1; i < size; i++)

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
