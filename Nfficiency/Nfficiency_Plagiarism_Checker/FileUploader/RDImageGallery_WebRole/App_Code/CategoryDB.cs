using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

[DataObject(true)]
public static class CategoryDB
{
    public static string inUser_ID;


    public static string getinUser_ID()
    {
        return inUser_ID;
    }

    [DataObjectMethod(DataObjectMethodType.Select)]
    private static string GetConnectionString()
    {
        return ConfigurationManager.ConnectionStrings
            ["accountdbConnectionString"].ConnectionString;
    }

    [DataObjectMethod(DataObjectMethodType.Select)]

    public static string GetCategory()
    {
        Category categoryList = new Category();
        SqlConnection con = new SqlConnection(GetConnectionString());
        string sel = "SELECT User_id, password, first_name, last_name, street, city, state, zip, email "
            + "FROM Customers ORDER BY User_id desc";
        SqlCommand cmd = new SqlCommand(sel, con);
        con.Open();
        SqlDataReader dr = 
            cmd.ExecuteReader(CommandBehavior.CloseConnection);
        Category category;
        while (dr.Read())
        {
            category = new Category();
            category.User_ID = dr["User_ID"].ToString();
            category.Password = dr["Password"].ToString();
            category.First_Name = dr["First_Name"].ToString();
            category.Last_Name = dr["Last_Name"].ToString();
            category.Street = dr["Street"].ToString();
            category.City = dr["City"].ToString();
            category.State = dr["State"].ToString();
            category.Zip = dr["Zip"].ToString();
            category.Email = dr["Email"].ToString();
            inUser_ID = category.User_ID;
        }
        
        dr.Close();
        return inUser_ID;
    }

    public static string returnUser_ID()
    {
        SqlConnection con = new SqlConnection(GetConnectionString());
        string sel = "SELECT top(1) User_id "
            + "FROM Customers Order by user_code desc";
        SqlCommand cmd = new SqlCommand(sel, con);
        con.Open();
        SqlDataReader dr =
            cmd.ExecuteReader(CommandBehavior.CloseConnection);
        // Order order;
        string retOrder_id = "";
        while (dr.Read())
        {
            retOrder_id = dr["User_id"].ToString(); // RETURNING NULL HERE
        }
        dr.Close();
        return retOrder_id;
    }

    [DataObjectMethod(DataObjectMethodType.Insert)]

    public static Category InsertCatigory(Category category)
    {
        SqlConnection con = new SqlConnection(GetConnectionString());
        string ins = "INSERT INTO Customers"
            + " (User_ID,Password, Last_Name, First_Name, Street, City, State, Zip, Email) "
            + " VALUES( @User_ID, @Password, @First_Name, @Last_Name, @Street, @City,@State, @Zip,@Email)";
        SqlCommand cmd = new SqlCommand(ins, con);
        cmd.Parameters.AddWithValue("User_ID", category.User_ID);
        cmd.Parameters.AddWithValue("Password", category.Password);
        cmd.Parameters.AddWithValue("First_Name", category.First_Name);
        cmd.Parameters.AddWithValue("Last_Name", category.Last_Name);
        cmd.Parameters.AddWithValue("Street", category.Street);
        cmd.Parameters.AddWithValue("City", category.City);
        cmd.Parameters.AddWithValue("State", category.State);
        cmd.Parameters.AddWithValue("Zip", category.Zip);
        cmd.Parameters.AddWithValue("Email", category.Email);
        con.Open();
        int i = cmd.ExecuteNonQuery();
        con.Close();  
         return category;
    }

    [DataObjectMethod(DataObjectMethodType.Delete)]

    public static int DeleteCategory(Category category)
    {
        SqlConnection con = new SqlConnection(GetConnectionString());
        string del = "DELETE FROM Customers "
            + "WHERE User_id = @User_id "
            + "AND password = @password "
            + "AND first_name = @first_name "
            + "AND last_name = @last_name ";
        SqlCommand cmd = new SqlCommand(del, con);
        cmd.Parameters.AddWithValue("User_id", category.User_ID);
        cmd.Parameters.AddWithValue("Password", category.Password);
        cmd.Parameters.AddWithValue("first_name", category.First_Name);
        cmd.Parameters.AddWithValue("last_name", category.Last_Name);
        cmd.Parameters.AddWithValue("street", category.Street);
        cmd.Parameters.AddWithValue("city", category.City);
        cmd.Parameters.AddWithValue("state", category.State);
        cmd.Parameters.AddWithValue("zip", category.Zip);
        cmd.Parameters.AddWithValue("email", category.Email);
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
            + "SET User_ID = @User_ID, "
            + "Password = @Password, "
            + "First_Name = @First_Name, "
            + "Last_Name = @Last_Name, "
            + "Street = @Street, "
            + "City = @City, "
            + "State = @State, "
            + "Zip = @Zip "
            + "Email = @Email "
            + "WHERE User_ID = @User_ID "
            + "AND First_Name = @original_First_Name "
            + "AND Last_Name = @original_Last_Name "
            + "AND Street = @original_Street "
            + "AND City = @original_City "
            + "AND State = @original_State "
            + "AND Zip = @original_Zip "
            +"AND Email = @original_Email";
        SqlCommand cmd = new SqlCommand(up, con);
       
        cmd.Parameters.AddWithValue("User_ID", category.User_ID);
        cmd.Parameters.AddWithValue("Password", category.Password);
        cmd.Parameters.AddWithValue("First_Name", category.First_Name);
        cmd.Parameters.AddWithValue("Last_Name", category.Last_Name);
        cmd.Parameters.AddWithValue("Street", category.Street);
        cmd.Parameters.AddWithValue("City", category.City);
        cmd.Parameters.AddWithValue("State", category.State);
        cmd.Parameters.AddWithValue("Zip", category.Zip);
        cmd.Parameters.AddWithValue("Email", category.Email);
        cmd.Parameters.AddWithValue("original_User_ID",original_Category.User_ID);
        cmd.Parameters.AddWithValue("original_Password", original_Category.Password);
        cmd.Parameters.AddWithValue("original_First_Name",original_Category.First_Name);
        cmd.Parameters.AddWithValue("original_Last_Name",original_Category.Last_Name);
        cmd.Parameters.AddWithValue("original_Street", original_Category.Street);
        cmd.Parameters.AddWithValue("original_City", original_Category.City);
        cmd.Parameters.AddWithValue("original_State", original_Category.State);
        cmd.Parameters.AddWithValue("original_Zip", original_Category.Zip);
        cmd.Parameters.AddWithValue("original_Email", original_Category.Email);
        con.Open();
        int updateCount = cmd.ExecuteNonQuery();
        con.Close();
        return updateCount;
    }
}