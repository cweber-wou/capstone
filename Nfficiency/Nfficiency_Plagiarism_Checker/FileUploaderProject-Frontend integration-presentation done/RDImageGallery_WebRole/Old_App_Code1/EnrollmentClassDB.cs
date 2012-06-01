using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel;
using System.Collections.Generic;
using System;


[DataObject(true)]
public static class EnrollmentClassDB
{

    [DataObjectMethod(DataObjectMethodType.Select)]
    public static List<CS430_ASPNET_Role_Records.Old_App_Code1.EnrollmentClass> GetEnrollment(String inUser_ID)
    {
        //inUser_ID = "ckessel";
        List<CS430_ASPNET_Role_Records.Old_App_Code1.EnrollmentClass> courseList = new List<CS430_ASPNET_Role_Records.Old_App_Code1.EnrollmentClass>();
        SqlConnection con = new SqlConnection(GetConnectionString());
        string sel = "SELECT User_ID, Course_ID, eCourse_Name "
            + "FROM Enrollment "
            + "WHERE User_ID =@ID1 "
            + "ORDER BY Course_ID desc";
        SqlCommand cmd = new SqlCommand(sel, con);

        cmd.Parameters.AddWithValue("@ID1", inUser_ID);

        con.Open();
        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        CS430_ASPNET_Role_Records.Old_App_Code1.EnrollmentClass courseClass;
        while (dr.Read())
        {
            courseClass = new CS430_ASPNET_Role_Records.Old_App_Code1.EnrollmentClass();
            courseClass.User_ID = dr["User_ID"].ToString();
            courseClass.Course_ID = dr["Course_ID"].ToString();
            courseClass.eCourse_Name = dr["eCourse_Name"].ToString();

            courseList.Add(courseClass);
        }
        dr.Close();
        return courseList;

    }

    public static List<CS430_ASPNET_Role_Records.Old_App_Code1.EnrollmentClass> GetEnrollment()
    {
        List<CS430_ASPNET_Role_Records.Old_App_Code1.EnrollmentClass> courseList = new List<CS430_ASPNET_Role_Records.Old_App_Code1.EnrollmentClass>();
        SqlConnection con = new SqlConnection(GetConnectionString());
        string sel = "SELECT User_ID, Course_ID, eCourse_Name "
            + "FROM Enrollment "
            + "ORDER BY Course_ID desc";
        SqlCommand cmd = new SqlCommand(sel, con);
        con.Open();
        SqlDataReader dr =
            cmd.ExecuteReader(CommandBehavior.CloseConnection);
        CS430_ASPNET_Role_Records.Old_App_Code1.EnrollmentClass courseClass;
        while (dr.Read())
        {
            courseClass = new CS430_ASPNET_Role_Records.Old_App_Code1.EnrollmentClass();
            courseClass.User_ID = dr["User_ID"].ToString();
            courseClass.Course_ID = dr["Course_ID"].ToString();
            courseClass.eCourse_Name = dr["eCourse_Name"].ToString();

            courseList.Add(courseClass);
        }
        dr.Close();
        return courseList;

    }

    private static string GetConnectionString()
    {
        return ConfigurationManager.ConnectionStrings
            ["justin_dbConnectionString"].ConnectionString;
    }
}