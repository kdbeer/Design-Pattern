using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyweightRealWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            string document = "AAZZZBBZB";
            char[] chars = document.ToCharArray();

            CharacterFactory factory = new CharacterFactory();

            // extrinsic state
            int pointSize = 10;

            // For each character use a flyweight object
            foreach (char c in chars)
            {
                pointSize++;
                Character character = factory.GetCharacter(c);
                character.Display(pointSize);
            }


            Console.ReadKey();
        }
    }

    class CharacterFactory
    {
        private Dictionary<char, Character> _characters = new Dictionary<char, Character>();

        public Character GetCharacter(char key)
        {
            //Use lazys initialize
            Character character = null;

            if(_characters.ContainsKey(key))
            {
                character = _characters[key];
            } else
            {
                switch (key) {
                    case 'A': character = new CharacterA(); break;
                    case 'B': character = new CharacterB(); break;
                    //...
                    case 'Z': character = new CharacterZ(); break;
                }
                _characters.Add(key, character);
            }

            return character;
        }
        
    }

    /// <summary>
    /// The 'Flyweight' abstract class
    /// </summary>
    abstract class Character
    {
        protected char symbol;
        protected int width;
        protected int height;
        protected int ascent;
        protected int descent;
        protected int pointSize;

        public abstract void Display(int pointSize);
    }

    /// <summary>
    /// A 'ConcreteFlyweight' class
    /// </summary>
    class CharacterA : Character
    {
        public CharacterA()
        {
            this.symbol = 'A';
            this.height = 100;
            this.width = 120;
            this.ascent = 70;
            this.descent = 0;
        }

        public override void Display(int pointSize)
        {
            this.pointSize = pointSize;
            Console.WriteLine(this.symbol +
        " (pointsize " + this.pointSize + ")");
        }
    }

    /// <summary>
    /// A 'ConcreteFlyweight' class
    /// </summary>
    class CharacterB : Character
    {
        // Constructor
        public CharacterB()
        {
            this.symbol = 'B';
            this.height = 100;
            this.width = 140;
            this.ascent = 72;
            this.descent = 0;
        }

        public override void Display(int pointSize)
        {
            this.pointSize = pointSize;
            Console.WriteLine(this.symbol +
              " (pointsize " + this.pointSize + ")");
        }

    }

    /// <summary>
    /// A 'ConcreteFlyweight' class
    /// </summary>
    class CharacterZ : Character
    {
        // Constructor
        public CharacterZ()
        {
            this.symbol = 'Z';
            this.height = 100;
            this.width = 100;
            this.ascent = 68;
            this.descent = 0;
        }

        public override void Display(int pointSize)
        {
            this.pointSize = pointSize;
            Console.WriteLine(this.symbol +
              " (pointsize " + this.pointSize + ")");
        }
    }
}
