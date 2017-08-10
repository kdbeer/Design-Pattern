using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyRealWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedList studentRecords = new SortedList();
            studentRecords.Add("Samual");
            studentRecords.Add("Jimmy");
            studentRecords.Add("Sandra");
            studentRecords.Add("Vivek");
            studentRecords.Add("Anna");

            studentRecords.SetSortStrategy(new QuickSort());
            studentRecords.Sort();

            studentRecords.SetSortStrategy(new ShellSort());
            studentRecords.Sort();

            studentRecords.SetSortStrategy(new MergeSort());
            studentRecords.Sort();

            Console.ReadKey();

        }
    }
    /// <summary>
    /// The 'Strategy' class
    /// </summary>
    abstract class SortStrategy
    {
        public abstract void Sort(List<string> list);
    }
    /// <summary>
    /// The 'ConcreateStrategy' class
    /// </summary>
    class QuickSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            //Default quick sort
            list.Sort();
            Console.WriteLine("QuickSorted list ");
        }
    }
    /// <summary>
    /// The 'ConcreateSreategy' class
    /// </summary>
    class ShellSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            //list.ShellSort(); 
            Console.WriteLine("ShellSorted list");
        }
    }
    /// <summary>
    /// The 'ConcreateStrategy' list
    /// </summary>
    class MergeSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            //list.MergeSort();
            Console.WriteLine("MergeSorted list");
        }
    }
    /// <summary>
    /// The 'Context' class
    /// </summary>
    class SortedList
    {
        private List<string> _list = new List<string>();
        private SortStrategy _sortStrategy;

        public void SetSortStrategy(SortStrategy sortStrategy)
        {
            this._sortStrategy = sortStrategy;
        }
        public void Add(string name)
        {
            _list.Add(name);
        }
        public void Sort()
        {
            _sortStrategy.Sort(_list);

            // Iterate over list and display results
            _list.ForEach(name =>
            {
                Console.WriteLine(" " + name);
            });
            Console.WriteLine();
        }
    }
}
