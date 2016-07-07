using System.Data;
using StudentAttendenceSystem.Entities;
namespace StudentAttendenceSystem.DataAccess
{
    public interface IAttendenceDataAccess
    {
        DataTable GetAllStudentsAttendence();
        bool InsertAttendance(Students attendanceData);
    }
}