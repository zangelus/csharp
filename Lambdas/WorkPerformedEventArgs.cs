using System;
using Lambdas.Enums;
namespace Lambdas
{
    public class WorkPerformedEventArgs:EventArgs
    {
        public int hours { get; set; }
        public WorkType worktype { get; set; }
        
        public WorkPerformedEventArgs(int hours, WorkType worktype)
        {
            this.hours = hours;
            this.worktype = worktype;
        }
    }
}
