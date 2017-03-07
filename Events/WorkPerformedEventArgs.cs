using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Events.Enums;
namespace Events
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
