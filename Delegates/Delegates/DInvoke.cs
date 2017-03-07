using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesEventsLambdas.Delegates
{
    public class DInvoke
    {
        public DInvoke()
        {
            #region Intantiante/Create the pipes or delegates
            WorkPerfomHandler del1 = new WorkPerfomHandler(DImplementation.WorkPerformed1);
            WorkPerfomHandler del2 = new WorkPerfomHandler(DImplementation.WorkPerformed2);
            WorkPerfomHandler del3 = new WorkPerfomHandler(DImplementation.WorkPerformed3);

            WorkPerfomHandler2way del4 = new WorkPerfomHandler2way(DImplementation.WorkPerfomHandler2way1);
            WorkPerfomHandler2way del5 = new WorkPerfomHandler2way(DImplementation.WorkPerfomHandler2way2);
            WorkPerfomHandler2way del6 = new WorkPerfomHandler2way(DImplementation.WorkPerfomHandler2way3);


            WorkPerfomHandler delegateList;
            WorkPerfomHandler2way delegateList2;
            #endregion

            #region  Send the data through "pipes" delegates 
            del1(5, WorkType.Golf);
            del2(1, WorkType.GoToMeeting);
            #endregion

            #region  Send a delegate as a parameter
            for (int index = 1; index<= 2; index++)
            {
                switch (index)
                {
                    case 1:
                        DoWork(del1);
                        break;
                    case 2:
                        DoWork(del2);
                        break;
                    default:
                        break;
                }
            }
            #endregion

            #region Invokation list or multicast delegate
            //Notify multiple subscribers when an event is raised.
            delegateList = del1 + del2 + del3;
            delegateList(3, WorkType.GenerateReports);

            //Another way to create the invocation list
            del1 += del2 + del3;
            del1(4, WorkType.Golf);

            //return the value from the method.
            Console.WriteLine(del6(10, WorkType.GenerateReports));
            //return only the value of the last called function
            delegateList2 = del4 + del5 + del6;
            Console.WriteLine(delegateList2(10, WorkType.GenerateReports));
            #endregion
        }

        public void DoWork(WorkPerfomHandler delegateParam)
        {
            delegateParam(5, WorkType.GoToMeeting);
        }

    }
}
