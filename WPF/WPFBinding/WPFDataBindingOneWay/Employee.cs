using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFDataBindingOneWay
{
    //Create the POCOS, Plain Old CLR Objects
    public class Employee
    {
        public string Name { get; set; }
        public string Title { get; set; }

        /* adding this static method, the class will act
           as a stand-in for obtaining an empployee  from 
           a database or from a web service
        */

        public static Employee GetEmployee()
        {
            var employee = new Employee()
            {
                Name = "Zbigniew",
                Title = "Mr."
            };

            return employee;
        }
    }
}
