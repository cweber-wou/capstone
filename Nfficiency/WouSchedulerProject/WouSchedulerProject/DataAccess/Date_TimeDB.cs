using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel;


[DataObject(true)]
public static class Date_TimeDB
{
    [DataObjectMethod(DataObjectMethodType.Select)]
    public static List<Faculty> GetAllCourses()
    {
        List<Faculty> facultyList = new List<Faculty>();
        SqlConnection con = new SqlConnection(GetConnectionString());
        string sel = "SELECT FID, First, Last "
            + "FROM Faculty ORDER BY FID";
        SqlCommand cmd = new SqlCommand(sel, con);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        Faculty faculty;
        while (dr.Read())
        {
            faculty = new Faculty();
            faculty.ID = Convert.ToInt32(dr["FID"].ToString());
            faculty.first = dr["First"].ToString();
            faculty.last = dr["Last"].ToString();
            facultyList.Add(faculty);
        }
        dr.Close();
        return facultyList;
    }

    private static string GetConnectionString()
    {
        return ConfigurationManager.ConnectionStrings
            ["ServerDB"].ConnectionString;
    }
}