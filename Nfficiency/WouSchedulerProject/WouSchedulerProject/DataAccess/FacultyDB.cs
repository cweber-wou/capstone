
//public int ID { get; set; } FID
//public string first { get; set; } Fisrt
//public string last { get; set; } Last

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel;

[DataObject(true)]
public static class FacultyDB
{
    [DataObjectMethod(DataObjectMethodType.Select)]
    public static List<Faculty> GetAllFauclty()
    {
        List<Faculty> facultyList = new List<Faculty>();
        SqlConnection con = new SqlConnection(GetConnectionString());
        string sel = "SELECT FID, First, Last "
            + "FROM Faculty ORDER BY FID";
        SqlCommand cmd = new SqlCommand(sel, con);
        con.Open();
        SqlDataReader dr =
            cmd.ExecuteReader(CommandBehavior.CloseConnection);
        Faculty faculty;
        while (dr.Read())
        {
            faculty = new Faculty();
            faculty.ID = Convert.ToInt16(dr["FID"].ToString());
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

    [DataObjectMethod(DataObjectMethodType.Insert)]
    public static int InsertFaculty(Faculty faculty)
    {
        SqlConnection con = new SqlConnection(GetConnectionString());
        string ins = "INSERT INTO Faculty"
            + " (First, Last) "
            + " VALUES(@First, @Last)";
        SqlCommand cmd = new SqlCommand(ins, con);


        cmd.Parameters.AddWithValue("First", faculty.first);
        cmd.Parameters.AddWithValue("Last", faculty.last);
        con.Open();
        int i = cmd.ExecuteNonQuery(); // i is the number of rows affected by the command.
        con.Close();
        return i;

    }

    [DataObjectMethod(DataObjectMethodType.Delete)]
    public static int DeleteFaculty(Faculty faculty)
    {
        SqlConnection con = new SqlConnection(GetConnectionString());
        string del = "DELETE FROM Faculty "
            + "WHERE FID = @FID ";
        SqlCommand cmd = new SqlCommand(del, con);
        cmd.Parameters.AddWithValue("FID", faculty.ID);

        con.Open();
        int i = cmd.ExecuteNonQuery();
        con.Close();
        return i;
    }

    [DataObjectMethod(DataObjectMethodType.Update)]
    public static int UpdateFaculty(Faculty faculty)
    {
        SqlConnection con = new SqlConnection(GetConnectionString());
        string up = "UPDATE Faculty "
            + "SET First = @First, "
            + "Last = @Last "
            + "WHERE FID = @FID ";
        SqlCommand cmd = new SqlCommand(up, con);
        cmd.Parameters.AddWithValue("FID", faculty.ID);
        cmd.Parameters.AddWithValue("First", faculty.first);
        cmd.Parameters.AddWithValue("Last", faculty.last);


        con.Open();
        int updateCount = cmd.ExecuteNonQuery();
        con.Close();
        return updateCount;
    }

}