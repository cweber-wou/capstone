using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace backend
{
    public partial class blank : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Tester test = new Tester();
            test.run();
            LinkedListNode<Report> report= test.Reports.First;
            while (report != null)
            {
                String o = report.Value.ToString();
                String[] f = o.Split('|');
                TableRow r = new TableRow();

                foreach (String n in f)
                    {
                    
                    
                            TableCell c = new TableCell();
                            c.Controls.Add(new LiteralControl(n));
                            r.Cells.Add(c);
                        
                        
                    }
                tblOut.Rows.Add(r);
                

                report = report.Next;
            }
        }
    }
}