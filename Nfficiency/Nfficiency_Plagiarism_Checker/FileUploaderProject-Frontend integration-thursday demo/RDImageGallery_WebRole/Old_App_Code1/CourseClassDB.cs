using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel;
using System.Collections.Generic;
using System;

[DataObject(true)]
    public static class CourseClassDB
    {

     [DataObjectMethod(DataObjectMethodType.Select)]

    public static List<CourseClass> GetCourses()
    {
        List<CourseClass> courseList = new List<CourseClass>();
        SqlConnection con = new SqlConnection(GetConnectionString());
        string sel = "SELECT Course_ID, Course_Name, Course_Description, Course_EnrollmentKey, Course_Owner "
            + "FROM Courses ORDER BY Course_ID desc";
        SqlCommand cmd = new SqlCommand(sel, con);
        con.Open();
        SqlDataReader dr = 
            cmd.ExecuteReader(CommandBehavior.CloseConnection);
        CourseClass courseClass;
        while (dr.Read())
        {
            courseClass = new CourseClass();
            courseClass.Course_ID = dr["Course_ID"].ToString();
            courseClass.Course_Name = dr["Course_Name"].ToString();
            courseClass.Course_Description = dr["Course_Description"].ToString();
            courseClass.Course_EnrollmentKey = dr["Course_EnrollmentKey"].ToString();
            courseClass.Course_Owner = dr["Course_Owner"].ToString();
            courseList.Add(courseClass);
        }
        dr.Close();
        return courseList;
    }

    [DataObjectMethod(DataObjectMethodType.Select)]

     public static string return_CourseID(CourseClass courseClass)
    {
        SqlConnection con = new SqlConnection(GetConnectionString());
        string sel = "SELECT top(1) Course_ID"
            + "FROM Courses Order by Course_ID desc";
        SqlCommand cmd = new SqlCommand(sel, con);
        con.Open();
        SqlDataReader dr =
            cmd.ExecuteReader(CommandBehavior.CloseConnection);
       // Order order;
        String retOrder_id = "";
        while (dr.Read())
        {
          retOrder_id = dr["Course_ID"].ToString(); // RETURNING NULL HERE
        }
        dr.Close();
        return retOrder_id;
    }

    [DataObjectMethod(DataObjectMethodType.Select)]

    public static string return_LastCourseID()
    {
        SqlConnection con = new SqlConnection(GetConnectionString());
        string sel = "SELECT top(1) Order_id "
            + "FROM customer_orders Order by customer_order_id desc";
        SqlCommand cmd = new SqlCommand(sel, con);
        con.Open();
        SqlDataReader dr =
            cmd.ExecuteReader(CommandBehavior.CloseConnection);
        // Order order;
        String retLastOrder_id = "";
        while (dr.Read())
        {
            retLastOrder_id = dr["Order_ID"].ToString();
        }
        dr.Close();
        return retLastOrder_id;
    }

    private static string GetConnectionString()
    {
        return ConfigurationManager.ConnectionStrings
            ["justin_dbConnectionString"].ConnectionString;
    }

    [DataObjectMethod(DataObjectMethodType.Insert)]

    public static string insert_Course(CourseClass courseClass)
    {
       
       // Set Identity_Insert Orders ON;
        SqlConnection con = new SqlConnection(GetConnectionString());
        string ins = "INSERT INTO Courses"
            + " (  Course_Name, Course_Description, Course_EnrollmentKey, Course_Owner) "
            + " VALUES(  @Course_Name, @Course_Description, @Course_EnrollmentKey, @Course_Owner)";
        SqlCommand cmd = new SqlCommand(ins, con);
       
      
        //cmd.Parameters.AddWithValue("Course_ID", courseClass.Course_ID);
        cmd.Parameters.AddWithValue("Course_Name", courseClass.Course_Name);
        cmd.Parameters.AddWithValue("Course_Description", courseClass.Course_Description);
        cmd.Parameters.AddWithValue("Course_EnrollmentKey", courseClass.Course_EnrollmentKey);
        cmd.Parameters.AddWithValue("Course_Owner", courseClass.Course_Owner);
        con.Open();
        int i = cmd.ExecuteNonQuery();
        con.Close();
       
           
      
        return courseClass.Course_ID;
        
    }

    [DataObjectMethod(DataObjectMethodType.Insert)]

    public static string insert_courseClass(CourseClass courseClass)
    {
        SqlConnection con = new SqlConnection(GetConnectionString());
        string ins = "INSERT INTO Courses"
            + " (Course_ID,  Course_Name, Course_Description, Course_EnrollmentKey, Course_Owner ) "
            + " VALUES( @OCourse_ID, @Course_Name, @Course_Description, @Course_EnrollmentKey, @Course_Owner)";
        SqlCommand cmd = new SqlCommand(ins, con);
        cmd.Parameters.AddWithValue("Course_ID", courseClass.Course_ID);
        cmd.Parameters.AddWithValue("Course_Name", courseClass.Course_Name);
        cmd.Parameters.AddWithValue("Course_Description", courseClass.Course_Description);
        cmd.Parameters.AddWithValue("Course_EnrollmentKey", courseClass.Course_EnrollmentKey);
        cmd.Parameters.AddWithValue("Course_Owner", courseClass.Course_Owner);
        con.Open();
        int i = cmd.ExecuteNonQuery();
        con.Close();
        return courseClass.Course_ID;

    }

   

    [DataObjectMethod(DataObjectMethodType.Delete)]

    public static int delete_Course(CourseClass courseClass)
    {
        SqlConnection con = new SqlConnection(GetConnectionString());
        string del = "DELETE FROM Courses "
            + "WHERE Course_ID = @Course_ID "
            + "AND Course_Name = @Course_Name "
            + "AND Course_Description = @Course_Description "
            + "AND Course_EnrollmentKey = @Course_EnrollmentKey "
            + "AND Course_Owner = @Course_Owner";
        SqlCommand cmd = new SqlCommand(del, con);
        cmd.Parameters.AddWithValue("Course_ID", courseClass.Course_ID);
        cmd.Parameters.AddWithValue("Course_Name", courseClass.Course_Name);
        cmd.Parameters.AddWithValue("Course_Description", courseClass.Course_Description);
        cmd.Parameters.AddWithValue("Course_EnrollmentKey", courseClass.Course_EnrollmentKey);
        cmd.Parameters.AddWithValue("Course_Owner", courseClass.Course_Owner);
        con.Open();
        int i = cmd.ExecuteNonQuery();
        con.Close();
        return i;
    }

    [DataObjectMethod(DataObjectMethodType.Update)]

    public static int update_Course(CourseClass original_courseClass, CourseClass courseClass)
    {
        SqlConnection con = new SqlConnection(GetConnectionString());
        string up = "UPDATE Courses "
            + "SET Course_ID = @Course_ID, "
            + "SET Course_Name = @Course_Name, "
            + "SET Course_Description = @Course_Description "
            + "SET Course_EnrollmentKey = @Course_EnrollmentKey "
            + "SET Course_Owner = @Course_Owner "
            + "Where Course_ID = @origional_Course_ID "
            + "AND Course_Name = @original_Course_Name "
            + "AND Course_Description = @original_Course_Description "
            + "AND Course_EnrollmentKey = @origional_Course_EnrollmentKey "
            + "AND Course_Owner = @origional_Course_Owner ";
        SqlCommand cmd = new SqlCommand(up, con);
       
       
       // cmd.Parameters.AddWithValue("Order_ID", order.Order_ID);
        cmd.Parameters.AddWithValue("Course_ID", courseClass.Course_ID);
        cmd.Parameters.AddWithValue("Course_Name", courseClass.Course_Name);
        cmd.Parameters.AddWithValue("Course_Description", courseClass.Course_Description);
        cmd.Parameters.AddWithValue("Course_EnrollmentKey", courseClass.Course_EnrollmentKey);
        cmd.Parameters.AddWithValue("Course_Owner", courseClass.Course_Owner);
        ///////ORIGINAL PARAMS///////////////////////////////////
        cmd.Parameters.AddWithValue("original_Course_ID",original_courseClass.Course_ID);
        cmd.Parameters.AddWithValue("original_Course_Name", original_courseClass.Course_Name);
        cmd.Parameters.AddWithValue("original_Course_Description",original_courseClass.Course_Description);
        cmd.Parameters.AddWithValue("original_Course_EnrollmentKey", original_courseClass.Course_EnrollmentKey);
        cmd.Parameters.AddWithValue("original_Course_Owner", original_courseClass.Course_Owner);
        con.Open();
        int updateCount = cmd.ExecuteNonQuery();
        con.Close();
        return updateCount;
    }
}

