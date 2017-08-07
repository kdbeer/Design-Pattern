using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Abstraction ab = new RefinedAbstraction();

            //Set implementation all code
            ab.Implementor = new ConcreateImplementorA();
            ab.Operation();

            ab.Implementor = new ConcreateImplementorB();
            ab.Operation();

            // Wait for key
            Console.ReadKey();
        }
    }

    class Abstraction
    {
        protected Implementor implementor;

        public Implementor Implementor
        {
            set { this.implementor = value; }
        }

        public virtual void Operation()
        {
            implementor.Opetation();
        }
    }

    class RefinedAbstraction : Abstraction
    {
        public override void Operation()
        {
            implementor.Opetation();
        }
    }

    class ConcreateImplementorA : Implementor
    {
        public override void Opetation()
        {
            Console.WriteLine("ConcreteImplementorA Operation");
        }
    }

    class ConcreateImplementorB : Implementor
    {
        public override void Opetation()
        {
            Console.WriteLine("ConcreteImplementorB Operation");
        }
    }

    abstract class Implementor
    {
        public abstract void Opetation();
    }
}
