using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentAttendenceSystem.Entities;

namespace StudentAttendenceSystem.Business
{
    public interface IAttendenceBusiness
    {
        List<Students> GetAllStudentAttendence();
        bool InsertAttendance(Students attendance);
    }
}
