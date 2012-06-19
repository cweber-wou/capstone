using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS430_FinalPractice
{
    public partial class Step2 : System.Web.UI.UserControl
    {
        
        public string DatatoShare{get;set;}
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.AppendHeader("Refresh", "0;URL=Default.aspx");
        }




    }
}