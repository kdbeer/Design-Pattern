using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Target target = new Target();
            target.Request();

            Console.ReadKey();
        }
    }

    class Target
    {
        public virtual void Request()
        {
            Console.WriteLine("Called Target Request()");
        }
    }

    class Adapter : Target
    {
        private Adaptee _adaptee = new Adaptee();

        public override void Request()
        {
            _adaptee.SpecificRequest();
        }
    }

    internal class Adaptee
    {
        internal void SpecificRequest()
        {
            Console.WriteLine("Called SpecificRequest()");
        }
    }
}
