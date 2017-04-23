using Medallion.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeLib;




namespace SearchAlgorithmsLib
{
    public class Solution<T>
    {

        private List<State<T>> path;

        public List<State<T>> Path
        {
            get { return path; }
            set { path = value; }
        }


        public Solution()
        {
            this.path = new List<State<T>>();
        }


        public void addToSolution(State<T> node)
        {
            this.path.Add(node);
            Console.WriteLine(path.Count());
        }



        public string toString()
        {
            string returnPath = "";
            int i;
            int len = Path.Count - 1;
            for (i = len; i >= 0; i--)
            {
                returnPath += this.path[i].ToString() + "\n";
            }
            return returnPath;
        }

        public State<T> GetItemAt(int v)
        {
            return path[v];
        }
    }
}