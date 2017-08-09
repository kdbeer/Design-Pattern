using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorCore
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcreateMediator m = new ConcreateMediator();

            ConcreateColleague1 c1 = new ConcreateColleague1(m);
            ConcreateColleague2 c2 = new ConcreateColleague2(m);

            m.Colleague1 = c1;
            m.Colleague2 = c2;

            c1.Send("How are you ?");
            c2.Send("Find thank you");

            //Wait
            Console.ReadKey();
        }
    }

    abstract class Mediator
    {
        public abstract void Send(string message, Colleague colleague);
    }
    class ConcreateMediator : Mediator
    {
        private ConcreateColleague1 colleague1;
        private ConcreateColleague2 colleague2;

        public ConcreateColleague1 Colleague1
        {
            get { return this.colleague1; }
            set { this.colleague1 = value; }
        }

        public ConcreateColleague2 Colleague2
        {
            get { return this.colleague2; }
            set { this.colleague2 = value; }
        }

        public override void Send(string message, Colleague colleague)
        {
            if (colleague == colleague1)
                colleague2.Notify(message);
            else
                colleague1.Notify(message);
        }
    }
    class ConcreateColleague1 : Colleague
    {
        public ConcreateColleague1(Mediator mediator) : base(mediator)
        {
        }

        public void Send(string message)
        {
            mediator.Send(message, this);
        }

        public void Notify(string message)
        {
            Console.WriteLine("Colleague1 gets message: "
        + message);
        }
    }

    class ConcreateColleague2 : Colleague
    {
        public ConcreateColleague2(Mediator mediator) : base(mediator)
        {
        }

        public void Send(string message)
        {
            mediator.Send(message, this);
        }

        public void Notify(string message)
        {
            Console.WriteLine("Colleague2 gets message: "
        + message);
        } 
    }


    abstract class Colleague
    {
        protected Mediator mediator;
        public Colleague(Mediator mediator)
        {
            this.mediator = mediator;
        }
    }




}
