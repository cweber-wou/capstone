// DB Table
// DID int
// Department nvarchar(MAX)
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel;


[DataObject(true)]
public static class DepartmentDB
{
    //[DataObjectMethod(DataObjectMethodType.Select)]
    //public static List<Course> GetAllCourses() {

    //}

    [DataObjectMethod(DataObjectMethodType.Select)]
    public static List<Department> GetAllCourses()
    {
        List<Department> DepartmentList = new List<Department>();
        SqlConnection con = new SqlConnection(GetConnectionString());
        string sel = "SELECT DID, Department "
            + "FROM Department ORDER BY DID";
        SqlCommand cmd = new SqlCommand(sel, con);
        con.Open();
        SqlDataReader dr =
            cmd.ExecuteReader(CommandBehavior.CloseConnection);
        Department department;
        while (dr.Read())
        {
            department = new Department();
            department.DID = Convert.ToInt16(dr["DID"].ToString());
            department.department = department.ToString();
            DepartmentList.Add(department);
        }
        dr.Close();
        return DepartmentList;
    }

    private static string GetConnectionString()
    {
        return ConfigurationManager.ConnectionStrings
            ["ServerDB"].ConnectionString;
    }

    [DataObjectMethod(DataObjectMethodType.Insert)]
    public static int InsertDepartment(Department Department)
    {
        SqlConnection con = new SqlConnection(GetConnectionString());
        string ins = "INSERT INTO Department"
            + " (Department) "
            + " VALUES(@Department)";
        SqlCommand cmd = new SqlCommand(ins, con);


        cmd.Parameters.AddWithValue("Department", Department.department);
        con.Open();
        int i = cmd.ExecuteNonQuery(); // i is the number of rows affected by the command.
        con.Close();
        return i;

    }

    [DataObjectMethod(DataObjectMethodType.Delete)]
    public static int DeleteDepartment(Department Department)
    {
        SqlConnection con = new SqlConnection(GetConnectionString());
        string del = "DELETE FROM Department "
            + "WHERE DID = @DID ";
        SqlCommand cmd = new SqlCommand(del, con);
        cmd.Parameters.AddWithValue("DID", Department.DID);

        con.Open();
        int i = cmd.ExecuteNonQuery();
        con.Close();
        return i;
    }

    [DataObjectMethod(DataObjectMethodType.Update)]
    public static int UpdateDepartment(Department Department)
    {
        SqlConnection con = new SqlConnection(GetConnectionString());
        string up = "UPDATE Department "
            + "SET department = @Department, "
            
            + "WHERE DID = @DID ";
        SqlCommand cmd = new SqlCommand(up, con);
        
        cmd.Parameters.AddWithValue("Department", Department.department);
        


        con.Open();
        int updateCount = cmd.ExecuteNonQuery();
        con.Close();
        return updateCount;
    }

}