using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeCore
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcreatePrototype1 p1 = new ConcreatePrototype1("I");
            ConcreatePrototype1 c1 = (ConcreatePrototype1)p1.Clone();
            Console.WriteLine("Cloned: {0}", c1.Id);

            ConcreatePrototype2 p2 = new ConcreatePrototype2("II");
            ConcreatePrototype2 c2 = (ConcreatePrototype2)p2.Clone();
            Console.WriteLine("Cloned: {0}", c2.Id);

            // Wait for user
            Console.ReadKey();
        }
    }

    abstract class Prototype
    {
        private string _id;

        //Constructer
        public Prototype(string id)
        {
            _id = id;
        }

        //Get id
        public string Id
        {
            get { return _id; }
        }

        public abstract Prototype Clone();
    }


    class ConcreatePrototype1 : Prototype
    {
        public ConcreatePrototype1(string id) : base(id)
        {

        }

        //return the shallow copy
        public override Prototype Clone()
        {
            return (Prototype)this.MemberwiseClone();
        }
    }

    class ConcreatePrototype2 : Prototype
    {
        public ConcreatePrototype2(string id) : base(id)
        {
        }

        public override Prototype Clone()
        {
            return (Prototype)this.MemberwiseClone();
        }
    }



}
