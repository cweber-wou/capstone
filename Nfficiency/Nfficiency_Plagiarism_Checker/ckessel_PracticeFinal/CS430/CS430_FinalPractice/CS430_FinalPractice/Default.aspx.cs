using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS430_FinalPractice
{
    public partial class _Default : System.Web.UI.Page
    {
        int controlOrder;
        ContentPlaceHolder cph;
        UserControl uc;
         public string varPassPID;

        public string VarPassPID
        {
            set {varPassPID = value;}
            get { return varPassPID;}
        }

        //Dynamically loads controls
        protected override void OnPreInit(EventArgs e)
        {
            if (!IsPostBack)
            {
                controlOrder = Convert.ToInt32(Request.QueryString["id"]);
            }
            else
                controlOrder = 0;

           
            if (controlOrder == 0)
            {
                Control control = LoadControl("Step1.ascx");
                Control control1 = LoadControl("Step2.ascx");
                Control control2 = LoadControl("Step3.ascx");

                Control placeHolderControl = Page.FindControl("ContentPlaceHolder1");
                Control placeHolderControl1 = Page.FindControl("ContentPlaceHolder2");
                Control placeHolderControl2 = Page.FindControl("ContentPlaceHolder3");

                Step1 ctrl = (Step1)LoadControl("Step1.ascx");
                ctrl.passingPID += new Step1.PassSelectedValues(passValuesHandlerMethod);//Magic line

                if (placeHolderControl != null)
                {
                    placeHolderControl.Controls.Add(control);
                    placeHolderControl.Controls.Add(control1);
                    placeHolderControl2.Controls.Add(control2);
                }
                else
                {
                    MasterPage theMaster = Page.Master;
                    while (theMaster != null)
                    {
                        placeHolderControl = theMaster.FindControl("ContentPlaceHolder1");
                        placeHolderControl1 = theMaster.FindControl("ContentPlaceHolder2");
                        placeHolderControl2 = theMaster.FindControl("ContentPlaceHolder3");
                        if (placeHolderControl != null)
                        {
                            placeHolderControl.Controls.Add(ctrl);
                            placeHolderControl1.Controls.Add(control1);
                            placeHolderControl2.Controls.Add(control2);
                            break;
                        }
                        theMaster = theMaster.Master;
                    }
                }
            }
            if (controlOrder == 1)
            {
                
                Control control = LoadControl("Step1.ascx");
                Control control1 = LoadControl("Step2.ascx");
                Control control2 = LoadControl("Step3.ascx");
                Control placeHolderControl = Page.FindControl("ContentPlaceHolder1");
                Control placeHolderControl1 = Page.FindControl("ContentPlaceHolder2");
                Control placeHolderControl2 = Page.FindControl("ContentPlaceHolder3");

                Step1 ctrl = (Step1)LoadControl("Step1.ascx");
                ctrl.passingPID += new Step1.PassSelectedValues(passValuesHandlerMethod);//Magic line

                if (placeHolderControl != null)
                {
                    placeHolderControl.Controls.Add(control);
                    placeHolderControl.Controls.Add(control1);
                    placeHolderControl2.Controls.Add(control2);
                }
                else
                {
                    MasterPage theMaster = Page.Master;
                    while (theMaster != null)
                    {
                        placeHolderControl1 = theMaster.FindControl("ContentPlaceHolder1");
                        placeHolderControl = theMaster.FindControl("ContentPlaceHolder2");
                        placeHolderControl2 = theMaster.FindControl("ContentPlaceHolder3");
                        if (placeHolderControl != null)
                        {
                            placeHolderControl.Controls.Add(ctrl);
                            placeHolderControl1.Controls.Add(control1);
                            placeHolderControl2.Controls.Add(control2);
                            break;
                        }
                        theMaster = theMaster.Master;
                    }
                }
            }

        }//End Method
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblInfo.Text = "0";
                             
            }
            if (IsPostBack) { 
                controlOrder = Convert.ToInt32(Request.QueryString["id"]);
                
            }
          
        }

        //This intercepts the event handler from the UserControl
        protected void passValuesHandlerMethod(string pramSelPID)
        {
            VarPassPID = pramSelPID;
            lblInfo.Text = VarPassPID.ToString();
        }

        protected void addUserControl()
        {
                       
        }

        protected void tnUsrCont_Click(object sender, EventArgs e)
        {
             cph = this.Master.FindControl("ContentPlaceHolder1") as ContentPlaceHolder;
            uc = this.LoadControl("Step1.ascx") as UserControl;
            uc.Attributes.Add("runat", "server");
            cph.Controls.Add(uc);
         
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx?id=" + RadioButtonList1.SelectedValue.ToString());
        }

       

    }
}
