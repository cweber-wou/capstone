using System;
using System.Collections.Generic;
using System.Web.Security;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;
using System.Data;


namespace CS430_ASPNET_Role_Records.User_Mng
{
    public partial class frmEnrollUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String user_ID;
            String Course_ID;
            String eCourse_Name;

            user_ID = User.Identity.Name.ToString();
            lblInfo.Text = User.Identity.Name.ToString(); // Gets user that is logged in
            GridViewRow row = GridView1.SelectedRow;

            Course_ID = (row.Cells[1].Text); //Gets the Course_id of the selected item and stores in variable
            lblInfo2.Text = Course_ID;

            eCourse_Name = (row.Cells[2].Text); //Gets the eCourse_Name of the selected item and stores in variable
            lblInfo2.Text = eCourse_Name;
            // Selects the Course_EnrollmentKey from courses by matching the Course_ID
            string connectionString = ConfigurationManager.ConnectionStrings["Nfficiency_dbConnectionString"].ConnectionString;
            string selectSql = "Select Course_EnrollmentKey From Courses Where Course_ID = @courseID";
            lblInfo.Text = selectSql.ToString();
            using (SqlConnection myConnection = new SqlConnection(connectionString))
            {
                myConnection.Open();
                Object returnValue = new Object();
                SqlCommand myCommand = new SqlCommand(selectSql, myConnection);
                myCommand.Parameters.AddWithValue("@courseId", Course_ID);
                myCommand.Parameters.AddWithValue("@eCourse_Name", eCourse_Name);

                returnValue = myCommand.ExecuteScalar();
        //        lblInfo.Text = Course_ID;
                
                    
                myConnection.Close();
            }
            Response.Redirect("frmEnrollUserVarification.aspx?id=" + Course_ID); 
                // Insert a new record into UserProfiles
                // string connectionString = ConfigurationManager.ConnectionStrings["SecurityTutorialsConnectionString"].ConnectionString;
                // string insertSql = "INSERT INTO UserProfiles(UserId, HomeTown, HomepageUrl, Signature) VALUES(@UserId, @HomeTown, @HomepageUrl, @Signature)";

                //  using (SqlConnection myConnection = new SqlConnection(connectionString))
                //  {

                //     myConnection.Open();

                //     SqlCommand myCommand = new SqlCommand(insertSql, myConnection);
                //      myCommand.Parameters.AddWithValue("@UserId", user_ID);
                //      myCommand.Parameters.AddWithValue("@HomeTown", DBNull.Value);
                //      myCommand.Parameters.AddWithValue("@HomepageUrl", DBNull.Value);
                //      myCommand.Parameters.AddWithValue("@Signature", DBNull.Value);

                //      myCommand.ExecuteNonQuery();

                //      myConnection.Close();
                //  }
            }
        }
    }
