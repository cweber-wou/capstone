
///    public int ID { get; set; } RID
///    public string building { get; set; } Building
///    public int number { get; set; } number

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel;

[DataObject(true)]
public static class RoomDB
{
    [DataObjectMethod(DataObjectMethodType.Select)]
    public static List<Room> GetAllCourses()
    {
        List<Room> roomList = new List<Room>();
        SqlConnection con = new SqlConnection(GetConnectionString());
        string sel = "SELECT RID, Building, number "
            + "FROM Room ORDER BY RID";
        SqlCommand cmd = new SqlCommand(sel, con);
        con.Open();
        SqlDataReader dr =
            cmd.ExecuteReader(CommandBehavior.CloseConnection);
        Room room;
        while (dr.Read())
        {
            room = new Room();
            room.ID = Convert.ToInt16(dr["RID"].ToString());
            room.number = Convert.ToInt16(dr["number"].ToString());
            room.building = dr["Building"].ToString();
            roomList.Add(room);
        }
        dr.Close();
        return roomList;
    }

    private static string GetConnectionString()
    {
        return ConfigurationManager.ConnectionStrings
            ["ServerDB"].ConnectionString;
    }

    [DataObjectMethod(DataObjectMethodType.Insert)]
    public static int InsertRoom(Room room)
    {
        SqlConnection con = new SqlConnection(GetConnectionString());
        string ins = "INSERT INTO ROOM"
            + " (Building, number) "
            + " VALUES(@Building, @number)";
        SqlCommand cmd = new SqlCommand(ins, con);


        cmd.Parameters.AddWithValue("number", room.number);
        cmd.Parameters.AddWithValue("Building", room.building);
        con.Open();
        int i = cmd.ExecuteNonQuery(); // i is the number of rows affected by the command.
        con.Close();
        return i;

    }

    [DataObjectMethod(DataObjectMethodType.Delete)]
    public static int DeleteRoom(Room room)
    {
        SqlConnection con = new SqlConnection(GetConnectionString());
        string del = "DELETE FROM Room "
            + "WHERE RID = @RID ";
        SqlCommand cmd = new SqlCommand(del, con);
        cmd.Parameters.AddWithValue("RID", room.ID);
        
        con.Open();
        int i = cmd.ExecuteNonQuery();
        con.Close();
        return i;
    }

    [DataObjectMethod(DataObjectMethodType.Update)]
    public static int UpdateRoom(Room room)
    {
        SqlConnection con = new SqlConnection(GetConnectionString());
        string up = "UPDATE Room "
            + "SET number = @number, "
            + "Building = @Building "
            + "WHERE RID = @RID ";
        SqlCommand cmd = new SqlCommand(up, con);
        cmd.Parameters.AddWithValue("RID", room.ID);
        cmd.Parameters.AddWithValue("Building", room.building);
        cmd.Parameters.AddWithValue("number", room.number);
       

        con.Open();
        int updateCount = cmd.ExecuteNonQuery();
        con.Close();
        return updateCount;
    }

}