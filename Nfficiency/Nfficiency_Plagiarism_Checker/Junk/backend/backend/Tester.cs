using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace backend
{
    public class Tester
    {
        private int type=0; // The type of test to be prefromed
        private int aID; // Assignment ID
        private int tested; // Number of assignments tested
        private LinkedList<Report> reports; // Linked List of the reports 

        // Get and set
        public int Type { get { return type; } set { type = value; } }
        public int AID { get { return aID; } set { aID = value; } }

        //Get
        public int Tested { get { return tested; } }
        public LinkedList<Report> Reports { get { return reports; } }

        public Tester() { 
            this.tested = 0;
            this.reports = new LinkedList<Report>(); 
        } // Blank constructor

        // constructor with the test type and Assignment already set
        public Tester(int type, int aID) 
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
        public int run()
        {
            //int changed = 0;
            //inRestults= getdata(aID);
            // Create a temp linked list 
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
            x.AID = 2;
            x.Link = "this is a test link";
            x.UserID = "TestUser";
            LinkedList<Paper> retrived = new LinkedList<Paper>();
            retrived.AddLast(x);
            LinkedList<Report> output = new LinkedList<Report>();


            //LinkedList<Report> oResults=new LinkedList<Report>();

            switch (type)
                {
                case 1://wc
                    // for each item inRestults 
                        LinkedListNode<Paper> currentPaper = retrived.First;
                        
                        while (currentPaper != null)
                        {
                            this.tested++;
                            Report currentReport = new Report(currentPaper.Value);
                            currentReport.TypeID = 1;
                            currentReport.TestID = wc.count(currentPaper.Value.Data);
                            reports.AddLast(currentReport);
                            currentPaper = currentPaper.Next;
                        }
                

                    break;
                case 2://keywc
                    // for each item inRestults 
                    //String data = kwc.count(item.LL_String);
                    //data.split(:);
                    //report=new report (item.assignid,item.userid,type,data.uuid,item.link
                    //sqlinsert(keywctable(data))
                    //OResults.add(report);
                    
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