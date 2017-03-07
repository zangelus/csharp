using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPFDataBindingOneWay
{

    //Create the POCOS, Plain Old CLR Objects
    public class Employee:INotifyPropertyChanged
    {
        private string name;
        public string Name {
            get {   return name;}
            set {
                    name = value;
                    OnPropertyChanged();
                }
        }
        private string title;
        public string Title
        {
            get
            { return title; }
            set
            {
                title = value;
                OnPropertyChanged();
                ///PropertyChanged += Employee_PropertyChanged;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        //private void Employee_PropertyChanged(object sender, PropertyChangedEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

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

       

        public void OnPropertyChanged([CallerMemberName] string caller = "" )
        {
            if (PropertyChanged!=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }
    }
}
