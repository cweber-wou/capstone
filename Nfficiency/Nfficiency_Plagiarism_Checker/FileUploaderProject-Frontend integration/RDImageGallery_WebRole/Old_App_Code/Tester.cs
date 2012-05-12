using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.StorageClient;
using Microsoft.WindowsAzure.StorageClient.Protocol;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace RDImageGallery_WebRole.Old_App_Code
{
    public class Tester
    {
        private int type = 0; // The type of test to be prefromed
        private String aID; // Assignment ID
        private int tested; // Number of assignments tested
        private LinkedList<Report> reports; // Linked List of the reports 

        // Get and set
        public int Type { get { return type; } set { type = value; } }
        public String AID { get { return aID; } set { aID = value; } }

        //Get
        public int Tested { get { return tested; } }
        public LinkedList<Report> Reports { get { return reports; } }

        public Tester()
        {
            this.tested = 0;
            this.reports = new LinkedList<Report>();
        } // Blank constructor

        // constructor with the test type and Assignment already set
        public Tester(int type, string aID)
        {
            this.aID = aID;
            this.type = type;
            this.tested = 0;
            this.reports = new LinkedList<Report>();
        }
        public void testInit()
        {
            type = 1;
            string c;
            LinkedList<string> input = new LinkedList<string>();
            c = "this is a test";
            input.AddFirst(c);
            c = "this is a test";
            input.AddFirst(c);
            c = "this is a test";
            input.AddFirst(c);
            Paper x = new Paper();
            x.Data = input;
            LinkedList<Paper> retrived = new LinkedList<Paper>();
            retrived.AddLast(x);
            LinkedList<Report> output = new LinkedList<Report>();
        }

        //run the tests -1 is undefined test

        public LinkedList<Report> getReports()
        {
            return reports;
        }
        public int run(string aGUID)
        {
            //int changed = 0;
            //inRestults= getdata(aID);
            // Create a temp linked list 
            //type = 1;
            //string c;
            //LinkedList<string> input = new LinkedList<string>();
            //c = "this is a test";
            //input.AddFirst(c);
            //c = "this is a test";
            //input.AddFirst(c);
            //c = "this is a test";
            //input.AddFirst(c);
            //Paper x = new Paper();
            //x.Data = input;
            //x.AID = "2";
            //x.Link = "this is a test link";
            //x.UserID = "TestUser";
            //LinkedList<Paper> retrived = new LinkedList<Paper>();
            //retrived.AddLast(x);
            assignmentReturn ar = new assignmentReturn();
            LinkedList<Paper> retrived;
            if (aGUID != null)
            {
                retrived = ar.getAssignmentList(aGUID);
            }
            else
            {
                retrived = ar.getAssignmentList();
            }
            LinkedList<Report> output = new LinkedList<Report>();


            //LinkedList<Report> oResults=new LinkedList<Report>();
            LinkedListNode<Paper> currentPaper = retrived.First;
            switch (type)
            {
                case 1://wc
                    // for each item inRestults 


                    Parallel.ForEach(retrived, current =>
                    {
                        this.tested++;
                        Report currentReport = new Report(current);
                        currentReport.TypeID = 1;
                        currentReport.TestID = wc.count(currentPaper.Value.Data);
                        reports.AddLast(currentReport);
                        currentPaper = currentPaper.Next;
                    });


                    break;
                case 2: 
                    
                    Parallel.ForEach(retrived, current =>
                        {
                            this.tested++;
                            Report report = new Report(current);
                            report.TypeID = 2;
                            report.KeyData=keywc.count(current.Data);
                            reports.AddLast(report);
                            //currentPaper = currentPaper.Next;
                        });
                    //while (currentPaper != null)
                    //{
                    //    this.tested++;
                    //    Report currentReport = new Report(currentPaper.Value);
                    //    currentReport.TypeID = 2;
                    //    Thread t = new Thread();     //(keywc.count(currentPaper.Value.Data,currentReport));
                    //    reports.AddLast(currentReport);
                    //    currentPaper = currentPaper.Next;
                    //}

                    break;
                case 3://n-word
                    break;
                case 4://phrased n-word
                    break;
                default:
                    return -1;
            }
            // put results into results tables
            // changed = sqlinsert(oresults); // number of rows added to the tables


            return this.tested;
        }

    }
}