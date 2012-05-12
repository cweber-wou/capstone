using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel;
using System.Collections.Generic;

[DataObject(true)]
public static class CategoryDB
{
    [DataObjectMethod(DataObjectMethodType.Select)]

    public static List<Category> GetCategory()
    {
        List<Category> categoryList = new List<Category>();
        SqlConnection con = new SqlConnection(GetConnectionString());
        string sel = "SELECT Customer_id, first_name, last_name, street, city, state, zip "
            + "FROM Customers ORDER BY Customer_id desc";
        SqlCommand cmd = new SqlCommand(sel, con);
        con.Open();
        SqlDataReader dr = 
            cmd.ExecuteReader(CommandBehavior.CloseConnection);
        Category category;
        while (dr.Read())
        {
            category = new Category();
            category.Customer_ID = dr["Customer_ID"].ToString();
            category.First_Name = dr["First_Name"].ToString();
            category.Last_Name = dr["Last_Name"].ToString();
            category.Street = dr["Street"].ToString();
            category.City = dr["City"].ToString();
            category.State = dr["State"].ToString();
            category.Zip = dr["Zip"].ToString();
            categoryList.Add(category);
        }
        dr.Close();
        return categoryList;
    }

    private static string GetConnectionString()
    {
        return ConfigurationManager.ConnectionStrings
            ["justin_dbConnectionString"].ConnectionString;
    }

    [DataObjectMethod(DataObjectMethodType.Insert)]

    public static int InsertCatigory(Category category)
    {
        SqlConnection con = new SqlConnection(GetConnectionString());
        string ins = "INSERT INTO Customers"
            + " (Last_Name, First_Name, Street, City, State, Zip) "
            + " VALUES( @First_Name, @Last_Name, @Street, @City,@State, @Zip)";
        SqlCommand cmd = new SqlCommand(ins, con);
        //cmd.Parameters.AddWithValue("Customer_ID", category.Customer_ID);
        cmd.Parameters.AddWithValue("First_Name", category.First_Name);
        cmd.Parameters.AddWithValue("Last_Name", category.Last_Name);
        cmd.Parameters.AddWithValue("Street", category.Street);
        cmd.Parameters.AddWithValue("City", category.City);
        cmd.Parameters.AddWithValue("State", category.State);
        cmd.Parameters.AddWithValue("Zip", category.Zip);
        con.Open();
        int i = cmd.ExecuteNonQuery();
        con.Close();
        return i;
    }

    [DataObjectMethod(DataObjectMethodType.Delete)]

    public static int DeleteCategory(Category category)
    {
        SqlConnection con = new SqlConnection(GetConnectionString());
        string del = "DELETE FROM Customers "
            + "WHERE Customer_id = @Customer_id "
            + "AND first_name = @first_name "
            + "AND last_name = @last_name ";
        SqlCommand cmd = new SqlCommand(del, con);
        cmd.Parameters.AddWithValue("Pizza_id", category.Pizza_ID);
        cmd.Parameters.AddWithValue("Customer_id", category.Customer_ID);
        cmd.Parameters.AddWithValue("first_name", category.First_Name);
        cmd.Parameters.AddWithValue("last_name", category.Last_Name);
        cmd.Parameters.AddWithValue("street", category.Street);
        cmd.Parameters.AddWithValue("city", category.City);
        cmd.Parameters.AddWithValue("state", category.State);
        cmd.Parameters.AddWithValue("zip", category.Zip);
        con.Open();
        int i = cmd.ExecuteNonQuery();
        con.Close();
        return i;
    }

    [DataObjectMethod(DataObjectMethodType.Update)]

    public static int UpdateCategory(Category original_Category, Category category)
    {
        SqlConnection con = new SqlConnection(GetConnectionString());
        string up = "UPDATE Customers "
            //+ "SET Customer_ID = @Customer_ID, "
            + "SET First_Name = @First_Name, "
            + "Last_Name = @Last_Name, "
            + "Street = @Street, "
            + "City = @City, "
            + "State = @State, "
            + "Zip = @Zip "
            + "WHERE First_Name = @original_First_Name "
            + "AND Last_Name = @original_Last_Name "
            + "AND Street = @original_Street "
            + "AND City = @original_City "
            + "AND State = @original_State "
            + "AND Zip = @original_Zip";
        SqlCommand cmd = new SqlCommand(up, con);
       
       // cmd.Parameters.AddWithValue("Customer_ID", category.Customer_ID);
        cmd.Parameters.AddWithValue("First_Name", category.First_Name);
        cmd.Parameters.AddWithValue("Last_Name", category.Last_Name);
        cmd.Parameters.AddWithValue("Street", category.Street);
        cmd.Parameters.AddWithValue("City", category.City);
        cmd.Parameters.AddWithValue("State", category.State);
        cmd.Parameters.AddWithValue("Zip", category.Zip);
        //cmd.Parameters.AddWithValue("original_Customer_ID",original_Category.Customer_ID);
        cmd.Parameters.AddWithValue("original_First_Name",original_Category.First_Name);
        cmd.Parameters.AddWithValue("original_Last_Name",original_Category.Last_Name);
        cmd.Parameters.AddWithValue("original_Street", original_Category.Street);
        cmd.Parameters.AddWithValue("original_City", original_Category.City);
        cmd.Parameters.AddWithValue("original_State", original_Category.State);
        cmd.Parameters.AddWithValue("original_Zip", original_Category.Zip);
        con.Open();
        int updateCount = cmd.ExecuteNonQuery();
        con.Close();
        return updateCount;
    }
}