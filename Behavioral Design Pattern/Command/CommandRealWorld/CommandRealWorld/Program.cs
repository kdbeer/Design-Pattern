using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandRealWorld
{
    class Program
    {
        /// <summary>
        /// The 'Client' class
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Create user and let her compute
            User user = new User();

            // User presses calculator buttons
            user.Compute('+', 100);
            user.Compute('-', 50);
            user.Compute('*', 10);
            user.Compute('/', 2);

            //Undo
            user.Undo(4);

            //Redo
            user.Redo(3);


            //Wait for user key
            Console.ReadKey();
        }
    }

    abstract class Command
    {
        public abstract void Execute();
        public abstract void UnExecute();
    }

    /// <summary>
    /// The 'ConcreateCommand' class
    /// </summary>
    class CulculatorCommand : Command
    {
        private char _operator;
        private int operand;
        private Culculator culculator;

        public CulculatorCommand(Culculator culculator, char @operator, int operand)
        {
            _operator = @operator;
            this.operand = operand;
            this.culculator = culculator;
        }

        //Get Operator
        public char Operator {
            get { return this._operator; }
        }

        //Get Operand
        public int Operand
        {
            get { return this.operand; }
        }

        public override void Execute()
        {
            culculator.Operation(_operator, operand);
        }

        public override void UnExecute()
        {
            this.culculator.Operation(Undo(_operator), operand);
        }

        private char Undo(char @operator)
        {
            switch(@operator) {
                case '+': return '-';
                case '-': return '+';
                case '*': return '/';
                case '/': return '*';
                default: throw new ArgumentException("@operator");
            }
        }
    }

    /// <summary>
    /// The 'Reciever' class
    /// </summary>
    class Culculator
    {
        private int _curr = 0;
        public void Operation(char @operator, int operand)
        {
            switch (@operator)
            {
                case '+': _curr += operand; break;
                case '-': _curr -= operand; break;
                case '*': _curr *= operand; break;
                case '/': _curr /= operand; break;
            }

            Console.WriteLine(
                "Current value = {0,3} (following {1} {2})",
                _curr, @operator, operand);
        }
    }

    class User
    {
        private Culculator _calculator = new Culculator();
        private List<Command> commands = new List<Command>();
        private int _current = 0;

        public void Redo(int levels)
        {
            Console.WriteLine("\n---- Redo {0} levels ", levels);
            // Perform redo operations
            for (int i = 0; i < levels; i++)
            {
                if(_current <= commands.Count - 1)
                {
                    Command command = commands[_current++];
                    command.Execute();
                }
            }
        }

        public void Undo(int levels)
        {
            Console.WriteLine("\n---- Undo {0} levels ", levels);
            // Perform undo operations
            for (int i = 0; i < levels; i++)
            {
                if(_current > 0)
                {
                    Command command = commands[--_current];
                    command.UnExecute();
                }
            }
        }

        public void Compute(char @operator, int operand)
        {
            // Create command operation and execute it
            Command command = new CulculatorCommand(
                _calculator, @operator, operand);
            command.Execute();

            //Add command to undo list
            commands.Add(command);
            _current++;
        }
    }
}
