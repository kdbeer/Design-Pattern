using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Reciever reciever = new Reciever();
            Command command = new ConcreateCommand(reciever);
            Invoker invoker = new Invoker();

            invoker.SetCommand(command);
            invoker.ExecuteCommand();

            //Wait for user
            Console.ReadKey();
        }
    }


    /// <summary>
    /// The 'Command' abstract class
    /// </summary>
    abstract class Command
    {
        protected Reciever reciever;

        public Command(Reciever reciever)
        {
            this.reciever = reciever;
        }

        public abstract void Execute();
    }

    /// <summary>
    /// The 'ConcreateCommmand' class
    /// </summary>
    class ConcreateCommand : Command
    {
        public ConcreateCommand(Reciever reciever) : base(reciever)
        {
        }

        public override void Execute()
        {
            reciever.Action();
        }
    }

    /// <summary>
    /// The 'reciever' class
    /// </summary>
    class Reciever
    {
        public void Action()
        {
            Console.WriteLine("Called Receiver.Action()");
        }
    }

    /// <summary>
    /// The 'Invoker' class
    /// </summary>
    class Invoker
    {
        private Command command;

        public void SetCommand(Command c)
        {
            this.command = c;
        }

        public void ExecuteCommand()
        {
            command.Execute();
        }
    }
}
