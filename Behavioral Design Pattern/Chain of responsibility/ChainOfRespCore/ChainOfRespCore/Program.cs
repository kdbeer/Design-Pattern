using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfRespCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Handle handle1 = new ConcreateHandle1();
            Handle handle2 = new ConcreateHandle2();
            Handle handle3 = new ConcreateHandle3();

            handle1.SetSuccessor(handle2);
            handle2.SetSuccessor(handle3);

            // Generate and process request
            int[] requests = { 2, 5, 14, 22, 18, 3, 27, 20 };

            foreach (int request in requests)
            {
                handle1.HandleRequest(request);
            }

            //Wait for user
            Console.ReadKey();
        }
    }

    abstract class Handle
    {
        protected Handle successor;

        public void SetSuccessor(Handle successor)
        {
            this.successor = successor;
        }

        public abstract void HandleRequest(int request);
    }

    class ConcreateHandle1 : Handle
    {
        public override void HandleRequest(int request)
        {
            if (request > 0 && request < 10)
            {
                Console.WriteLine("{0} handled request {1}",
                    this.GetType().Name, request);
            }
            else if (successor != null)
            {
                successor.HandleRequest(request);
            }
        }
    }

    class ConcreateHandle2 : Handle
    {
        public override void HandleRequest(int request)
        {
            if(request >= 10 && request > 20)
            {
                Console.WriteLine("{0} handled request {1}",
                    this.GetType().Name, request);
            } else if(successor != null)
            {
                successor.HandleRequest(request);
            }
        }
    }

    class ConcreateHandle3 : Handle
    {
        public override void HandleRequest(int request)
        {
            if(request >= 20 && request < 30 )
            {
                Console.WriteLine("{0} handled request {1}",
                    this.GetType().Name, request);
            } else
            {
                if(successor != null)
                {
                    successor.HandleRequest(request);
                }
            }
        }
    }
}
