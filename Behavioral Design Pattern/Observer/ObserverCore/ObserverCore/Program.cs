using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverCore
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcreateSubject s = new ConcreateSubject();
            //Attach state to Subject
            s.Attach(new ConcreteObserver(s, "X"));
            s.Attach(new ConcreteObserver(s, "Y"));
            s.Attach(new ConcreteObserver(s, "Z"));

            // Change subject and notify observers
            s.SubjectState = "ABC";
            s.Notify();

            //Wait for user
            Console.ReadKey();
        }
    }
    /// <summary>
    /// The 'Subject' class
    /// </summary>
    abstract class Subject
    {
        private List<Observer> _observers = new List<Observer>();
        public void Attach(Observer observer)
        {
            _observers.Add(observer);
        }

        public void Detach(Observer observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (Observer o in _observers)
            {
                //Chang observe state and notify
                o.Update();
            }
        }
    }
    /// <summary>
    /// The 'ConcreateSubject' class
    /// </summary>
    class ConcreateSubject : Subject
    {
        private string _subjectState;
        // Gets or sets subject state
        public string SubjectState
        {
            get { return _subjectState; }
            set { this._subjectState = value; }
        }
    }

    abstract class Observer
    {
        public abstract void Update();
    }

    class ConcreteObserver : Observer
    {
        private string _name;
        private string _observerState;
        private ConcreateSubject _subject;

        //Constructer
        public ConcreteObserver(ConcreateSubject subject, string name)
        {
            _name = name;
            _subject = subject;
        }
        public override void Update()
        {
            _observerState = _subject.SubjectState;
            Console.WriteLine("Observer {0}'s new state is {1}",
              _name, _observerState);
        }
        //Get or set subject
        public ConcreateSubject concreateSubject
        {
            get { return _subject; }
            set { this._subject = value; }
        }
    }
}
