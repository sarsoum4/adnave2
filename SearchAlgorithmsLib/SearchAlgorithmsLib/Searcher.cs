using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medallion.Collections;


namespace SearchAlgorithmsLib
{
    public abstract class Searcher<T> : ISearcher<T>
    {

        private PriorityQueue<State<T>> openList;
        private int evaluatedNodes;


        public Searcher()
        {
            openList = new PriorityQueue<State<T>>();
            evaluatedNodes = 0;
        }

        protected State<T> popOpenList()
        {
            evaluatedNodes++;
            return openList.Dequeue(); // poll()
        }

        protected void addEvaluatedNode()
        {
            evaluatedNodes++;
        }

        protected void addToOpenList(State<T> s)
        {
            this.openList.Enqueue(s);
        }

        protected bool openContaines(State<T> s)
        {
            foreach (State<T> element in openList)
            {
                if(element.Equals(s))
                return true;
            }
            return false;
        }


        // a property of openList
        public int OpenListSize
        { // it is a read-only property :)
            get { return openList.Count; }
        }

        // ISearcher’s methods:
        public int getNumberOfNodesEvaluated()
        {
            return evaluatedNodes;
        }


        public abstract Solution<T> search(ISearchable<T> searchable);



    }




}

