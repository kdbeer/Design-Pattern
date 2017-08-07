using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorCore
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcreateComponent c = new ConcreateComponent();
            ConcreateDecoratorA d1 = new ConcreateDecoratorA();
            ConcreateDecoratorB d2 = new ConcreateDecoratorB();

            //Link decorator
            d1.SetComponent(c);
            d2.SetComponent(d1);

            d2.Operation();

            Console.ReadKey();
        }
    }

    abstract class Component
    {
        public abstract void Operation();
    }

    class ConcreateComponent : Component
    {
        public override void Operation()
        {
            Console.WriteLine("ConcreteComponent.Operation()");
        }
    }

    abstract class Decorator : Component
    {
        protected Component component;

        public void SetComponent(Component component )
        {
            this.component = component;
        }

        public override void Operation()
        {
            if (component != null)
                component.Operation();
        }
    }

    class ConcreateDecoratorA : Decorator
    {
        public override void Operation()
        {
            base.Operation();
            Console.WriteLine("ConcreteDecoratorA.Operation()");
        }
    }

    class ConcreateDecoratorB : Decorator
    {
        public override void Operation()
        {
            base.Operation();
            Console.WriteLine("ConcreteDecoratorB.Operation()");
        }

        void AddedBehivior()
        {
        }
    }
}
