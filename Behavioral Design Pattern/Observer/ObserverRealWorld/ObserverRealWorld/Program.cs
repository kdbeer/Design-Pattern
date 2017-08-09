using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverRealWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create IBM stock and attach investors
            IBM ibm = new IBM("IBM", 120.00);
            ibm.Attach(new Investor("Sorros"));
            ibm.Attach(new Investor("Berkshire"));

            // Fluctuating prices will notify investors
            ibm.Price = 120.10;
            ibm.Price = 121.00;
            ibm.Price = 120.50;
            ibm.Price = 120.75;

            //Wait for user
            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'Subject' class
    /// </summary>
    abstract class Stock
    {
        private string _symbol;
        private double _price;
        private List<IInvestor> _investors = new List<IInvestor>();
        //Constructure
        public Stock(string symbol, double price)
        {
            _symbol = symbol;
            _price = price;
        }
        public void Attach(IInvestor investor)
        {
            _investors.Add(investor);
        }
        public void Detach(IInvestor investor)
        {
            _investors.Remove(investor);
        }

        //Get or set the price
        public double Price
        {
            get { return this._price; }
            set {
                if (_price != value)
                {
                    _price = value;
                    Notify();
                }
            }
        }
        public void Notify()
        {
            foreach (IInvestor investor in _investors)
            {
                investor.Update(this);
            }
            Console.WriteLine("");
        }

        //Get the symbol
        public string Symbol
        {
            get { return _symbol; }
        }
    }

    /// <summary>
    /// The 'ConcreateSubject' class
    /// </summary>
    class IBM : Stock
    {
        public IBM(string symbol, double price) : base(symbol, price)
        {
        }
    }

    /// <summary>
    /// The 'Observer' interface
    /// </summary>
    interface IInvestor
    {
        void Update(Stock stock);
    }
    /// <summary>
    /// The 'ConcreateObserver' class
    /// </summary>
    class Investor : IInvestor
    {
        private string _name;
        private Stock _stock;
        public Investor(string name)
        {
            _name = name;
        }
        public void Update(Stock stock)
        {
            Console.WriteLine("Notified {0} of {1}'s " +
                "change to {2:C}", _name, stock.Symbol, stock.Price);
        }

        public Stock Stock
        {
            get { return _stock; }
            set { this._stock = value; }
        }
    }
}
