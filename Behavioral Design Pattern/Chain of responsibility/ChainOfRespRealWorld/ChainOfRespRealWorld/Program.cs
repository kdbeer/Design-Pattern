using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfRespRealWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            //Set up chain of responsibility
            Approver larry = new Director();
            Approver sam = new VicePrisident();
            Approver tammy = new Prisedent();

            larry.SetSuccessor(sam);
            sam.SetSuccessor(tammy);


            // Generate and process purchase requests
            Purchase p = new Purchase(2034, 350, "Assets");
            larry.ProcessRequest(p);

            p = new Purchase(2035, 32590.10, "Project X");
            larry.ProcessRequest(p);

            p = new Purchase(2036, 122100.00, "Project Y");
            larry.ProcessRequest(p);

            //Wait for user key
            Console.ReadKey();
        }
    }

    abstract class Approver
    {
        protected Approver successor;

        public void SetSuccessor(Approver successor)
        {
            this.successor = successor;
        }

        public abstract void ProcessRequest(Purchase purchase);
    }

    class Director : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if(purchase.Amount < 10000.0)
            {
                Console.WriteLine("{0} approved request# {1}",
                    this.GetType().Name, purchase.Number);
            } else if(successor != null)
            {
                successor.ProcessRequest(purchase);
            }
        }
    }

    class VicePrisident : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 25000.0)
            {
                Console.WriteLine("{0} approved request# {1}",
                    this.GetType().Name, purchase.Number);
            }
            else if (successor != null)
            {
                successor.ProcessRequest(purchase);
            }
        }
    }

    class Prisedent : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 100000.0)
            {
                Console.WriteLine("{0} approved request# {1}",
                    this.GetType().Name, purchase.Number);
            }
            else
            {
                Console.WriteLine(
                  "Request# {0} requires an executive meeting!",
                  purchase.Number);
            }
        }
    }



    public class Purchase
    {
        private int _number;
        private double _amount;
        private string _purpose;

        public Purchase(int number, double amount, string purpose)
        {
            _number = number;
            _amount = amount;
            _purpose = purpose;
        }

        public int Number
        {
            get { return this._number; }
            set { this._number = value; }
        }

        public double Amount
        {
            get { return this._amount; }
            set { this._amount = value ; }
        }

        public string Purpose
        {
            get { return this._purpose; }
            set { this._purpose = value; }
        }
    }
}
