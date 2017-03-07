using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesEventsLambdas.Delegates
{
    public class DImplementation
    {
        //Function called by a one way delegate
        public static void WorkPerformed1(int hours, WorkType worktype)
        {
            Console.WriteLine($"Work performed 1: {worktype} during:{hours}h");
        }
        public static void WorkPerformed2(int hours, WorkType worktype)
        {
            Console.WriteLine($"Work performed 2: {worktype} during:{hours}h");
        }
        public static void WorkPerformed3(int hours, WorkType worktype)
        {
            Console.WriteLine($"Work performed 3: {worktype} during:{hours}h");
        }

        //Function called by a Two way delegate
        public static int WorkPerfomHandler2way1(int hours, WorkType worktype)
        {
            Console.WriteLine($"Work performed 4: {worktype} during:{hours}h");
            return hours + 1;
        }
        public static int WorkPerfomHandler2way2(int hours, WorkType worktype)
        {
            Console.WriteLine($"Work performed 5: {worktype} during:{hours}h");
            return hours + 2;
        }
        public static int WorkPerfomHandler2way3(int hours, WorkType worktype)
        {
            Console.WriteLine($"Work performed 6: {worktype} during:{hours}h");
            return hours + 3;
        }
    }
}
