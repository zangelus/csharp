using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesEventsLambdas.Delegates
{
    //one way delegate -> data goes only on one direction
    public delegate void WorkPerfomHandler(int hours, WorkType worktype);

    //Two way delegate -> one data can return from the invoked method
    public delegate int WorkPerfomHandler2way(int hours, WorkType worktype);

    public enum WorkType
    {
        GoToMeeting=1,
        Golf,
        GenerateReports
    }

}
