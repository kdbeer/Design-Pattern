using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderCore
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create ditector and builder
            Director director = new Director();

            Builder b1 = new ConcreatBuilder1();
            Builder b2 = new ConcreatBuilder2();

            //Construct 2 products
            director.Construct(b1);
            Product p1 = b1.GetResult();
            p1.show();


            director.Construct(b2);
            Product p2 = b2.GetResult();
            p2.show();


            //Wait for user
            Console.ReadKey();


        }
    }

    class Director
    {
        public void Construct(Builder builder)
        {
            builder.BuilderPartA();
            builder.BuilderPartB();
        }
    }

    /// <summary>
    /// The 'Builder' class
    /// </summary>
    abstract class Builder
    {
        public abstract void BuilderPartA();
        public abstract void BuilderPartB();
        public abstract Product GetResult();
    }

    /// <summary>
    /// The 'ConcreateBuilder1' class
    /// </summary>
    class ConcreatBuilder1 : Builder
    {
        private Product _product = new Product();
        public override void BuilderPartA()
        {
            _product.Add("PartA");
        }

        public override void BuilderPartB()
        {
            _product.Add("PartB");
        }

        public override Product GetResult()
        {
            return _product;
        }
    }

    /// <summary>
    /// The 'ConcreatBuilder2' class
    /// </summary>
    class ConcreatBuilder2 : Builder
    {
        private Product _product = new Product();
        public override void BuilderPartA()
        {
            _product.Add("PartX");
        }

        public override void BuilderPartB()
        {
            _product.Add("PartY");
        }

        public override Product GetResult()
        {
            return _product;
        }
    }

    /// <summary>
    /// The 'Product' class
    /// </summary>
    public class Product
    {
        private List<String> parts = new List<string>();
        public void Add(string part)
        {
            parts.Add(part);
        }

        public void show()
        {
            Console.WriteLine("\nProduct Parts-------");
            foreach (string part in parts)
                Console.WriteLine(part);
        }
    }
}
