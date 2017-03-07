using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Events.Enums;

namespace Events
{
    class Program
    {
        static void Main(string[] args)
        {
            RunExample1();
            RunExample2();
            Console.ReadKey();
        }

        private static void RunExample1()
        {
            var worker = new Worker();
            worker.WorkPerfomedEvent     += Worker_WorkPerfomedEvent;                       //<<- Using delegate inference
            worker.WorkPerformedEventV2  += Worker_WorkPerformedEventV2;                    //<<- Using delegate inference
            worker.WorkPerformedEventV3  += Worker_WorkPerformedEventV3;                    //<<- Using delegate inference
            worker.WorkCompletedEvent    += Worker_WorkCompletedEvent;                      //<<- Using delegate inference
            worker.WorkCompletedEvent    += new EventHandler(Worker_WorkCompletedEvent);    //<<- Handler not using delegate inference. The Event have to be created. 
            worker.DoSomeWork(10, WorkType.GenerateReports);    
        }

        private static int Worker_WorkPerfomedEvent(int hours, WorkType worktype)
        {
            Console.WriteLine($"Work {worktype} has been performed during {hours}h");
            return 1;
        }   
        private static int Worker_WorkPerformedEventV2(object sender, WorkPerformedEventArgs e)
        {
            Console.WriteLine($"Work {(WorkType)e.worktype} has been performed during {e.hours}h");
            return 1;
        }
        private static void Worker_WorkPerformedEventV3(object sender, WorkPerformedEventArgs e)
        {
            Console.WriteLine($"Work {e.worktype} has been performed during {e.hours}h");
        }
        private static void Worker_WorkCompletedEvent(object sender, EventArgs e)
        {
            Console.WriteLine($"Work {e.ToString()} has been performed during {e.ToString()}h");
        }

        private static void RunExample2()
        {
            var worker = new Worker1();
            worker.WorkPerformed += new EventHandler<WorkPerformedEventArgs>(Worker_WorkPerformed);
            worker.DoWork(100, WorkType.Golf);

        }
        private static void Worker_WorkPerformed(object sender, WorkPerformedEventArgs e)
        {
            Console.WriteLine($"Work {e.worktype} has been performed during {e.hours}h");
        }
    }
}
