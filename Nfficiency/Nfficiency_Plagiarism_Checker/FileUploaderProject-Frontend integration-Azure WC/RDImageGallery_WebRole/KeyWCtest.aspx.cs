using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RDImageGallery_WebRole.Old_App_Code;


namespace RDImageGallery_WebRole
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private Tester test = new Tester();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Dictionary<string, int> data;
            //LinkedList<string> list= new LinkedList<string>();
            //list.AddLast("This is a test of my key word search here are a few words that I test for for foreach void while while while while void");
            //list.AddLast("This is a test of my key word search here are a few words that I test for for foreach void while while while while void");
            //list.AddLast("This is a test of my key word search here are a few words that I test for for foreach void while while while while void");
            //data = keywc.count(list);
            //ListView1.DataSource=data;
            //ListView1.DataBind();
        
            String s = Request.QueryString["aGUID"];
            test.Type = 2;
            test.run(s);
            
            
                Table table1 = new Table();
                table1.ID = "itemPlaceholderContainer";
                table1.Attributes.Add("border", "1");
                table1.Attributes.Add("style", "background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;");
                

                
                TableHeaderRow Header = new TableHeaderRow();
                Header.Attributes.Add("runat", "server");
                Header.Attributes.Add("style", "background-color:#DCDCDC;color: #000000;");
                
                int z = 0;
                TableHeaderCell name = new TableHeaderCell();
                z++;
                name.Text = "UserID";
                name.ID = "HeaderCell" + z;
                name.Attributes.Add("runat", "server");
                Header.Controls.Add(name);
                z++;
                name = new TableHeaderCell();
                name.Text = "File Name";
                name.ID = "HeaderCell" + z;
                name.Attributes.Add("runat", "server");
                Header.Controls.Add(name);
                z++;
                name = new TableHeaderCell();
                name.Text = "Test Type";
                name.ID = "HeaderCell" + z;
                name.Attributes.Add("runat", "server");
                Header.Controls.Add(name);
                z++;
                name = new TableHeaderCell();
                name.Text = "UUID";
                name.Attributes.Add("runat", "server");
                name.ID = "HeaderCell" + z;
                Header.Controls.Add(name);
                z++;
                name = new TableHeaderCell();
                name.Text = "WC";
                name.Attributes.Add("runat", "server");
                name.ID = "HeaderCell" + z;
                Header.Controls.Add(name);
                foreach (string hitem in test.getReports().First.Value.KeyData.Keys)
                {
                    z++;
                    name = new TableHeaderCell();
                    name.Attributes.Add("runat", "server");
                    name.Text = hitem;
                    name.ID = "HeaderCell" + z;
                    Header.Controls.Add(name);
                }
                table1.Controls.Add(Header);
                z = 0;
                foreach (Report report in test.getReports())
                {
                    z++;
                    TableRow item = new TableRow();
                    item.ID = "row"+z;
                    item.Attributes.Add("runat", "server");
                    int i = 0;
                    TableCell cell = new TableCell();
                    cell.Text=report.Aid;
                    i++;
                    cell.ID = "cell" + z.ToString() + i;
                    cell.Attributes.Add("runat", "server");
                    item.Controls.Add(cell);
                    cell = new TableCell();
                    i++;
                    cell.ID = "cell" + z.ToString() + i;
                    cell.Attributes.Add("runat", "server");
                    cell.Text = report.UserID;
                    item.Controls.Add(cell);
                    cell = new TableCell();
                    i++;
                    cell.ID = "cell" + z.ToString() + i;
                    cell.Attributes.Add("runat", "server");
                    cell.Text = report.TypeID.ToString();
                    item.Controls.Add(cell);
                    cell = new TableCell();
                    i++;
                    cell.ID = "cell" + z.ToString() + i;
                    cell.Attributes.Add("runat", "server");
                    
                    HyperLink UUID = new HyperLink();
                    UUID.Text = "Download";
                    UUID.NavigateUrl = "~/";
                    cell.Controls.Add(UUID);
                    item.Controls.Add(cell);
                    cell = new TableCell();
                    i++;
                    cell.ID = "cell" + z.ToString() + i;
                    cell.Attributes.Add("runat", "server");
                    cell.Text = report.TestID.ToString();
                    item.Controls.Add(cell);
                    foreach (int value in report.KeyData.Values)
                    {
                        i++;
                        cell = new TableCell();
                        cell.Text = value.ToString();
                        cell.ID = "cell" + z.ToString() + i;
                        cell.Attributes.Add("runat", "server");
                        item.Controls.Add(cell);
                    }
                    table1.Controls.Add(item);
                }

                mine.Controls.Add(table1);
                    
            //ListView1.DataSource = test.getReports();
            //int x=0;
            //foreach (string h in test.getReports().First.Value.KeyData.Keys)
            //{
            //    x++;
            //    TableHeaderCell name = new TableHeaderCell();
            //    name.Text = h;
            //    name.ID = "HeaderCell" + x;
                
            //}
                
            
            //ListView1.Sort("TestID", SortDirection.Ascending);
            //ListView1.DataBind();
        }
    }
}