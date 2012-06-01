using System;
using System.Collections.Generic;
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
    public partial class frmEnrollUserVarification : System.Web.UI.Page
    {
        String Course_ID; 

        protected void Page_Load(object sender, EventArgs e)
        {
            Course_ID = Request.QueryString["id"];           //row["Customer_id"].ToString();
            if (Course_ID == null)
            { lblError.Text = "ERROR - return to ENROLL USER"; }
          //  lblInfo.Text = Course_ID;
            lblCourse.Text = getCourseName(Course_ID);
        }

        protected void btnEnroll_Click(object sender, EventArgs e)
        {
            String EnrollmentKey; // Pulled from Course table
            String User_ID;
            String eCourse_Name;

            User_ID = User.Identity.Name.ToString();

            lblInfo2.Text = User.Identity.Name.ToString(); // Gets user that is logged in
        //    lblInfo.Text = Course_ID;

            if (ifItemExists(Course_ID, User_ID) == false)
            {
                lblInfo.Text = "Your are allready Enrolled in the Course";
                return;

            }
            // Selects the Course_EnrollmentKey from courses by matching the Course_ID
            string connectionString = ConfigurationManager.ConnectionStrings["justin_dbConnectionString"].ConnectionString;
            string selectSql = "Select Course_EnrollmentKey From Courses Where Course_ID = @courseID";
            lblInfo.Text = selectSql.ToString();
            using (SqlConnection myConnection = new SqlConnection(connectionString))
            {
                myConnection.Open();
                Object returnValue = new Object();
                SqlCommand myCommand = new SqlCommand(selectSql, myConnection);
                myCommand.Parameters.AddWithValue("@courseId", Course_ID);
                returnValue = myCommand.ExecuteScalar();
               // lblInfo.Text = Course_ID;
                EnrollmentKey = returnValue.ToString();
                lblInfo2.Text = EnrollmentKey;
                myConnection.Close();
            }

            // Selects the Course_Name from courses by matching the Course_ID
            string connectionStringCN = ConfigurationManager.ConnectionStrings["justin_dbConnectionString"].ConnectionString;
            string selectSqlCN = "Select Course_Name From Courses Where Course_ID = @courseID";
           using (SqlConnection myConnectionCN = new SqlConnection(connectionString))
            {
                myConnectionCN.Open();
                Object returnValue = new Object();
                SqlCommand myCommand = new SqlCommand(selectSqlCN, myConnectionCN);
                myCommand.Parameters.AddWithValue("@courseId", Course_ID);
                returnValue = myCommand.ExecuteScalar();
                eCourse_Name = returnValue.ToString();
                lblInfo2.Text = EnrollmentKey;
                myConnectionCN.Close();
            }

            //Checking if User is in the Student Role
            if (User.IsInRole("Student"))
            {
                if (EnrollmentKey == txtEnrollKey.Text)
                {
                    insertEnrollment(Course_ID, User_ID, eCourse_Name);
                lblInfo.Text = "YOU WERE SECUSSFULLY ADDED TO THE COURSE";
                lblCourse.Visible = false;
                txtEnrollKey.Visible = false;
                btnCancel.Visible = false;
                btnEnroll.Visible = false;
                }           
                else{lblInfo.Text = " INVALID ENROLLMENT KEY, PLEASE TRY AGAIN"; }
            }
       }

        // If I get here I have allready verified the Course_ID - EnrollmentKey - Loggedin is a Student
        // *** Need to add check if the item allready exists in the Enrollment DB 
            public void insertEnrollment(String inCourse_ID, String inUser_ID, String inECourse_Name)
            {
               
            // Insert a new record into Enrollment
                string connectionString = getConnectionString();
                string insertSql = "INSERT INTO Enrollment(User_ID, Course_ID, eCourse_Name) VALUES(@User_ID, @Course_ID, @eCourse_Name)";

             using (SqlConnection myConnection = new SqlConnection(connectionString))
              {
                 myConnection.Open();
                 SqlCommand myCommand = new SqlCommand(insertSql, myConnection);
                 myCommand.Parameters.AddWithValue("@User_ID", inUser_ID);
                 myCommand.Parameters.AddWithValue("@Course_ID", inCourse_ID);
                 myCommand.Parameters.AddWithValue("@eCourse_Name", inECourse_Name);
                 myCommand.ExecuteNonQuery();
                 myConnection.Close();
              }
        }

            public bool ifItemExists(String inCourse_ID, String inUser_ID)
            {

                int courseID = Convert.ToInt16(inCourse_ID);
                String myCourseName = null;
                SqlConnection con = new SqlConnection(getConnectionString());
                string sel = "SELECT eCourse_Name "
                    + "FROM Enrollment "
                    + "WHERE Course_ID = @Course_ID and User_ID = @User_ID";
                SqlCommand cmd = new SqlCommand(sel, con);
                cmd.Parameters.AddWithValue("Course_ID", inCourse_ID);
                cmd.Parameters.AddWithValue("User_ID", inUser_ID);
                con.Open();
                SqlDataReader dr =
                cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (dr.Read())
                {
                    myCourseName = dr["eCourse_Name"].ToString();
                }
                dr.Close();
                

                if (myCourseName != null)
                    return false;
                else { return true; }
            }

            public string getConnectionString()
            { string connectionString = ConfigurationManager.ConnectionStrings["justin_dbConnectionString"].ConnectionString;
            return connectionString;
            }

        public string getCourseName(string inCourse_ID){
            int Course_ID = Convert.ToInt16(inCourse_ID);
        string connectionStringCN = ConfigurationManager.ConnectionStrings["justin_dbConnectionString"].ConnectionString;
            string selectSqlCN = "Select Course_Name From Courses Where Course_ID = @courseID";
            using (SqlConnection myConnectionCN = new SqlConnection(connectionStringCN))
            {
                myConnectionCN.Open();
                Object returnValue = new Object();
                SqlCommand myCommand = new SqlCommand(selectSqlCN, myConnectionCN);
                myCommand.Parameters.AddWithValue("@courseId", Course_ID);
                returnValue = myCommand.ExecuteScalar();
               string  eCourse_Name = returnValue.ToString();
              //  lblInfo2.Text = EnrollmentKey;
                myConnectionCN.Close();
                return eCourse_Name;
            }
            }

            protected void btnTest_Click(object sender, EventArgs e)
            {
               
               string User_ID = User.Identity.Name.ToString();
                ifItemExists(Course_ID, User_ID);
            }
    }
}