using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadeRealWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            MortGage mortGage = new MortGage();

            // Evaluate mortgage eligibility for customer
            Customer customer = new Customer("Ann Mckinsey");
            bool eligible = mortGage.IsEligible(customer, 125000);
            Console.WriteLine("\n" + customer.Name + 
                " Has been " + (eligible ? "Approved" : "Rejected"));

            Console.ReadKey();
        }
    }

    class Bank
    {
        public bool HasSufficientSavings(Customer c, int amount)
        {
            Console.WriteLine("Check bank for " + c.Name);
            return true;
        }
    }

    class Credit
    {
        public bool HaveGoodCredit(Customer c)
        {
            Console.WriteLine("Check credit for " + c.Name);
            return true;
        }
    }

    class Loan
    {
        public bool HasNoBadLoans(Customer c)
        {
            Console.WriteLine("Check loans for " + c.Name);
            return true;
        }
    }

    public class Customer
    {
        private string _name;

        public Customer(string name)
        {
            _name = name;
        }

        public string Name {
            get { return this._name;  }
            set { this.Name = value; }
        }
    }

    /// <summary>
    /// The 'Facade' class
    /// </summary>
    class MortGage
    {
        private Bank _bank = new Bank();
        private Loan _loan = new Loan();
        private Credit _credit = new Credit();

        public bool IsEligible(Customer c, int amount)
        {
            Console.WriteLine("{0} applies for {1:C} loan\n", c.Name, amount);

            bool eligible = true;

            // Check creditworthyness of applicant
            if (!_bank.HasSufficientSavings(c, amount))
            {
                eligible = false;
            }
            else if (!_loan.HasNoBadLoans(c))
            {
                eligible = false;
            }
            else if (!_credit.HaveGoodCredit(c))
            {
                eligible = false;
            }

            return eligible;
        }
    }
}
