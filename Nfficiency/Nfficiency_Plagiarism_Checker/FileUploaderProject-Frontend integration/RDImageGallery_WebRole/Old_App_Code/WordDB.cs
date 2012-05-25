using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel;
using System.Collections.Generic;
using System;
namespace RDImageGallery_WebRole.Old_App_Code
{
    [DataObject(true)]
    public static class WordDB
    {

        [DataObjectMethod(DataObjectMethodType.Select)]

        public static List<Word> GetWords()
        {
            List<Word> courseList = new List<Word>();
            SqlConnection con = new SqlConnection(GetConnectionString());
            string sel = "SELECT Id, Value "
                + "FROM Words ORDER BY ID desc";
            SqlCommand cmd = new SqlCommand(sel, con);
            con.Open();
            SqlDataReader dr =
                cmd.ExecuteReader(CommandBehavior.CloseConnection);
            Word word;
            while (dr.Read())
            {
                word = new Word();
                word.Id = Convert.ToInt16(dr["ID"].ToString());
                word.Value = dr["value"].ToString();
                
                courseList.Add(word);
            }
            dr.Close();
            return courseList;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]

        public static string return_CourseID(Word word)
        {
            SqlConnection con = new SqlConnection(GetConnectionString());
            string sel = "SELECT top(1) ID "
                + "FROM Words Order by ID desc";
            SqlCommand cmd = new SqlCommand(sel, con);
            con.Open();
            SqlDataReader dr =
                cmd.ExecuteReader(CommandBehavior.CloseConnection);
            // Order order;
            String retOrder_id = "";
            while (dr.Read())
            {
                retOrder_id = dr["ID"].ToString(); // RETURNING NULL HERE
            }
            dr.Close();
            return retOrder_id;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]

        public static string return_LastCourseID()
        {
            SqlConnection con = new SqlConnection(GetConnectionString());
            string sel = "SELECT top(1) Order_id "
                + "FROM customer_orders Order by customer_order_id desc";
            SqlCommand cmd = new SqlCommand(sel, con);
            con.Open();
            SqlDataReader dr =
                cmd.ExecuteReader(CommandBehavior.CloseConnection);
            // Order order;
            String retLastOrder_id = "";
            while (dr.Read())
            {
                retLastOrder_id = dr["Order_ID"].ToString();
            }
            dr.Close();
            return retLastOrder_id;
        }

        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings
                ["justin_dbConnectionString"].ConnectionString;
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]

        public static int insert_Course(Word word)
        {

            // Set Identity_Insert Orders ON;
            SqlConnection con = new SqlConnection(GetConnectionString());
            string ins = "INSERT INTO Words "
                + " (  Value) "
                + " VALUES(  @value)";
            SqlCommand cmd = new SqlCommand(ins, con);


            //cmd.Parameters.AddWithValue("ID", word.ID);
            cmd.Parameters.AddWithValue("value", word.Value);
           
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();



            return word.Id;

        }

        [DataObjectMethod(DataObjectMethodType.Insert)]

        public static int insert_word(Word word)
        {
            SqlConnection con = new SqlConnection(GetConnectionString());
            string ins = "INSERT INTO Words "
                + " (ID,  Value) "
                + " VALUES( @OID, @value)";
            SqlCommand cmd = new SqlCommand(ins, con);
            cmd.Parameters.AddWithValue("ID", word.Id);
            cmd.Parameters.AddWithValue("value", word.Value);
            
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return word.Id;

        }



        [DataObjectMethod(DataObjectMethodType.Delete)]

        public static int delete_Course(Word word)
        {
            SqlConnection con = new SqlConnection(GetConnectionString());
            string del = "DELETE FROM Words "
                + "WHERE ID = @ID "
                + "AND Value = @value ";
            SqlCommand cmd = new SqlCommand(del, con);
            cmd.Parameters.AddWithValue("ID", word.Id);
            cmd.Parameters.AddWithValue("value", word.Value);
            
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        [DataObjectMethod(DataObjectMethodType.Update)]

        public static int update_Course(Word original_word, Word word)
        {
            SqlConnection con = new SqlConnection(GetConnectionString());
            string up = "UPDATE Words "
                + "SET ID = @ID, "
                + "SET Value = @value, "
                + "Where ID = @origional_ID "
                + "AND Value = @original_value ";
            SqlCommand cmd = new SqlCommand(up, con);


            // cmd.Parameters.AddWithValue("Order_ID", order.Order_ID);
            cmd.Parameters.AddWithValue("ID", word.Id);
            cmd.Parameters.AddWithValue("value", word.Value);
            ///////ORIGINAL PARAMS///////////////////////////////////
            cmd.Parameters.AddWithValue("original_ID", original_word.Id);
            cmd.Parameters.AddWithValue("original_value", original_word.Value);
            
            int updateCount = cmd.ExecuteNonQuery();
            con.Close();
            return updateCount;
        }
    }
}

