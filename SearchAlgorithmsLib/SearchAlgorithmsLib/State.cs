using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medallion.Collections;


namespace SearchAlgorithmsLib
{
    public class State<T> : IComparable
    {

        private T state; // the state represented by a string
        private double cost; // cost to reach this state (set by a setter)
        private State<T> cameFrom; // the state we came from to this state (setter)



        public State<T> CameFrom
        {
            get{return cameFrom;}
            set{cameFrom = value;}
        }

        public double Cost
        {
            get{return cost;}
            set{cost = value;}
        }


        public T currentState
        {
            get
            {
                return state;
            }

            set
            {
                state = value;
            }
        }



        public State(T state) // CTOR
        {
            this.state = state;
            this.Cost = 1;
            this.CameFrom = null;
        }


        public bool Equals(State<T> s) // we override Object's Equals method
        {
            return state.Equals(s.state);
        }

        public int CompareTo(object obj)
        {
            State<T> other = obj as State<T>;
            return this.Cost.CompareTo(other.Cost);

        }

        //public static implicit operator State<T>(PriorityQueue<State<T>> v)
        // {
        //  throw new NotImplementedException();
        //}
    }
}
