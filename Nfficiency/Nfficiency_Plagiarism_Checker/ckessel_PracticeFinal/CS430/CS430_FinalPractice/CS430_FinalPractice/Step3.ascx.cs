using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS430_FinalPractice
{
    public partial class Step3 : System.Web.UI.UserControl
    {
       protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Local 
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedIndex == 0)
            { 
                int input = Convert.ToInt32(txtInput.Text.ToString());
                txtOutput.Text = (input / 1532).ToString();
            }

            if (RadioButtonList1.SelectedIndex == 1)
            {
                int input = Convert.ToInt32(txtInput.Text.ToString());
                txtOutput.Text = (input * 1532).ToString();
            
            } 
                     }

        //WCF Calls 
        // Use default name when adding the service reference, and just change stuff in here
        protected void btnWCF_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client client = new
        ServiceReference1.Service1Client();
            int returnString;

            if (RadioButtonList1.SelectedIndex == 0)
            {
                returnString = client.dollars2Dublons(Convert.ToInt32(txtInput.Text.ToString()));
           txtOutput.Text = returnString.ToString();
            }

            if (RadioButtonList1.SelectedIndex == 1)
            {
                returnString = client.dublons2Dollars(Convert.ToInt32(txtInput.Text.ToString()));
                txtOutput.Text = returnString.ToString();

            } 
        }
    }
}
    
