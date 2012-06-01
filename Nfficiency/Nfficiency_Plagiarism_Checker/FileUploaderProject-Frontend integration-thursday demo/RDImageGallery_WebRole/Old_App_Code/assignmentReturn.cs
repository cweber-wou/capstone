//*************************************************
//   Called using the following instance....... 
//
//   protected void btnProcess_Click(object sender, EventArgs e)
//    {
//        assignmentReturn ar = new assignmentReturn();
//        LinkedList<Paper> pa = new LinkedList<Paper>();
//        pa = ar.getAssignmentList();
//
//        for (int i = 0; i < pa.Count; i++)
//            txtOut.Text = pa.First.Value.Data.First.Value.ToString();
//    }
//



using System;
    using System.Collections.Specialized;
    using System.Configuration;
    using System.Linq;
    using System.Web.UI.WebControls;
    using System.ComponentModel;
    using System.IO;
    using System.Windows.Forms;
    using System.Collections.Generic;

namespace RDImageGallery_WebRole.Old_App_Code
{
    public class assignmentReturn
    {

        public LinkedList<Paper> getAssignmentList()
        { LinkedList<Paper> emptyPapers = new LinkedList<Paper>();
        return emptyPapers;
        }

        //****************************************************************************
        //
        // Default getAssignmentList
        // Takes aGUID as paramiter
        // Uses returnAGuidPath(inAGuid) to locate the full path to the assignment
        // Uses pathToPapers(aGUID) to get all the submitted assignments   
        // Loads the Paper object data LL with a parsed LL of Strings
        // Returns the LL of Paper obj.
        //
        //****************************************************************************
        public LinkedList<Paper> getAssignmentList(string inAGuid)
        {
            string path = string.Empty;
            LinkedList<Paper> files = new LinkedList<Paper>();

            path = returnAGuidPath(inAGuid); // Gets the path of the aGUID

            files = pathToPapers(path.ToString(), inAGuid.ToString()); // Returns LL<Papers>
            foreach (Paper p in files)
            {
                p.Data = new LinkedList<string>();
                string fileString = File.ReadAllText(p.Link); //gets the file as a byte[] by the file's link
                string[] lines = fileString.Split(new string[] { Environment.NewLine }, StringSplitOptions.None); //Splits file up by '\n'
                for (int i = 0; i < lines.Length; i++)
                    p.Data.AddLast(lines[i].ToString());

            }
            return files;

        }

        //****************************************************************************
        //
        //Converts to LL of papers
        //Returns LL<papers>
        //Don't want to pull in data here due to overhead
        //
        //****************************************************************************
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

        //****************************************************************************
        //
        // Takes aGUID as a paramiter
        // Gets the default directory ##NEED getActiveDir method to get universal path
        // Searches the default directory and subdirectories for the aGUID directory
        // Returns the path of the aGUID
        //
        //****************************************************************************
        public string returnAGuidPath(string inAGUID)
        {
            string pathOfAGUID = string.Empty;
            string activeDir = Path.GetPathRoot(Directory.GetCurrentDirectory());
            activeDir = Path.Combine(activeDir, "FileRepository");
            string[] files = Directory.GetDirectories(activeDir, inAGUID, SearchOption.AllDirectories); //Gets the directory starting at activeDir, and searches for inAGUID

            try
            {
                pathOfAGUID = files[0].ToString();
            }
            catch (Exception)
            {
                pathOfAGUID = "File Not Found: getCourseID_AGUID(string inAGUID)";

            }
            return pathOfAGUID;
        }
    }//End Class
}//End Name Space
