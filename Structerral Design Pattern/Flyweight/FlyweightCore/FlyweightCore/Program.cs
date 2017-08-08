using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyweightCore
{
    class Program
    {
        static void Main(string[] args)
        {
            int extrinsicstate = 22;
            FlyweightFactory factory = new FlyweightFactory();

            //Work with flyweight instance
            Flyweight fx = factory.GetFlyweight("X");
            fx.Operation(--extrinsicstate);

            Flyweight fy = factory.GetFlyweight("Y");
            fy.Operation(--extrinsicstate);

            Flyweight fz = factory.GetFlyweight("Z");
            fz.Operation(--extrinsicstate);

            Console.ReadKey();
        }
    }

    class FlyweightFactory
    {
        private Hashtable flyweights = new Hashtable();

        //Construct
        public FlyweightFactory()
        {
            flyweights.Add("X", new ConcreateFlyWeight());
            flyweights.Add("Y", new ConcreateFlyWeight());
            flyweights.Add("Z", new ConcreateFlyWeight());
        }

        public Flyweight GetFlyweight(string key)
        {
            return ((Flyweight)flyweights[key]);
        }
    }

    abstract class Flyweight
    {
        public abstract void Operation(int extrinsicstate);
    }

    class ConcreateFlyWeight : Flyweight
    {
        public override void Operation(int extrinsicstate)
        {
            Console.WriteLine("ConcreteFlyweight: " + extrinsicstate);
        }
    }

    class UnsharedConcreteFlyweight : Flyweight
    {
        public override void Operation(int extrinsicstate)
        {
            Console.WriteLine("UnsharedConcreteFlyweight: " +
    extrinsicstate);
        }
    }

}
