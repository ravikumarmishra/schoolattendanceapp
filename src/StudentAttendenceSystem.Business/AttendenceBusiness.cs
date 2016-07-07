using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentAttendenceSystem.Entities;
using StudentAttendenceSystem.DataAccess;
using System.Data;
using StudentAttendenceSystem.Log;

namespace StudentAttendenceSystem.Business
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class AttendenceBusiness: IAttendenceBusiness
    {
        private IAttendenceDataAccess attendenceDetails;
        Logger _logError = new Logger();
        StudentAttendenceSystem.Log.Log _error = new Log.Log();
        public AttendenceBusiness(IAttendenceDataAccess attendence)
        {
            attendenceDetails = attendence;
        }
       public List<Students> GetAllStudentAttendence()
        {
            List<Students> _studentDetails = new List<Students>();
            
            DataTable dtble= attendenceDetails.GetAllStudentsAttendence();
            foreach(DataRow item in dtble.Rows)
            {
                Students oStudents = new Students();
                oStudents.StudentId = (int)item["StudentId"];
                oStudents.StudentName = (string)item["StudentName"];
                oStudents.Date = (DateTime)item["Date"];
                oStudents.AttendenceStatus = (string)item["AttendenceStatus"];
                _studentDetails.Add(oStudents);
            }
            return (_studentDetails);
        }

        public bool InsertAttendance(Students attendance)
        {
            try
            {
                if (attendenceDetails.InsertAttendance(attendance))
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                _error.error = ex.Message;
                _logError.Create(_error);
                return false;
            }
        }
    }
}
