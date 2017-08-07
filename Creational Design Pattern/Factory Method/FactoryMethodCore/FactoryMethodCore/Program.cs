using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Creator[] creators = new Creator[2];

            creators[0] = new ConcreateCreatorA();
            creators[1] = new ConcreateCreatorB();

            //Iterate over creators and create products
            foreach(Creator creator in creators)
            {
                Product product = creator.FactoryMethod();
                Console.WriteLine("Created {0}", product.GetType().Name);
            }

            //Wait for user key
            Console.ReadKey();


        }
    }
    /// <summary>
    /// The 'Product' class
    /// </summary>
    abstract class Product
    {

    }

    /// <summary>
    /// The 'ConcreateProductA' class
    /// </summary>
    class ConcreateProductA : Product
    {

    }

    /// <summary>
    /// The  'ConcreateProduct' class
    /// </summary>
    class ConcreateProductB : Product
    {

    }

    abstract class Creator
    {
        public abstract Product FactoryMethod();
    }

    class ConcreateCreatorA : Creator
    {
        public override Product FactoryMethod()
        {
            return new ConcreateProductA();
        }
    }

    class ConcreateCreatorB : Creator
    {
        public override Product FactoryMethod()
        {
            return new ConcreateProductB();
        }
    }
}
