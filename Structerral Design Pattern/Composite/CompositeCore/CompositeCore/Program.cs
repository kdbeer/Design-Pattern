using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeCore
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create structure
            Composite root = new Composite("root");
            root.Add(new Leaf("Leaf A") );
            root.Add(new Leaf("Leaf B"));

            Composite comp = new Composite("Composite x");
            comp.Add(new Leaf("Leaf XA"));
            comp.Add(new Leaf("Leaf XB"));

            root.Add(comp);
            root.Add(new Leaf("Leaf C"));

            //Add and remove a leaf
            Leaf leaf = new Leaf("Leaf D");
            root.Add(leaf);
            root.Remove(leaf);

            //Recursively display tree
            root.Display(1);


            //Wait
            Console.ReadKey();


        }
    }

    abstract class Component
    {
        protected string name;

        public Component(string name)
        {
            this.name = name;
        }

        public abstract void Add(Component c);
        public abstract void Remove(Component c);
        public abstract void Display(int depth);        
    }

    class Composite : Component
    {
        private List<Component> _childrens = new List<Component>();

        //Constructer
        public Composite(string name) : base(name) { }

        public override void Add(Component c)
        {
            _childrens.Add(c);
        }
        public override void Remove(Component c)
        {
            _childrens.Remove(c);
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);
            foreach (Component _children in _childrens)
            {
                _children.Display(depth + 2);
            }
        }
    }

    class Leaf : Component
    {
        public Leaf(string name) : base(name)
        {
        }

        public override void Add(Component c)
        {
            Console.WriteLine("Cannot add to a leaf");
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);
        }

        public override void Remove(Component c)
        {
            Console.WriteLine("Cannot remove to a leaf");
        }
    }
}
