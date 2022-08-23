using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DelegatesEventsLambdas.Delegates;

namespace DelegatesEventsLambdas
{
    class Program
    {
        static void Main(string[] args)
        {
            TestDelegates test = new TestDelegates();
            Console.WriteLine("press any key for next test");
            Console.ReadKey();

            var photoProcessor = new PhotoProcessor();
            var filters = new Filters();
            var photo = new Photo();

            PhotoProcessor.PhotoFilterHandler filter = null;
            filter = filters.AddHue;
            filter += filters.AddContrast;
            filter += AddColor;

            photoProcessor.ApplyFilter(photo, filter);

            Console.WriteLine("press any key for next test");
            Console.ReadKey();
        }

        static private void AddColor(Photo photo)
        {
            Console.WriteLine("Color added");
        }

       
    }
}
