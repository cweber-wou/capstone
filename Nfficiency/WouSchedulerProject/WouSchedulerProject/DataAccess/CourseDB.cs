//********************************************
// int CID { get; set; }
//  int DID { get; set; }
//  String Description { get; set; }
//  int Hours { get; set; }
//*********************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel;
using System.Collections;
//using WouSchedulerProject.DataAccess;

     [DataObject(true)]
     public static class CourseDB
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
         public static List<Course> GetAllCourses()
        {
            List<Course> courseList = new List<Course>();
            SqlConnection con = new SqlConnection(GetConnectionString());
            string sel = "SELECT cid, did, description, hours "
                + "FROM COURSE ORDER BY CID";
            SqlCommand cmd = new SqlCommand(sel, con);
            con.Open();
            SqlDataReader dr =
                cmd.ExecuteReader(CommandBehavior.CloseConnection);
            Course course;
            while (dr.Read())
            {
                course = new Course();
                course.CID = Convert.ToInt16(dr["CID"].ToString());
                course.DID = Convert.ToInt16(dr["DID"].ToString());
                course.Description = dr["Description"].ToString();
                course.Hours = Convert.ToInt16(dr["Hours"].ToString());
                courseList.Add(course);
            }
            dr.Close();
            return courseList;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static DataSet GetAllCoursesForPage()
        {
            SqlConnection con = new SqlConnection(GetConnectionString());
            string sel =  "SELECT CID, Department.Department, COURSE.Description, Hours "
                        + "FROM   COURSE, Department "
                        + "WHERE  Department.DID = COURSE.DID";
            SqlDataAdapter da = new SqlDataAdapter(sel, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Courses");
            return ds;
        }

        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings
                ["ServerDB"].ConnectionString;
        }
        /**
         *   public static int InsertCatigory(Category category)

         * 
        **/

        //[DataObjectMethod(DataObjectMethodType.Insert)]
        //public static int InsertCourse(Course course)
        //{
        //    SqlConnection con = new SqlConnection(GetConnectionString());
        //    string ins = "INSERT INTO COURSE"
        //        + " (cid, did, description, hours) "
        //        + " VALUES(@DID, @Description, @Hours)";
        //    SqlCommand cmd = new SqlCommand(ins, con);
                      
        //    //cmd.Parameters.AddWithValue("CID", course.CID);
        //    cmd.Parameters.AddWithValue("DID", course.DID);
        //    cmd.Parameters.AddWithValue("Description", course.Description);
        //    cmd.Parameters.AddWithValue("Hours", course.Hours);
        //    con.Open();
        //    int i = cmd.ExecuteNonQuery(); // i is the number of rows affected by the command.
        //    con.Close();
        //    return i;

        //}

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static int InsertCourse(Course course)
        {
            SqlConnection con = new SqlConnection(GetConnectionString());
            string ins = "INSERT INTO COURSE(did, description, hours) "
                       + "VALUES(@DID, @Description, @Hours)";
            SqlCommand cmd = new SqlCommand(ins, con);

            //cmd.Parameters.AddWithValue("CID", course.CID);
            cmd.Parameters.AddWithValue("DID", course.DID);
            cmd.Parameters.AddWithValue("Description", course.Description);
            cmd.Parameters.AddWithValue("Hours", course.Hours);
            con.Open();
            int i = cmd.ExecuteNonQuery(); // i is the number of rows affected by the command.
            con.Close();
            return i;

        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static int DeleteCourse(Course course)
        {
            SqlConnection con = new SqlConnection(GetConnectionString());
            //Requires DataKeyNames="CID" property to be set at least for list view
            string del = "DELETE FROM Nifficiency_Scheduler.dbo.COURSE "
                + "WHERE CID = @CID ";
             SqlCommand cmd = new SqlCommand(del, con);
            cmd.Parameters.AddWithValue("CID", course.CID);
            
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int UpdateCourse(Course course) 
        {
            SqlConnection con = new SqlConnection(GetConnectionString());
            string up = "UPDATE Course "
                        + "SET DID = @DID, Description = @Description, Hours = @Hours "
                        + "WHERE CID = @original_CID";
            SqlCommand cmd = new SqlCommand(up, con);

            cmd.Parameters.AddWithValue("DID", course.DID);
            cmd.Parameters.AddWithValue("Description", course.Description);
            cmd.Parameters.AddWithValue("Hours", course.Hours);           
            cmd.Parameters.AddWithValue("original_CID", course.CID);

            con.Open();
            int updateCount = cmd.ExecuteNonQuery();
            con.Close();
            return updateCount;
        }
    
}