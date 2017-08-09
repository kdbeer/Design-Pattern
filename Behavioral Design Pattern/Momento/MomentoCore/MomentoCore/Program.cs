using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomentoCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Originator o = new Originator();
            o.State = "On";

            // Store internal state
            CareTaker c = new CareTaker();
            c.Momento = o.CreateMomento();

            //Continued changing originator
            o.State = "Off";

            //Restore saved state
            o.SetMomento(c.Momento);

            //wait
            Console.ReadKey();
        }
    }

    class Originator
    {
        private string _state;
        //Property
        public string State
        {
            get { return _state; }
            set
            {
                _state = value;
                Console.WriteLine("State = " + _state);
            }
        }

        //Create momento
        public Momento CreateMomento()
        {
            return new Momento(_state);
        }

        //Restore original state
        public void SetMomento(Momento momento)
        {
            Console.WriteLine("Restoring state...");
            State = momento.State;
        }



    }
    class Momento
    {
        private string _state;

        //Constructure
        public Momento(string state)
        {
            _state = state;
        }

        //Get ot set state
        public string State
        {
            get { return this._state; }
            set { this._state = value; }
        }
    }

    class CareTaker
    {
        private Momento _momento;

        //Get or Set momento
        public Momento Momento
        {
            get { return this._momento; }
            set { this._momento = value; }
        }
    }
}
