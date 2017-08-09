using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomentoRealWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            SaleProspect s = new SaleProspect();
            s.Name = "Noel van Halen";
            s.Phone = "(412) 256-0990";
            s.Budget = 25000.0;

            //Stores Initial state
            PerspectMemory m = new PerspectMemory();
            m.Momento = s.SaveMomento();

            //Continues changing originator
            s.Name = "Leo Welch";
            s.Phone = "(310) 209-7111";
            s.Budget = 1000000.0;

            Console.WriteLine();
            //Restore the save state
            s.RestoreMomento(m.Momento);

            //Wait for user key
            Console.ReadLine();


        }
    }

    /// <summary>
    /// The 'Originator' class
    /// </summary>
    class SaleProspect
    {
        public string _name;
        public string _phone;
        public double _budget;

        //Get or set name
        public string Name
        {
            get { return _name; }
            set {
                this._name = value;
                Console.WriteLine("Name:  " + _name);
            }
        }

        //Get or set phone
        public string Phone
        {
            get { return _phone; }
            set {
                _phone = value;
                Console.WriteLine("Phone:  " + _phone);
            }
        }
        //Get ot set momento
        public double Budget
        {
            get { return this._budget; }
            set {
                this._budget = value;
                Console.WriteLine("Budget:  " + _budget);
            }
        }
        //Stores Momento
        public Momento SaveMomento()
        {
            Console.WriteLine("\nSaving state --\n");
            return new Momento(_name, _phone, _budget);
        }

        public void RestoreMomento(Momento momento)
        {
            Console.WriteLine("\nRestoring state --\n");
            this.Name = momento.Name;
            this.Budget = momento.Budget;
            this.Phone = momento.Phone;
        }
    }

    /// <summary>
    /// The 'Momento' class
    /// </summary>
    public class Momento
    {
        private string _name;
        private string _phone;
        private double _budget;

        public Momento(string name, string phone, double budget)
        {
            _name = name;
            _phone = phone;
            _budget = budget;
        }

        //Property
        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        public string Phone
        {
            get { return this._phone; }
            set { this._phone = value; }
        }

        public double Budget
        {
            get { return this._budget; }
            set { this._budget = value; }
        }
    }

    class PerspectMemory
    {
        private Momento _momento;

        //Property momento
        public Momento Momento
        {
            get { return this._momento; }
            set { this._momento = value; }
        }
    }


}
