using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAttendenceSystem.Entities
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class Students
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public DateTime Date { get; set;}
        public string AttendenceStatus { get; set; }
    }
}
