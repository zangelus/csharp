using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesEventsLambdas
{
    internal class PhotoProcessor
    {
        public delegate void PhotoFilterHandler(Photo photo);
        public void ApplyFilter(Photo photo, PhotoFilterHandler filter)
        {
            filter(photo);
            photo.Save();
        }

    }
}
