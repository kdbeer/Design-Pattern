using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateRealWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            //Open a new account
            Account account = new Account("Kridsada Duangmala");

            //Apply finantial transaction
            account.Deposit(500.0);
            account.Deposit(300.0);
            account.Deposit(550.0);
            account.PayInterest();
            account.Withdraw(2000.00);
            account.Withdraw(1100.00);

            //Wait
            Console.ReadLine();



        }
    }
    /// <summary>
    /// The 'State' abstract class
    /// </summary>
    abstract class State
    {
        protected Account account;
        protected double balance;

        protected double interest;
        protected double lowerLimit;
        protected double upperLimit;

        //Property
        public Account Account
        {
            get { return this.account; }
            set { this.account = value; }
        }

        public double Balance
        {
            get { return this.balance; }
            set { this.balance = value; }
        }

        public abstract void Deposite(double amount);
        public abstract void Withdraw(double amount);
        public abstract void PayInterest();
    }

    class RedState : State
    {
        private double _serviceFee;

        //Constructor
        public RedState(State state)
        {
            this.balance = state.Balance;
            this.account = state.Account;
            Initialize();
        }
        private void Initialize()
        {
            // Should come from a datasource
            interest = 0.0;
            lowerLimit = -100.0;
            upperLimit = 0.0;
            _serviceFee = 15.00;
        }
        public override void Deposite(double amount)
        {
            balance += amount;
            StateChangeCheck();
        }

        public override void PayInterest()
        {
            //No interest is paid
        }

        public override void Withdraw(double amount)
        {
            amount = amount - _serviceFee;
            Console.WriteLine("No funds available for withdrawal!");
        }

        private void StateChangeCheck()
        {
            if(balance > upperLimit)
            {
                account.State = new SilverState(this);
            }
        }
    }

    class SilverState : State
    {
        public SilverState(State state) : this(state.Balance, state.Account)
        {
        }

        public SilverState(double balance, Account account)
        {
            this.balance = balance;
            this.account = account;
        }

        public override void Deposite(double amount)
        {
            balance += amount;
            StateChangeCheck();
        }

        private void StateChangeCheck()
        {
            if (balance < lowerLimit)
                account.State = new RedState(this);
            else if (balance > upperLimit)
                account.State = new GoldState(this);
        }

        public override void PayInterest()
        {
            balance += interest;
        }

        public override void Withdraw(double amount)
        {
            balance -= amount;
            StateChangeCheck();
        }
    }

    internal class GoldState : State
    {
        // Overloaded constructors
        public GoldState(State state) : this(state.Balance, state.Account)
        {
        }

        public GoldState(double balance, Account account)
        {
            this.balance = balance;
            this.account = account;
            Initialize();
        }

        private void Initialize()
        {
            // Should come from a database
            interest = 0.05;
            lowerLimit = 1000.0;
            upperLimit = 10000000.0;
        }

        public override void Deposite(double amount)
        {
            balance += amount;
            StateChangeCheck();
        }


        public override void PayInterest()
        {
            balance += interest * balance;
            StateChangeCheck();
        }

        public override void Withdraw(double amount)
        {
            balance -= amount;
            StateChangeCheck();
        }
        private void StateChangeCheck()
        {
            if (balance < 0.0)
            {
                account.State = new RedState(this);
            }
            else if (balance < lowerLimit)
            {
                account.State = new SilverState(this);
            }
        }
    }

    class Account
    {
        private State _state;
        private string _owner;
        //Constructor
        public Account(string owner)
        {
            this._owner = owner;
            this._state = new SilverState(0.0, this);
        }

        //Properties
        public double Balance
        {
            get { return _state.Balance; }
        }

        public State State
        {
            get { return _state; }
            set { _state = value; }
        }

        public void Deposit(double amount)
        {
            _state.Deposite(amount);
            Console.WriteLine("Deposited {0:C} --- ", amount);
            Console.WriteLine(" Balance = {0:C}", this.Balance);
            Console.WriteLine(" Status = {0}",
              this.State.GetType().Name);
            Console.WriteLine();
        }
        public void Withdraw(double amount)
        {
            _state.Withdraw(amount);
            Console.WriteLine("Withdrew {0:C} --- ", amount);
            Console.WriteLine(" Balance = {0:C}", this.Balance);
            Console.WriteLine(" Status = {0}\n",
              this.State.GetType().Name);
        }
        public void PayInterest()
        {
            _state.PayInterest();
            Console.WriteLine("Interest Paid --- ");
            Console.WriteLine(" Balance = {0:C}", this.Balance);
            Console.WriteLine(" Status = {0}\n",
              this.State.GetType().Name);
        }

    }
}
