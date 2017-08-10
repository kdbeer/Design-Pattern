using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context;

            // Three contexts following different strategies
            context = new Context(new ConcreateStrategyA());
            context.ContextInterface();

            context = new Context(new ConcreateStrategyB());
            context.ContextInterface();

            context = new Context(new ConcreateStrategyC());
            context.ContextInterface();

            //Wait
            Console.ReadKey();
        }
    }
    /// <summary>
    /// The 'Stratrgy' class
    /// </summary>
    abstract class Strategy
    {
        public abstract void AlgorithmInterface();
    }
    /// <summary>
    /// The 'ConcreateStrategy' class
    /// </summary>
    class ConcreateStrategyA : Strategy
    {
        public override void AlgorithmInterface()
        {
            Console.WriteLine(
                "Called ConcreteStrategyA.AlgorithmInterface()");
        }
    }
    /// <summary>
    /// The 'ConcreateStrategy' class
    /// </summary>
    class ConcreateStrategyB : Strategy
    {
        public override void AlgorithmInterface()
        {
            Console.WriteLine(
                "Called ConcreteStrategyB.AlgorithmInterface()");
        }
    }
    /// <summary>
    /// The 'ConcreteStrategy' class
    /// </summary>
    class ConcreateStrategyC : Strategy
    {
        public override void AlgorithmInterface()
        {
            Console.WriteLine(
                "Called ConcreteStrategyC.AlgorithmInterface()");
        }
    }

    class Context
    {
        private Strategy _strategy;
        //Constructor
        public Context(Strategy strategy)
        {
            _strategy = strategy;
        }
        public void ContextInterface()
        {
            _strategy.AlgorithmInterface();
        }
    }
}
