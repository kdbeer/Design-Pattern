using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF_realworld
{
    class Program
    {
        static void Main(string[] args)
        {
            ContinentFactory africa = new AfricaFactory();
            AnimalWorld world = new AnimalWorld(africa);
            world.RunFoodChain();
            Console.WriteLine();

            ContinentFactory america = new AmericaFactory();
            world = new AnimalWorld(america);
            world.RunFoodChain();

            Console.ReadKey();
        }
    }

    abstract class ContinentFactory
    {
        public abstract Herbivore CreateHerbivore();
        public abstract Carnivore CreateCarnivore();
    }

    /// <summary>
    /// The 'Habivor'class  
    /// </summary>
    abstract class Herbivore
    {

    }

    /// <summary>
    /// The 'Carvinor' class
    /// </summary>
    abstract class Carnivore
    {
        public abstract void Eat(Herbivore h);
    }

    class AfricaFactory : ContinentFactory
    {
        public override Herbivore CreateHerbivore()
        {
            return new Wildebeest();
        }
        public override Carnivore CreateCarnivore()
        {
            return new Lion();
        }

    }


    class Wildebeest : Herbivore
    {
    }
    class Lion : Carnivore
    {
        public override void Eat(Herbivore h)
        {
            // Eat Wildebeest
            Console.WriteLine(this.GetType().Name +
              " eats " + h.GetType().Name);
        }
    }

    class AmericaFactory : ContinentFactory { 
        public override Herbivore CreateHerbivore()
        {
            return new Bison();
        }

        public override Carnivore CreateCarnivore()
        {
            return new Wolf();
        }

    }

    class Wolf : Carnivore
    {
        public override void Eat(Herbivore h)
        {
            // Eat bison
            Console.WriteLine(this.GetType().Name +
              " eats " + h.GetType().Name);
        }
    }

    class Bison : Herbivore
    {

    }

    class AnimalWorld
    {
        private Herbivore _herbivore;
        private Carnivore _carnivore;

        public AnimalWorld(ContinentFactory continent)
        {
            _herbivore = continent.CreateHerbivore();
            _carnivore = continent.CreateCarnivore();
        }
        public void RunFoodChain()
        {
            _carnivore.Eat(_herbivore);
        }
    }
}
