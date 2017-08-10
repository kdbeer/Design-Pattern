using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateCore
{
    class Program
    {
        static void Main(string[] args)
        {
            //Setup context in a state
            Context c = new Context(new ConcreateStateA());

            // Issue requests, which toggles state
            c.Request();
            c.Request();
            c.Request();
            c.Request();

            //Wait
            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'State' class
    /// </summary>
    abstract class State
    {
        public abstract void Handle(Context context);
    }
    /// <summary>
    /// The 'ConcreateState'class
    /// </summary>
    class ConcreateStateA : State
    {
        public override void Handle(Context context)
        {
            context.State = new ConcreateStateB();
        }
    }
    /// <summary>
    /// The 'ConcreateState' class
    /// </summary>
    class ConcreateStateB : State
    {
        public override void Handle(Context context)
        {
            context.State = new ConcreateStateA();
        }
    }

    class Context
    {
        private State _state;
        //Constructure
        public Context(State state)
        {
            _state = state;
        }
        //Get or set state
        public State State
        {
            get { return this._state; }
            set {
                _state = value;
                Console.WriteLine("State: " +
                    _state.GetType().Name);
            }
        }
        //Change State
        public void Request()
        {
            _state.Handle(this);
        }
    }
}
