using System;
using Events.Enums;

namespace Events
{
    //1.1 Create a delegate
    public delegate int WorkPerformedDelegate(int hours, WorkType worktype);
    public delegate int WorkPerformedDelegateV2(object sender, WorkPerformedEventArgs e);
    
    public class Worker
    {   
        //2 Event Definition

        //2.1.1 Use a delegate "pipe" to declare an event. Raw data is passed
        public event WorkPerformedDelegate  WorkPerfomedEvent;  
        //2.1.2 Using a delegate with custom EventArgs to pass data
        public event WorkPerformedDelegateV2 WorkPerformedEventV2;

        //2.2 Using .NET EventHandler. In this case No need to create a Delegate. 
        //2.2.1 Basic usage. 
        public event EventHandler WorkCompletedEvent;
        //2.2.2 Custom EventArgs to pass data     
        public event EventHandler<WorkPerformedEventArgs> WorkPerformedEventV3; //<---Event definition


        public void DoSomeWork(int hours, WorkType worktype)
        {
            //I would like to notify the subscribers when some work has already been done
            for (int i= 1;i<=hours;i++)
            {
                OnWorkPerformed(i, worktype);
                OnWorkPerformedV2(i, worktype);
                OnWorkPerformedV3(i, worktype);
            }
            //Also to notify subscribers when the work has been done
            OnWorkCompleted(this,EventArgs.Empty);
        }

        //3 Methods from where the event will be raise

        //3.1 
        protected virtual void OnWorkPerformed(int hours, WorkType worktype)
        {
            //3.1.1 (option 1) verify if the event is null (means no subscribers attached)
            if (WorkPerfomedEvent != null)
            {
                WorkPerfomedEvent(hours,worktype); //<---Raise the event
            }

            //3.1.2 (option 2) verify cast of the event to the delegate is null
            /*WorkPerformedDelegate del = WorkPerfomedEvent as WorkPerformedDelegate;
            if (del != null)
            {
                del(8,WorkType.Golf);
            }
            */
        }

        //3.2
        protected virtual void OnWorkPerformedV2(int hours, WorkType worktype)
        {
            if (WorkPerformedEventV2 != null)
            {
                WorkPerformedEventV2(this, new WorkPerformedEventArgs(hours,worktype)); //<---Raise the event
            }
        }

        //3.3
        protected virtual void OnWorkPerformedV3(int hours, WorkType worktype)
        {
            if (WorkPerformedEventV3 != null)
            {
                WorkPerformedEventV3(this, new WorkPerformedEventArgs(hours, worktype)); //<---Raise the event
            }
        }

        //3.4
        protected virtual void OnWorkCompleted(object sender, EventArgs e)
        {
            if (WorkCompletedEvent != null)
            {
                WorkCompletedEvent(sender, e);  //<---Raise the event
            }
        }
    }
}
