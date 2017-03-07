using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lambdas.Enums;
using System.Threading;

namespace Lambdas
{  
    public class Worker
    {
        public event EventHandler<WorkPerformedEventArgs> WorkPerformed;
        public Worker() { }

        public void DoWork(int hours, WorkType worktype)
        {
            for (int i=1;i<= hours;i++)
            {
                OnWorkPerformed(i, worktype);
                Thread.Sleep(1000);
            }
        }

        protected virtual void OnWorkPerformed(int hours, WorkType worktype)
        {
            if (WorkPerformed != null)
            {
                WorkPerformed(this,new WorkPerformedEventArgs(hours, worktype));
            }
        }
    }

   
}
