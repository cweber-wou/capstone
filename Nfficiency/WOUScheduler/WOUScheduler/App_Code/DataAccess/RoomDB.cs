using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for RoomDB
/// </summary>
[DataObject(true)]
public static class RoomDB
{
    [DataObjectMethod(DataObjectMethodType.Select)]
    public static IEnumerable GetAllCatagories()
    {
        SqlConnection con = new SqlConnection(GetConnectionString());
        string sel = "SELECT * FROM Room";
        SqlCommand cmd = new SqlCommand(sel, con);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        return dr;
    }

    private static string GetConnectionString()
    {
        return ConfigurationManager.ConnectionStrings["ServerDB"].ConnectionString;
    }
}