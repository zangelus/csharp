using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesEventsLambdas
{
    internal class Filters
    {
        public void AddContrast(Photo photo)
        {
            Console.WriteLine("Constrast added");
        }

        public void AddHue(Photo photo)
        {
            Console.WriteLine("Hue added");
        }


    }
}
