using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel;
using System.Collections.Generic;
using System;

[DataObject(true)]
    public class ProductDB
    {

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Product> GetProduct()
        {
            List<Product> productList = new List<Product>();
            SqlConnection con = new SqlConnection(GetConnectionString());
            string sel = "SELECT aGUID, Course_ID, Assignment_ID "
                + "FROM Assignments ORDER BY Course_ID desc";
            SqlCommand cmd = new SqlCommand(sel, con);
            con.Open();
            SqlDataReader dr =
                cmd.ExecuteReader(CommandBehavior.CloseConnection);
            Product product;
            while (dr.Read())
            {
                product = new Product();
                product.aGUID = dr["aGUID"].ToString();
                product.Course_id = dr["Course_ID"].ToString();
                product.assignmentNumber = dr["Assignment_ID"].ToString();
                product.descripton = dr["Description"].ToString();
                productList.Add(product);
            }
            dr.Close();
            return productList;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Product> GetProductCID(string inCID)
        {
            List<Product> productList = new List<Product>();
            SqlConnection con = new SqlConnection(GetConnectionString());
            string sel = "SELECT aGUID, Course_ID, Assignment_ID, Description "
                + "FROM Assignments "
                + "WHERE Course_ID = @inCID "
                + "ORDER BY Course_ID desc";
            SqlCommand cmd = new SqlCommand(sel, con);
            cmd.Parameters.AddWithValue("inCID", inCID);
            con.Open();
            SqlDataReader dr =
                cmd.ExecuteReader(CommandBehavior.CloseConnection);
            Product product;
            while (dr.Read())
            {
                product = new Product();
                product.aGUID = dr["aGUID"].ToString();
                product.Course_id = dr["Course_ID"].ToString();
                product.assignmentNumber = dr["Assignment_ID"].ToString();
                product.descripton = dr["Description"].ToString();
                productList.Add(product);
            }
            dr.Close();
            return productList;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<string> GetAGUID_CID(string inCID)
        {
            List<string> productList = new List<string>();
            SqlConnection con = new SqlConnection(GetConnectionString());
            string sel = "SELECT aGUID "
                + "FROM Assignments "
                + "WHERE Course_ID = @inCID "
                + "ORDER BY Course_ID desc";
            SqlCommand cmd = new SqlCommand(sel, con);
            cmd.Parameters.AddWithValue("inCID", inCID);
            con.Open();
            SqlDataReader dr =
                cmd.ExecuteReader(CommandBehavior.CloseConnection);
            Product product;
            while (dr.Read())
            {
                product = new Product();
                product.aGUID = dr["aGUID"].ToString();
                productList.Add(product.aGUID.ToString());
            }
            dr.Close();
            return productList;
        }

        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings
                ["justin_dbConnectionString"].ConnectionString;
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]

        public static int InsertOrder(Product product)
        {
            SqlConnection con = new SqlConnection(GetConnectionString());
            string ins = "INSERT INTO Assignments"
                + " (aGUID, Course_ID, Assignment_ID, Description) "
                + " VALUES( @aGUID, @Course_ID, @Assignment_ID, @Description)";
            SqlCommand cmd = new SqlCommand(ins, con);

            cmd.Parameters.AddWithValue("aGUID", product.aGUID);
            cmd.Parameters.AddWithValue("Course_ID", product.Course_id);
            cmd.Parameters.AddWithValue("Assignment_ID", product.assignmentNumber);
            cmd.Parameters.AddWithValue("Description", product.descripton);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;

        }

        [DataObjectMethod(DataObjectMethodType.Delete)]

        public static int DeleteOrder(Product product)
        {
            SqlConnection con = new SqlConnection(GetConnectionString());
            string del = "DELETE FROM Assignments "
                + "WHERE aGUID = @aGUID";

            SqlCommand cmd = new SqlCommand(del, con);
            cmd.Parameters.AddWithValue("aGUID", product.aGUID);
            cmd.Parameters.AddWithValue("Course_ID", product.Course_id);
            cmd.Parameters.AddWithValue("Assignment_ID", product.assignmentNumber);
            cmd.Parameters.AddWithValue("Description", product.descripton);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        [DataObjectMethod(DataObjectMethodType.Update)]

        public static int UpdateOrder(Product original_Product, Product product)
        {
            SqlConnection con = new SqlConnection(GetConnectionString());
            string up = "UPDATE Assignments "
                + "SET aGUID = @, "
                + "WHERE aGUID = @original_aGUID ";
            SqlCommand cmd = new SqlCommand(up, con);

            cmd.Parameters.AddWithValue("aGUID", product.aGUID);
            cmd.Parameters.AddWithValue("Course_ID", product.Course_id);
            cmd.Parameters.AddWithValue("Assignment_ID", product.assignmentNumber);
            cmd.Parameters.AddWithValue("Description", product.descripton);

            cmd.Parameters.AddWithValue("origional_aGUID", original_Product.aGUID);
            cmd.Parameters.AddWithValue("original_Course_ID", original_Product.Course_id);
            cmd.Parameters.AddWithValue("original_Assignment_ID", original_Product.assignmentNumber);
            cmd.Parameters.AddWithValue("original_Description", original_Product.descripton);
            con.Open();
            int updateCount = cmd.ExecuteNonQuery();
            con.Close();
            return updateCount;
        }
    }
