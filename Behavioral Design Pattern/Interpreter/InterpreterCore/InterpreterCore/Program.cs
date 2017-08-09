using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterpreterCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();

            //Usually tree
            ArrayList lists = new ArrayList();

            //Popular 'abstract systax tree'
            lists.Add(new TerminalExpression());
            lists.Add(new NonterminalExpression());
            lists.Add(new TerminalExpression());
            lists.Add(new TerminalExpression());

            //Interpret
            foreach (AbstractExpression exp in lists)
            {
                exp.Interpret(context);
            }

            //wait for user key
            Console.ReadKey();


        }
    }

    /// <summary>
    /// The 'Context' class
    /// </summary>
    class Context
    {

    }

    /// <summary>
    /// The 'AbstractExpression' class
    /// </summary>
    abstract class AbstractExpression
    {
        public abstract void Interpret(Context context);
    }

    /// <summary>
    /// The 'TherminalExpression' class
    /// </summary>
    class TerminalExpression : AbstractExpression
    {
        public override void Interpret(Context context)
        {
            Console.WriteLine("Called Terminal.Interpret()");
        }
    }

    class NonterminalExpression : AbstractExpression
    {
        public override void Interpret(Context context)
        {
            Console.WriteLine("Called Nonterminal.Interpret()");
        }
    }

}
