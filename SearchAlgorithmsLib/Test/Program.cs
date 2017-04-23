using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SearchAlgorithmsLib;


class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("THE START !!");
       
        ISearcher<int> ser = new BestFirstSearch<int>();

        Dictionary<State<int>, List<State<int>>> Adj = new Dictionary<State<int>, List<State<int>>>();
        State<int> one = new State<int>(1);
        State<int> two = new State<int>(2);
        State<int> three = new State<int>(3);
        State<int> four = new State<int>(4);
        State<int> five = new State<int>(5);
        State<int> six = new State<int>(6);
        State<int> seven = new State<int>(7);

        Adj[one] = new List<State<int>> { two, three };
        Adj[two] = new List<State<int>> { four, five };
        Adj[three] = new List<State<int>> { two , seven};
        Adj[four] = new List<State<int>>();
        Adj[five] = new List<State<int>> ();
        Adj[six] = new List<State<int>> { seven };
        Adj[seven] = new List<State<int>> { three };

        TestSearchable<int> test1 = new TestSearchable<int>(one, seven, Adj);
        Solution<int> sol = ser.search(test1);
    
        printSol(sol);
        Console.ReadLine();
    }


    static void printSol<T>(Solution<T> s)
    {
        for (int i = 0; i < s.Path.Count; i++)
        {
            Console.WriteLine(s.Path[i].currentState.ToString() );
        }
        Console.WriteLine("");
    }
}

