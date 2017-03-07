using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataGrid
{
    public enum Party
    {
        Independant,
        Federalist,
        DemocratRepublicant,
    }
    public class Employee : INotifyPropertyChanged
    {
        private string _name;
        public string Name { get { return _name; } set { _name = value; RaisedPropertyChanged(); } }

        private string _title;
        public string Title { get { return _title; } set { _title = value; RaisedPropertyChanged(); } }

        private bool _wasReelected;
        public bool WasReelected { get { return _wasReelected; } set { _wasReelected = value; RaisedPropertyChanged(); } }

        private Party _affiliation;
        public Party Affiliation { get { return _affiliation; } set { _affiliation = value; RaisedPropertyChanged(); } }


        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisedPropertyChanged([CallerMemberName] string caller ="")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }




        public static ObservableCollection<Employee> GetEmployee()
        {
            var Employees = new ObservableCollection<Employee>
            {
                new Employee() { Name="Washington",Title="President 1", WasReelected=true,Affiliation=Party.Independant },
                new Employee() { Name="Adams",Title="President 2", WasReelected=false,Affiliation=Party.Federalist },
                new Employee() { Name="Jefferson",Title="President 3", WasReelected=true,Affiliation=Party.DemocratRepublicant },
                new Employee() { Name="Madison",Title="President 4", WasReelected=true,Affiliation=Party.DemocratRepublicant },
                 new Employee() { Name="Monrow",Title="President 5", WasReelected=true,Affiliation=Party.DemocratRepublicant }
            };

            return Employees;
        }

    }
}
