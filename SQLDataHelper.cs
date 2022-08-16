using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using WebApplication3.Models;


namespace WebApplication3.DataLayer
{
    public class SQLDataHelper
    {
        string connectionString = "";
        public SQLDataHelper()
        { connectionString = WebConfigurationManager.ConnectionStrings["ProjectDB"].ConnectionString;}
        public List<string> GetStudentsName()
        {
            List<string> listOfStudentsName = new List<string>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Select * from students", con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                   // Student str = new Student();
                    // str.ID = Convert.ToInt32(sdr["ID"]); //These are table column names
                    string Name = sdr["Student_Name"].ToString();
                    // str.Address = sdr["Student_Address"].ToString();
                    listOfStudentsName.Add(Name);
                }
                con.Close();
            }
            return listOfStudentsName;
        }
      public List<Student> GetStudentsData()
        {
            List<Student> listOfStudents = new List<Student>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Select * from students", con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    Student str = new Student();
                    str.ID = Convert.ToInt32(sdr["ID"]); //These are table column names
                    str.Name = sdr["Student_Name"].ToString();
                    str.Address = sdr["Student_Address"].ToString();
                    listOfStudents.Add(str);
                }
                con.Close();
            }
            return listOfStudents;
        }
    }
}
  
       