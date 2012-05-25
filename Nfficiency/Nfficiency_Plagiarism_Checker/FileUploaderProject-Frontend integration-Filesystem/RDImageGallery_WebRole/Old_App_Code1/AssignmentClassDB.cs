using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel;
using System.Collections.Generic;
using System;

[DataObject(true)]
    public class AssignmentClassDB
    {

        [DataObjectMethod(DataObjectMethodType.Select)]
            public static List<AssignmentClass> GetProduct()
        {
            List<AssignmentClass> productList = new List<AssignmentClass>();
            SqlConnection con = new SqlConnection(GetConnectionString());
            string sel = "SELECT aGUID, Course_ID, Assignment_ID "
                + "FROM Assignments ORDER BY Course_ID desc";
            SqlCommand cmd = new SqlCommand(sel, con);
            con.Open();
            SqlDataReader dr =
                cmd.ExecuteReader(CommandBehavior.CloseConnection);
            AssignmentClass product;
            while (dr.Read())
            {
                product = new AssignmentClass();
                product.aGUID= dr["aGUID"].ToString();
                product.Course_id = dr["Course_ID"].ToString();
                product.assignmentNumber = dr["Assignment_ID"].ToString();
                productList.Add(product);
            }
            dr.Close();
            return productList;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<AssignmentClass> GetProductCID(string inCID)
        {
            List<AssignmentClass> productList = new List<AssignmentClass>();
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
            AssignmentClass product;
            while (dr.Read())
            {
                product = new AssignmentClass();
                product.aGUID = dr["aGUID"].ToString();
                product.Course_id = dr["Course_ID"].ToString();
                product.assignmentNumber = dr["Assignment_ID"].ToString();
                product.descripton = dr["Description"].ToString();
                productList.Add(product);
            }
            dr.Close();
            return productList;
        }

        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings
                ["Nfficiency_dbConnectionString"].ConnectionString;
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]

        public static int InsertOrder(AssignmentClass product)
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

        public static int DeleteOrder(AssignmentClass product)
        {
            SqlConnection con = new SqlConnection(GetConnectionString());
            string del = "DELETE FROM Assignments "
                + "WHERE aGUID = @aGUID";
               
            SqlCommand cmd = new SqlCommand(del, con);
            cmd.Parameters.AddWithValue("aGUID",product.aGUID);
            cmd.Parameters.AddWithValue("Course_ID", product.Course_id);
            cmd.Parameters.AddWithValue("Assignment_ID", product.assignmentNumber);
            cmd.Parameters.AddWithValue("Description", product.descripton);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        [DataObjectMethod(DataObjectMethodType.Update)]

        public static int UpdateOrder(AssignmentClass original_Product, AssignmentClass product)
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
