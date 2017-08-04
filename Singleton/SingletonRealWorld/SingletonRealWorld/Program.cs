using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonRealWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            LoadBalancer b1 = LoadBalancer.GetLoadBalance();
            LoadBalancer b2 = LoadBalancer.GetLoadBalance();
            LoadBalancer b3 = LoadBalancer.GetLoadBalance();
            LoadBalancer b4 = LoadBalancer.GetLoadBalance();

            //same instance ?
            if (b1 == b2 && b2 == b3 && b3 == b4)
            {
                Console.WriteLine("Same instance\n");
            }


            // Load balance 15 server requests
            LoadBalancer balancer = LoadBalancer.GetLoadBalance();
            for (int i = 0; i < 15; i++)
            {
                string server = balancer.Server;
                Console.WriteLine("Dispatch Request to: " + server);
            }

            //Wait for key
            Console.ReadKey();

        }
    }

    class LoadBalancer
    {
        private static LoadBalancer _instance;
        private List<string> _servers = new List<string>();
        private Random _random = new Random();

        // Lock synchronization object
        private static object synclock = new object();

        // Constructor (protected)
        protected LoadBalancer()
        {
            // List of available servers
            _servers.Add("ServerI");
            _servers.Add("ServerII");
            _servers.Add("ServerIII");
            _servers.Add("ServerIV");
            _servers.Add("ServerV");
        }

        public static LoadBalancer GetLoadBalance()
        {
            // Support multithreaded applications through
            // 'Double checked locking' pattern which (once
            // the instance exists) avoids locking each
            // time the method is invoked
            if(_instance == null)
            {
                lock(synclock)
                {
                    if (_instance == null)
                        _instance = new LoadBalancer();
                }
            }

            return _instance;
        }

        public string Server
        {
            get {
                int r = _random.Next(_servers.Count);
                return _servers[r].ToString();
            }
        }
    }

}
