using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodCore
{
    class Program
    {
        static void Main(string[] args)
        {
            AbstractClass aA = new ConcreateClassA();
            aA.TemplateMethod();

            AbstractClass aB = new ConcreateClassB();
            aB.TemplateMethod();

            //Wait
            Console.ReadKey();
        }
    }
    /// <summary>
    /// The 'Abstract' class
    /// </summary>
    abstract class AbstractClass
    {
        public abstract void PrimitiveOperation1();
        public abstract void PrimitiveOperation2();
        //The 'Template Method' 
        public void TemplateMethod()
        {
            PrimitiveOperation1();
            PrimitiveOperation2();
            Console.WriteLine();
        }
    }
    /// <summary>
    /// The 'ConcreateClass'
    /// </summary>
    class ConcreateClassA : AbstractClass
    {
        public override void PrimitiveOperation1()
        {
            Console.WriteLine("ConcreteClassA.PrimitiveOperation1()");
        }

        public override void PrimitiveOperation2()
        {
            Console.WriteLine("ConcreteClassA.PrimitiveOperation2()");
        }
    }
    /// <summary>
    /// The 'ConcreateClass' 
    /// </summary>
    class ConcreateClassB : AbstractClass
    {
        public override void PrimitiveOperation1()
        {
            Console.WriteLine("ConcreteClassB.PrimitiveOperation1()");
        }

        public override void PrimitiveOperation2()
        {
            Console.WriteLine("ConcreteClassB.PrimitiveOperation2()");
        }
    }
}
