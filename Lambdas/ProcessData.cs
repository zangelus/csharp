using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambdas
{
    class ProcessData
    {
        public int Process(int x, int y, BusinessRules del)
        {
            return del(x, y);
        }

         public void Process2(int x, int y, Action<int,int> del)
        {
            del(x, y);
        }

        public int Process3 (int x, int y, Func<int, int,int> del)
        {
            return del(x, y);
        }
    }
}
