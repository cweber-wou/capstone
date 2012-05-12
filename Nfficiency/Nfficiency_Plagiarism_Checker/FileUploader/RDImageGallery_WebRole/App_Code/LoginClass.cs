using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel;
using System.Collections.Generic;
using System;

/// <summary>
/// Summary description for Login
/// </summary>
 [DataObject(true)]
public class LoginClass
{
	public LoginClass()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    [DataObjectMethod(DataObjectMethodType.Select)]

    public static string returnPassword(userEncrypt category)
    {
        SqlConnection con = new SqlConnection(GetConnectionString());
        string sel = "SELECT Password "
            + "FROM Customers "
            + "WHERE User_id = @User_id";
        SqlCommand cmd = new SqlCommand(sel, con);
        con.Open();
        cmd.Parameters.AddWithValue("User_id", category.User_id);
        SqlDataReader dr =
            cmd.ExecuteReader(CommandBehavior.CloseConnection);
        
        // Order order;
        String retPassword = "";
        while (dr.Read())
        {
            retPassword = dr["Password"].ToString();
        }
        dr.Close();
        return retPassword;
    }

    [DataObjectMethod(DataObjectMethodType.Select)]
    private static string GetConnectionString()
    {
        return ConfigurationManager.ConnectionStrings
            ["accountdbConnectionString"].ConnectionString;
    }


}