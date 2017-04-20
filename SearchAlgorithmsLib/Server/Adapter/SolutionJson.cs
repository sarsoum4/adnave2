using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Adapter
{
    class SolutionJson
    {

        public string MazeName;
        public string Solution;
        public int NodesEvaluated;

        public SolutionJson(string mazeName, string solution, int nodesEvaluated)
        {
            this.MazeName = mazeName;
            this.Solution = solution;
            this.NodesEvaluated = nodesEvaluated;
        }


    }
}
