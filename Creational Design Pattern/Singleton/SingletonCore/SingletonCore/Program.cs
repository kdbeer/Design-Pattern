using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Singleton s1 = Singleton.Instance();
            Singleton s2 = Singleton.Instance();

            //Test for same in stance
            if(s1 == s2)
                Console.WriteLine("Object is same instance");

            Console.ReadKey();
        }
    }

    class Singleton
    {
        private static Singleton _instance;

        // Constructor is 'protected'
        protected Singleton()
        {

        }
        
        public static Singleton Instance()
        {
            // Uses lazy initialization.
            // Note: this is not thread safe.
            if (_instance == null)
                _instance = new Singleton();

            return _instance;
        }

    }


}
