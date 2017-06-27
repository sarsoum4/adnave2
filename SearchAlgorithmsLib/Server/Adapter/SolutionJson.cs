using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Server.Adapter
{
    public class SolutionJson
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

        public string solveToJSON()
        {
            JObject mazeSolutionObj = new JObject();
            mazeSolutionObj["Name"] = this.MazeName;
            mazeSolutionObj["Solution"] = this.Solution;
            mazeSolutionObj["NodesEvaluated"] = this.NodesEvaluated;
            return mazeSolutionObj.ToString();
        }

    }
}
