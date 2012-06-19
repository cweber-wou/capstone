using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS430_ASPNET_Role_Records
{
    public partial class insAddCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DetailsViewRow row = DetailsView2.Rows[4]; // third row
            TextBox myTextBox = (TextBox)row.Cells[1].Controls[0]; // text box in second cell
            myTextBox.Text = User.Identity.Name; 

        }

        public void DetailsView1_ItemInserted1(object sender, DetailsViewInsertedEventArgs e)
        {
                  
            if (e.Exception != null)
            {
                lblError.Text = "A database error has occurred.<br /><br />" +
                    e.Exception.Message;
                if (e.Exception.InnerException != null)
                    lblError.Text += "<br />Message: "
                        + e.Exception.InnerException.Message;
                e.ExceptionHandled = true;
                
                
            }
            lblStatus.Visible = true;
            lblStatus.Text = "You Have secussfully added the Course";
            Response.Redirect("~/Default.aspx");
        }

    

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }
    }
}