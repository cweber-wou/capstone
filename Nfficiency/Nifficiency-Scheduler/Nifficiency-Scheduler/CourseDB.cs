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

     [DataObject(true)]
     public static class CourseDB
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
         public static List<Course> GetCourse()
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

        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings
                ["ServerDB"].ConnectionString;
        }
        /**
         *   public static int InsertCatigory(Category category)

         * 
        **/

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static int InsertCourse(Course course)
        {
            SqlConnection con = new SqlConnection(GetConnectionString());
            string ins = "INSERT INTO COURSE"
                + " (cid, did, description, hours) "
                + " VALUES(  @CID, @DID, @Description, @Hours)";
            SqlCommand cmd = new SqlCommand(ins, con);
                      
            cmd.Parameters.AddWithValue("CID", course.CID);
            cmd.Parameters.AddWithValue("DID", course.DID);
            cmd.Parameters.AddWithValue("Description", course.Description);
            cmd.Parameters.AddWithValue("Hours", course.Hours);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;

        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static int DeleteCourse(Course course)
        {
            SqlConnection con = new SqlConnection(GetConnectionString());
            string del = "DELETE FROM Course "
                + "WHERE CID = @CID "
                + "AND DID = @DID ";
            SqlCommand cmd = new SqlCommand(del, con);
            cmd.Parameters.AddWithValue("CID", course.CID);
            cmd.Parameters.AddWithValue("DID", course.DID);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int UpdateCourse(Course original_Course, Course course)
        {
            SqlConnection con = new SqlConnection(GetConnectionString());
            string up = "UPDATE Course "
                + "SET CID = @CID, "
                + "DID = @DID, "
                + "WHERE CID = @original_CID ";
            SqlCommand cmd = new SqlCommand(up, con);
            cmd.Parameters.AddWithValue("CID", course.CID);
            cmd.Parameters.AddWithValue("DID", course.DID);
            cmd.Parameters.AddWithValue("original_CID", original_Course.CID);
            cmd.Parameters.AddWithValue("original_DID", original_Course.DID);

            con.Open();
            int updateCount = cmd.ExecuteNonQuery();
            con.Close();
            return updateCount;
        }
    
};