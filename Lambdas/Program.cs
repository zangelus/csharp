using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lambdas.Enums;

namespace Lambdas
{
    public delegate int BusinessRules(int x, int y);

    class Program
    {
        static void Main(string[] args)
        {
            var worker = new Worker();
            //Example 1 Anonymous Methods, or methods embeded inline. Almost like a lambda
            worker.WorkPerformed += delegate (object sender, WorkPerformedEventArgs e)
            {
                Console.WriteLine($"<--Anonymous Method-->Hours worked {e.hours} doing {e.worktype}");
            };
            //Example 2 This is the lambda and does exactly the same as the anonymous method above
            worker.WorkPerformed += (s, e) => Console.WriteLine($"<--Lambda-->Hours worked {e.hours} doing {e.worktype}");

            //Example 3 like an event using Delegate inference
            worker.WorkPerformed += Worker_WorkPerformed;

            worker.DoWork(7, WorkType.Golf);

            //Example 4. Passing delegate to functions to execute different functionalities
            //Highly decouple methods.
            BusinessRules AddFunc   = (x, y) => x + y;
            BusinessRules MultFunct = (x, y) => x * y;
            var toProcess = new ProcessData();
            var ret1 = toProcess.Process(3, 4, AddFunc);
            var ret2 = toProcess.Process(3, 4, MultFunct);
            Console.WriteLine($"The returned value for AddFunc   is {ret1}");
            Console.WriteLine($"The returned value for MultFunct is {ret2}");

            //Example 5. Using Actions<> .NET delegates
            //Action<> does not return any parameter
            Action<int, int> AddFunc2 = (x, y) => Console.WriteLine($"<--Action<> .NET delegate-->{x+ y}");
            Action<int, int> MultFunc2 = (x, y) => Console.WriteLine($"<--Action<> .NET delegate-->{x * y}");
            toProcess.Process2(5, 6, AddFunc2);
            toProcess.Process2(5, 6, MultFunc2);

            //Example 6, Using Func<> .NET delegates
            //Func<> can return a parameter
            Func <int, int, int> AddFunc3 = (x, y) => x + y;
            Func<int, int, int> MultFunc3 = (x, y) => x * y;
            var ret3 = toProcess.Process3(1, 2, AddFunc3);
            var ret4 = toProcess.Process3(1, 2, MultFunc3);
            Console.WriteLine($"The returned value for AddFunc3   is {ret3}");
            Console.WriteLine($"The returned value for MultFunct3 is {ret4}");


            //Example 7, Using lambdas to querry object

            var Phoenix = new List<Customer> 
            {
                new Customer { Id=1, City="Phoenix", FirstName="John", LastName="Dow"},
                new Customer { Id=500, City="Phoenix", FirstName="Jane", LastName="Dow"},
                new Customer { Id=3, City="Seatle", FirstName="Suki", LastName="{Pizzoro"},
                new Customer { Id=4, City="NewYork", FirstName="Michelle", LastName="Smith"},
            };

            var phoenixCust = Phoenix
                .Where((c) => c.City == "Phoenix" && c.Id<500)
                .OrderBy((c) => c.FirstName);

            foreach (var customer in phoenixCust)
            {
                Console.WriteLine(customer.FirstName);
            }


            Console.ReadKey();
        }

        private static void Worker_WorkPerformed(object sender, WorkPerformedEventArgs e)
        {
            Console.WriteLine($"<--Delegate Inference-->Hours worked {e.hours} doing {e.worktype}");
        }
    }
}
