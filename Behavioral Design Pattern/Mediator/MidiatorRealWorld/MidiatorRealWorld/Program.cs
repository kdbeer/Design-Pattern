using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiatorRealWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create chatroom
            Chatroom chatroom = new Chatroom();
            // Create participants and register them
            Participant George = new Beatle("George");
            Participant Paul = new Beatle("Paul");
            Participant Ringo = new Beatle("Ringo");
            Participant John = new Beatle("John");
            Participant Yoko = new NonBeatle("Yoko");

            chatroom.Register(George);
            chatroom.Register(Paul);
            chatroom.Register(Ringo);
            chatroom.Register(John);
            chatroom.Register(Yoko);

            //Chating participant
            Yoko.Send("John", "Hi John!");
            Paul.Send("Ringo", "All you need is love");
            Ringo.Send("George", "My sweet Lord");
            Paul.Send("John", "Can't buy me love");
            John.Send("Yoko", "My sweet love");

            //Wait
            Console.ReadLine();
        }
    }

    /// <summary>
    /// The 'mediator' abstract class
    /// </summary>
    abstract class AbstractChatroom
    {
        public abstract void Register(Participant participant);
        public abstract void Send(string from, string to, string message);
    }


    /// <summary>
    /// The 'ConcreateMediator' class
    /// </summary>
    class Chatroom : AbstractChatroom
    {
        private Dictionary<string, Participant> _participants = new Dictionary<string, Participant>();

        public override void Register(Participant participant)
        {
            if(!_participants.ContainsValue(participant))
            {
                _participants[participant.Name] = participant;
            }

            participant.Chatroom = this;
        }

        public override void Send(string from, string to, string message)
        {
            Participant participant = _participants[to];

            if(participant != null)
            {
                participant.Recieve(from, message);
            }
        }
    }

    /// <summary>
    /// The 'AbstractColleague' class
    /// </summary>
    class Participant
    {
        private Chatroom _chatroom;
        private string _name;
        public Participant(string name)
        {
            _name = name;
        }
        //Get Partcipant name
        public string Name
        {
            get { return this._name; }
        }
        // Gets chatroom
        public Chatroom Chatroom
        {
            set { _chatroom = value; }
            get { return _chatroom; }
        }

        public void Send(string to, string message)
        {
            _chatroom.Send(_name, to, message);
        }

        public virtual void Recieve(string from, string message)
        {
            Console.WriteLine("{0} to {1}: '{2}'",
        from, Name, message);
        }
    }

    /// <summary>
    /// The 'ConcreateColleague' class
    /// </summary>
    class Beatle : Participant
    {
        public Beatle(string name) : base(name)
        {
        }

        public override void Recieve(string from, string message)
        {
            Console.Write("To a Beatle: ");
            base.Recieve(from, message);
        }
    }

    /// <summary>
    /// The 'ConcreateColleague' class
    /// </summary>
    class NonBeatle : Participant
    {
        public NonBeatle(string name) : base(name)
        {
        }

        public override void Recieve(string from, string message)
        {
            Console.Write("To a non-Beatle: ");
            base.Recieve(from, message);
        }
    }
}
