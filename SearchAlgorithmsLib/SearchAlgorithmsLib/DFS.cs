using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    public class DFS<T> : Searcher<T>
    {
        HashSet<State<T>> visited = new HashSet<State<T>>();
        Stack<State<T>> s = new Stack<State<T>>();

        public override Solution<T> search(ISearchable<T> searchable)
        {
            State<T> initial = searchable.getInitialState();
            s.Push(initial);

            List<State<T>> succerssors = new List<State<T>>();
            succerssors = searchable.getAllPossibleStates(initial);

            while (!(s.Count == 0))
            {
                State<T> v = s.Pop();
                if (v.Equals(searchable.getGoalState())){
                    return backTrace(searchable); // private method, back traces through the parents
                }
                if (!(visited.Contains(v)))
                {
                    visited.Add(v);
                    succerssors = searchable.getAllPossibleStates(v);
                    foreach (State<T> state in succerssors)
                    {
                        state.CameFrom = v;
                        s.Push(state);
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
    }
}
