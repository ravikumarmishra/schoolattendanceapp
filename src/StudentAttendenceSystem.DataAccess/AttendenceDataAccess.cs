using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using StudentAttendenceSystem.Log;
using StudentAttendenceSystem.Entities;

namespace StudentAttendenceSystem.DataAccess
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class AttendenceDataAccess:IAttendenceDataAccess
    {
        string ConnectionString = "Data Source=a2md20985;Initial Catalog=StudentDatabase;Integrated Security=True";
        Logger _logError = new Logger();
        StudentAttendenceSystem.Log.Log _error = new Log.Log();
        /// <summary>
        /// method to get all students Attendence records
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllStudentsAttendence()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("GetStudentAttendenceDetails", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = conn;
                        SqlDataAdapter adt = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adt.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                _error.error = ex.Message;
                _logError.Create(_error);
                return null;
            }
        }
        /// <summary>
        /// method for inserting attendance of student to database
        /// </summary>
        /// <param name="attendanceData"></param>
        /// <returns></returns>
        public bool InsertAttendance(Students attendanceData)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("sp_insertAttendance", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Connection = conn;
                        command.Parameters.Add("@studentname", SqlDbType.VarChar).Value = attendanceData.StudentName;
                        command.Parameters.Add("@date", SqlDbType.DateTime).Value = attendanceData.Date;
                        command.Parameters.Add("@status", SqlDbType.VarChar).Value = attendanceData.AttendenceStatus;
                        int count = command.ExecuteNonQuery();       // for execution of the stored procedure
                        if (count >= 1)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                catch (SqlException ex)
                {
                    _error.error = ex.Message;
                    _logError.Create(_error);
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
}
