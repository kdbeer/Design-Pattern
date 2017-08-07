using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeRealWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            //Customer
            Customers customers = new Customers("Chicaco");

            // Set ConcreteImplementor
            customers.Data = new CustomerData();

            // Exercise the bridge
            customers.Show();
            customers.Next();
            customers.Show();
            customers.Next();
            customers.Show();
            customers.Next();
            customers.Add("Henry Velasquez");
                        
            customers.ShowAll();

            Console.ReadKey();
        }
    }

    class CustomerBase
    {
        private DataObject _dataObject;
        protected string group;

        public CustomerBase(string group)
        {
            this.group = group;
        }

        //Property
        public DataObject Data
        {
            get { return this._dataObject; }
            set { this._dataObject = value; }
        }

        public virtual void Next()
        {
            _dataObject.NextRecord();
        }

        public virtual void Prior()
        {
            _dataObject.PriorRecord();
        }

        public virtual void Add(string customer)
        {
            _dataObject.AddRecord(customer);
        }

        public virtual void Delete(string customer)
        {
            _dataObject.DeleteRecord(customer);
        }

        public virtual void Show()
        {
            _dataObject.ShowRecord();
        }

        public virtual void ShowAll()
        {
            Console.WriteLine("Customer Group: " + group);
            _dataObject.ShowAllRecord();
        }
    }

    class Customers : CustomerBase
    {
        public Customers(string group) : base(group)
        {
        }

        public override void ShowAll()
        {            
            // Add separator lines
            Console.WriteLine();
            Console.WriteLine("------------------------");
            base.ShowAll();
            Console.WriteLine("------------------------");
        }
    }



    abstract class DataObject
    {
        public abstract void AddRecord(string customer);
        public abstract void DeleteRecord(string customer);
        public abstract void NextRecord();
        public abstract void PriorRecord();
        public abstract void ShowAllRecord();
        public abstract void ShowRecord();
    }

    class CustomerData : DataObject
    {
        private List<string> _customers = new List<string>();
        private int _current = 0;

        public CustomerData()
        {
            // Loaded from a database 
            _customers.Add("Jim Jones");
            _customers.Add("Samual Jackson");
            _customers.Add("Allen Good");
            _customers.Add("Ann Stills");
            _customers.Add("Lisa Giolani");
        }


        public override void NextRecord()
        {
            if (_current <= _customers.Count - 1)
                _current++;
        }
        public override void AddRecord(string customer)
        {
            _customers.Add(customer);
        }

        public override void DeleteRecord(string customer)
        {
            _customers.Remove(customer);
        }

        public override void PriorRecord()
        {
            if (_current > 0)
                _current--;
        }


        public override void ShowRecord()
        {
            Console.WriteLine(_customers[_current]);
        }
        public override void ShowAllRecord()
        {
            foreach (string customer in _customers)
            {
                Console.WriteLine(" " + customer);
            }
        }
    }


}
