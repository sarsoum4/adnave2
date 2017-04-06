using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    class DFS<T> : Searcher<T>
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
                if (!(visited.Contains(v)))
                {
                    visited.Add(v);
                    foreach (State<T> state in succerssors)
                    {
                        s.Push(state);
                    }
                }
            }
        }
    }
}
