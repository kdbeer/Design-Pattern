using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorCore
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcreteAggregate aggregate = new ConcreteAggregate();
            aggregate[0] = "Item A";
            aggregate[1] = "Item B";
            aggregate[2] = "Item C";
            aggregate[3] = "Item D";

            // Create Iterator and provide aggregate
            Iterator i = aggregate.CreateIterator();

            Console.WriteLine("Iterating over collection:");
            object item = i.First();
            while(item != null)
            {
                Console.WriteLine(item);
                item = i.Next();
            }

            //Wait
            Console.ReadKey();

        }
    }

    /// <summary>
    /// The 'Aggregate' class
    /// </summary>
    abstract class Aggregate
    {
        public abstract Iterator CreateIterator();
    }

    /// <summary>
    /// The 'Iterator' abstract class
    /// </summary>
    abstract class Iterator
    {
        public abstract object First();
        public abstract object Next();
        public abstract bool IsDone();
        public abstract object CurrentItem();
    }

    /// <summary>
    /// 
    /// </summary>
    class ConcreteAggregate : Aggregate
    {
        ArrayList _items = new ArrayList();
        public override Iterator CreateIterator()
        {
            return new ConcreateIterator(this);
        }

        //Get item count
        public int Count
        {
            get { return this._items.Count; }
        }

        //Indexer
        public object this[int index]
        {
            get { return this._items[index]; }
            set { _items.Insert(index, value); }
        }
    }

    internal class ConcreateIterator : Iterator
    {
        private ConcreteAggregate _aggregate;
        int _current = 0;

        public ConcreateIterator(ConcreteAggregate concreteAggregate)
        {
            this._aggregate = concreteAggregate;
        }
        // Gets current iteration item
        public override object CurrentItem()
        {
            return _aggregate[_current];
        }
        // Gets first iteration item
        public override object First()
        {
            return _aggregate[0];
        }

        public override bool IsDone()
        {
            return _current > _aggregate.Count;
        }

        public override object Next()
        {
            object ret = null;
            if(_current < _aggregate.Count - 1)
            {
                ret = _aggregate[++_current];
            }
            return ret;
        }
    }
}
