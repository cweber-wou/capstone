using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS430_FinalPractice
{
    public partial class Step1 : System.Web.UI.UserControl
    {
        public delegate void PassSelectedValues(string passPID); //Sets deligate
        public event PassSelectedValues passingPID; //sets event 
        
        protected void Page_Load(object sender, EventArgs e)
        {
         
        }

        //Passed event to parent
        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           lblInfo.Text = ListBox1.SelectedItem.Value;
           string strPassPID = ListBox1.SelectedItem.Value;
           passingPID(strPassPID);
        }

        //Inserts using sqldatasource and controls
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SqlDataSource2.InsertParameters["PID"].DefaultValue = lblInfo.Text;
            SqlDataSource2.InsertParameters["Amount"].DefaultValue = TextBox1.Text;
            SqlDataSource2.Insert();
            Response.AppendHeader("Refresh", "0;URL=Default.aspx");
        }
    }
}