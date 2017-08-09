using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterpretRealWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            string roman = "MCMXXVIII";
            Context context = new Context(roman);

            //Build the 'parse' three
            List<Expression> trees = new List<Expression>();

            trees.Add(new ThousandExpression());
            trees.Add(new HundredExpression());
            trees.Add(new TenExpression());
            trees.Add(new OneExpression());

            //Tnterpret
            trees.ForEach(exp =>
            {
                exp.Interpret(context);
            });

            Console.WriteLine("{0} = {1}",
                roman, context.Output);

            // Wait for user
            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'Context' class
    /// </summary>
    class Context
    {
        private string _input;
        private int _output;

        public Context(string input)
        {
            _input = input;
        }

        //Get or set input
        public string Input
        {
            get { return this._input; }
            set { this._input = value; }
        }

        //Get or set input
        public int Output
        {
            get { return this._output; }
            set { this._output = value; }
        }
    }

    /// <summary>
    /// The 'AbstractExpression' class
    /// </summary>
    abstract class Expression
    {
        public void Interpret(Context context)
        {
            if (context.Input.Length == 0)
                return;

            if (context.Input.StartsWith(Nine()))
            {
                context.Output += (9 * Multiplier());
                context.Input = context.Input.Substring(2);
            }
            else if (context.Input.StartsWith(Four()))
            {
                context.Output += (4 * Multiplier());
                context.Input = context.Input.Substring(2);
            }
            else if (context.Input.StartsWith(Five()))
            {
                context.Output += (5 * Multiplier());
                context.Input = context.Input.Substring(1);
            }

            while(context.Input.StartsWith(One()))
            {
                context.Output += (1 * Multiplier());
                context.Input = context.Input.Substring(1);
            }
        }

        public abstract int Multiplier();
        public abstract string One();
        public abstract string Five();
        public abstract string Four();
        public abstract string Nine();
    }

    /// <summary>
    /// The 'TerminalExpression' class
    /// </summary>
    class ThousandExpression : Expression
    {
        public override string Five()
        {
            return " ";
        }

        public override string Four()
        {
            return " ";
        }

        public override int Multiplier()
        {
            return 1000;
        }

        public override string One()
        {
            return "M";
        }

        public override string Nine()
        {
            return " ";
        }
        
    }
    /// <summary>
    /// The 'TerminalExpression' class
    /// </summary>
    class HundredExpression : Expression
    {
        public override string One() { return "C"; }
        public override string Four() { return "CD"; }
        public override string Five() { return "D"; }
        public override string Nine() { return "CM"; }
        public override int Multiplier() { return 100; }
    }
    /// <summary>
    /// The 'TerminalExpression' class
    /// </summary>
    class TenExpression :Expression
    {
        public override string One() { return "X"; }
        public override string Four() { return "XL"; }
        public override string Five() { return "L"; }
        public override string Nine() { return "XC"; }
        public override int Multiplier() { return 10; }
    }
    /// <summary>
    /// The 'TerminalExpression' class
    /// </summary>
    class OneExpression : Expression
    {
        public override string One() { return "I"; }
        public override string Four() { return "IV"; }
        public override string Five() { return "V"; }
        public override string Nine() { return "IX"; }
        public override int Multiplier() { return 1; }
    }
}
