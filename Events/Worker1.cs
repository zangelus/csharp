using Events.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public class Worker1
    {
        //public delegate int WorkPerformed(object sender, WorkPerformedEventArgs e);
        public event EventHandler<WorkPerformedEventArgs> WorkPerformed;

        public void DoWork(int hours, WorkType worktype)
        {
            OnWorkPerformed(hours, worktype);
        }

        protected virtual void OnWorkPerformed(int hours, WorkType worktype)
        {
            if (WorkPerformed != null)
            {
                WorkPerformed(this, new WorkPerformedEventArgs(hours, worktype));
            }
        }
    }
}
