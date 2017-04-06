using Medallion.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    public class BestFirstSearch<T> : Searcher<T>
    {



        public override Solution<T> search(ISearchable<T> searchable)
        {

            //State<T> close = new PriorityQueue<State<T>>();
            HashSet<State<T>> closed = new HashSet<State<T>>();

            State<T> initialState =  searchable.getInitialState();
            addToOpenList(initialState);

            while (OpenListSize > 0)
            {
                State<T> n = popOpenList();
                closed.Add(n);
                if (n.Equals(searchable.getGoalState()))
                {
                    return backTrace(n); // private method, back traces through the parents
                }
                List<State<T>> succerssors = new List<State<T>>();
                succerssors = searchable.getAllPossibleStates(n);
                foreach (State<T> s in succerssors)
                {
                    if (!closed.Contains(s) && !openContaines(s))
                    {
                        s.CameFrom = n;
                        s.Cost = n.Cost + 1;
                        addToOpenList(s);
                    }
                    else if (s.Cost > n.Cost + 1)
                    {
                        if (!openContaines(s))
                        {
                            addToOpenList(s);
                        }
                        else
                        {
                            s.Cost = n.Cost + 1;
                        }
                    }
                }
            }
            return backTrace(searchable);
        }





        private Solution<T> backTrace(ISearchable<T> searchable)
        {

            Solution<T> sol = new Solution<T>();
            State<T> goal = searchable.getGoalState();
            State<T> curr = goal;
            while (curr != null)
            {
                sol.addToSolution(curr);
                curr = curr.CameFrom;
            }
            return sol;
        }




        private Solution<T> backTrace(State<T> n)
        {
            throw new NotImplementedException();
        }

        private Solution<T> backTrace()
        {
            throw new NotImplementedException();
        }







    }
}
