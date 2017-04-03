using Medallion.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    class BestFirstSearch<T>
    {

        State<T> open = new PriorityQueue<State<T>>();
        State<T> close = new PriorityQueue<State<T>>();
    }
}
