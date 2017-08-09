using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorRealWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Collection collection = new Collection();
            collection[0] = new Item("Item 0");
            collection[1] = new Item("Item 1");
            collection[2] = new Item("Item 2");
            collection[3] = new Item("Item 3");
            collection[4] = new Item("Item 4");
            collection[5] = new Item("Item 5");
            collection[6] = new Item("Item 6");
            collection[7] = new Item("Item 7");

            //Create iterator
            Iterator iterator = collection.CreateIterator();

            Console.WriteLine(iterator.CurrentItem);

            // Skip every other item
            iterator.Step = 2;

            Console.WriteLine("Iterating over collection:");
            for (Item item = iterator.First();
                !iterator.IsDone; item = iterator.Next())
            {
                Console.WriteLine(item.Name);
            }
            //Wait for user
            Console.ReadKey();



        }
    }

    /// <summary>
    /// A collection item
    /// </summary>
    class Item
    {
        private string _name;

        public Item(string name)
        {
            _name = name;
        }

        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }
    }

    /// <summary>
    /// The 'aggregate' interface
    /// </summary>
    interface IAbstractCollection
    {
        Iterator CreateIterator();
    }

    class Collection : IAbstractCollection
    {
        private ArrayList lists = new ArrayList();

        public Iterator CreateIterator()
        {
            return new Iterator(this);
        }

        //Get item count
        public int Count
        {
            get { return this.lists.Count; }
        }

        //Indexer
        public object this[int index]
        {
            get { return lists[index]; }
            set { lists.Add(value); }
        }
    }

    /// <summary>
    /// The 'Iterator' interface
    /// </summary>
    interface IAbstractIterator
    {
        Item First();
        Item Next();
        bool IsDone { get; }
        Item CurrentItem { get; }
    }

    /// <summary>
    /// The 'Iterator' class
    /// </summary>
    class Iterator : IAbstractIterator
    {
        private Collection _collection;
        private int _current = 0;
        private int _step = 1;

        public int Step
        {
            get { return _step; }
            set { _step = value; }
        }

        public Iterator(Collection collection)
        {
            this._collection = collection;
        }

        public bool IsDone
        {
            get { return _current >= _collection.Count; }
        }

        public Item CurrentItem
        {
            get { return _collection[_current] as Item; }
        }
            
        public Item First()
        {
            _current = 0;
            return _collection[_current] as Item;
        }

        public Item Next()
        {
            _current += _step;
            if (!IsDone)
            {
                return _collection[_current] as Item;
            }
            else
                return null;
        }
    }
}
