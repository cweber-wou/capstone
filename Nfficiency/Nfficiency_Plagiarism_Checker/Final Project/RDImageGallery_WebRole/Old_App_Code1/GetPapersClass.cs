using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

using System.Collections.Specialized;
using System.Configuration;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Collections;




namespace RDImageGallery_WebRole.Old_App_Code1
{
    public class GetPapersClass
    {
        public DataSet ToDataSetImage1(LinkedList<Paper> list)
        {
            Type elementType = typeof(Paper);
            DataSet ds = new DataSet();
            DataTable t = new DataTable();
            ds.Tables.Add(t);
            var g = typeof(Paper).GetProperties();
            t.Columns.Add("txtFileName");
            //add a column to table for each public property on T
            //go through each property on T and add each value to the table
            foreach (Paper item in list)
            {
                DataRow row = t.NewRow();
                row[0] = item.FileName.ToString();
                t.Rows.Add(row);
            }
            return ds;
        }

        public DataSet ToDataSet1(LinkedList<Paper> list)
        {
            Type elementType = typeof(Paper);
            DataSet ds = new DataSet();
            DataTable t = new DataTable();
            ds.Tables.Add(t);
            var g = typeof(Paper).GetProperties();
            t.Columns.Add("AID");
            t.Columns.Add("UserID");
            t.Columns.Add("txtFileName");
            t.Columns.Add("Link");

            //go through each property on T and add each value to the table
            foreach (Paper item in list)
            {
                DataRow row = t.NewRow();

                row[0] = item.AID.ToString();
                row[1] = item.UserID.ToString();
                row[2] = item.FileName.ToString();
                row[3] = item.Link.ToString();


                //This line was missing:
                t.Rows.Add(row);
            }
            return ds;
        }

        //Returns the directory of the assignment
        public string GetContainer(String aGUID, String Course_ID)
        {
            string activeDir = Path.GetPathRoot(Directory.GetCurrentDirectory());
            activeDir = Path.Combine(activeDir, "FileRepository");
            activeDir = Path.Combine(activeDir, Course_ID);
            activeDir = Path.Combine(activeDir, aGUID);
            return activeDir;

        }

        //Takes the path of the directory, converts to LL<str> of files
        //Converts to LL of papers
        //Returns LL<papers>
        //Don't want to pull in data here due to overhead
        public LinkedList<Paper> pathToPapers(string path, string aGUID)
        {
            LinkedList<string> allFiles = new LinkedList<string>();
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(path);
            foreach (System.IO.FileInfo f in dir.GetFiles("*.*"))
            {
                allFiles.AddFirst(f.Name);
            }
            LinkedList<Paper> allPapers = new LinkedList<Paper>();
            foreach (string p in allFiles)
            {
                Paper paper = new Paper();
                paper.AID = aGUID.ToString();
                string fullPath = Path.Combine(path, p);
                paper.Link = fullPath.ToString();
                string truUserID = Path.GetFileNameWithoutExtension(p);//parsed filename without extension
                paper.UserID = truUserID.ToString();

                paper.FileName = p.ToString();
                allPapers.AddFirst(paper);
            }
            return allPapers;
        }




        }//End Class
   
}//End NameSpace