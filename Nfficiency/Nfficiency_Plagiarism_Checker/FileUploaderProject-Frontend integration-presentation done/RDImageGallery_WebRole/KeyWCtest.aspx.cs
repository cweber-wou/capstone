﻿using System;
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
            
        
            String s = Request.QueryString["aGUID"];
            test.Type = 2;
            test.run(s);
            
            
                Table table1 = new Table();
                table1.ID = "itemPlaceholderContainer";
                table1.Attributes.Add("border", "1");
                table1.Attributes.Add("style", "width:3500pt; background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;");
                

                
                TableHeaderRow Header = new TableHeaderRow();
                Header.Attributes.Add("runat", "server");
                Header.Attributes.Add("style", "background-color:#DCDCDC;color: #000000;");
                
                int z = 0;
                TableHeaderCell name = new TableHeaderCell();
                z++;
                name = new TableHeaderCell();
                name.Text = "UserID";
                name.ID = "HeaderCell" + z;
                name.Attributes.Add("runat", "server");
                Header.Controls.Add(name);
                z++;
                name = new TableHeaderCell();
                name.Text = "Word Count";
                name.Attributes.Add("runat", "server");
                name.ID = "HeaderCell" + z;
                Header.Controls.Add(name);
                z++;
                
                foreach (string hitem in test.getReports().First.Value.KeyData.Keys)
                {
                    if (hitem != "WC")
                    {
                        z++;
                        name = new TableHeaderCell();
                        name.Attributes.Add("runat", "server");
                        name.Text = hitem;

                        name.ID = "HeaderCell" + z;
                        Header.Controls.Add(name);
                    }
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
                    i++;
                    cell.ID = "cell" + z.ToString() + i;
                    cell.Attributes.Add("runat", "server");
                    cell.Text = report.UserID;
                    item.Controls.Add(cell);

                    int wc;
                    while (!(report.KeyData.TryRemove("WC",out wc)));
                    
                    cell = new TableCell();
                    i++;
                    cell.ID = "cell" + z.ToString() + i;
                    cell.Attributes.Add("runat", "server");
                    cell.Text = wc.ToString();
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

                int n = 0;
                foreach (Report a in test.getReports())
                {
                    table1 = new Table();
                    table1.ID = "itemPlaceholderContainer"+n.ToString();             
                    table1.Attributes.Add("border", "1");
                    table1.Attributes.Add("style", "width:300pt;background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;");
                    Header = new TableHeaderRow();
                    Header.Attributes.Add("runat", "server");
                    Header.Attributes.Add("style", "background-color:#DCDCDC;color: #000000;");
                    z = 0;
                    name = new TableHeaderCell();
                    z++;
                    name.Text = "compared";
                    name.ID = "HeaderCell" + z;
                    name.Attributes.Add("runat", "server");
                    Header.Controls.Add(name);
                    
                    
                    
                        z++;
                        name = new TableHeaderCell();
                        name.Attributes.Add("runat", "server");
                        name.Text = "Total";
                        name.ID = "HeaderCell" + z;
                        Header.Controls.Add(name);
                   
                    table1.Controls.Add(Header);
                    foreach (Compare b in a.Compared)
                    {
                        z++;
                        TableRow item = new TableRow();
                    item.ID = "row"+z;
                    item.Attributes.Add("runat", "server");
                    int i = 0;
                    TableCell cell = new TableCell();
                    cell.Text=b.Key;
                    i++;
                    cell.ID = "cell" + z.ToString() + i;
                    cell.Attributes.Add("runat", "server");
                    item.Controls.Add(cell);


                    int value;
                    while (!(b.Data.TryGetValue("Total", out value))) ;
                        i++;
                        cell = new TableCell();
                        cell.Text = value.ToString();
                        cell.ID = "cell" + z.ToString() + i;
                        cell.Attributes.Add("runat", "server");
                        item.Controls.Add(cell);
                            
                        
                        table1.Controls.Add(item);
                    }
                    mine.Controls.Add(table1);
                    n++;
                }
                    
            
        }
    }
}