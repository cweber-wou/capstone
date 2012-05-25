using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace NfficiencyPD.Old_App_Code1
{
    public class CreateFileOrFolder
    {
        public static void createRepoDir(){
            // Specify a "currently active folder"
            //string activeDir = Directory.GetCurrentDirectory();//@".";
            string activeDir = Path.GetPathRoot(Directory.GetCurrentDirectory());
            //Create a new subfolder under the current active folder
            string newPath = System.IO.Path.Combine(activeDir, "FileRepository");
            //Checks if the directory exists, if it dosn't then it makes it
            DirectoryInfo dir = new DirectoryInfo(activeDir);
            if (!dir.Exists)
            {
            dir.Create();
            }
            else
            // Create the subfolder under activeDir
            System.IO.Directory.CreateDirectory(newPath);
      }//End createRepoDir

        public static void createDir1(string inActiveDir, string inDir)
        {
            // Specify a "currently active folder"
            //string activeDir = Directory.GetCurrentDirectory();//@".";
            string activeDir = inActiveDir;
            //Create a new subfolder under the current active folder
            string newPath = System.IO.Path.Combine(activeDir, inDir);
            //Checks if the directory exists, if it dosn't then it makes it
            DirectoryInfo dir = new DirectoryInfo(activeDir);
            if (!dir.Exists)
            {
                dir.Create();
            }
            else
                // Create the subfolder under activeDir
                System.IO.Directory.CreateDirectory(newPath);


        }//End createRepoDir

        //gets the active directory c:\FileRepository\aGUID
        public static string getActiveDir(string aGUID)
        {
            string activeDir = Path.GetPathRoot(Directory.GetCurrentDirectory());
            activeDir = Path.Combine(activeDir, "FileRepository");
            activeDir = Path.Combine(activeDir, aGUID);
            return activeDir;
        }

        //No Param get active directory
        public static string getActiveDir()
        {
            string activeDir = Path.GetPathRoot(Directory.GetCurrentDirectory());
            activeDir = Path.Combine(activeDir, "FileRepository");
            return activeDir;
        }

        
    } 
}
