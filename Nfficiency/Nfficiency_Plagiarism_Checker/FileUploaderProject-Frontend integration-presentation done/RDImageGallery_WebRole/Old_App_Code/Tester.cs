﻿using System;
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

        static public LinkedList<string> getWordlist()
        {
            LinkedList<string> wordlist = new LinkedList<string>();
            foreach (Word w in WordDB.GetWords())
            {
                wordlist.AddLast(w.Value);
            }
            return wordlist;
        }

        public LinkedList<Report> getReports()
        {
            return reports;
        }
        public int run(string aGUID)
        {
            
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
                    Paper found=null;
                    foreach (Paper current in retrived)
                    {
                        if (current.FileName == "Dictonary.txt")
                        {
                            found = current;
                  
                        }
                    }

                    
                    
                    LinkedList<string> words;
                    if (found != null)
                    {
                        words = found.Data;
                        retrived.Remove(found);

                        //replace word list
                    }
                    else
                    {
                        words = getWordlist();
                    }
                    foreach(Paper current in retrived)
                        {
                            this.tested++;
                            Report report = new Report(current);
                            report.TypeID = 2;
                            report.KeyData=keywc.count(current.Data,words);
                            reports.AddLast(report);
                            
                            //currentPaper = currentPaper.Next;
                        }
                    Parallel.ForEach(reports, current =>//spawn threads for every report
                    {
                       
                        LinkedListNode<Report> testing = reports.First;// grab first not to compare to all documents
                        while (testing != null)
                        {
                            Compare store = new Compare();
                            int total = 0;
                            foreach (KeyValuePair<string, int> word in current.KeyData)
                            {
                                //setup keys we are dealing with
                                string key = word.Key;
                                
                                //get values
                                int value1 = word.Value;
                                int value2;
                                while (!(testing.Value.KeyData.TryGetValue(key, out value2))) ;
                                //Calculate
                                int result = Math.Abs(value1 - value2);
                                total += result;
                                //save data
                                while (!(store.Data.TryAdd(key, result))) ;


                            }
                            int wc = 0;
                            while (!(store.Data.TryGetValue("WC",out wc)));
                            total -= wc;
                            while (!(store.Data.TryAdd("Total", total))) ;//add total to the dictionary before we continue
                            store.Key = current.UserID +"*"+ testing.Value.UserID;//format is GUID*GUID
                            current.Compared.AddLast(store);
                            testing = testing.Next;// go to next report
                        }
                        
                    });
                    

                    break;
                case 3://n-word
                    break;
                case 4://phrased n-word
                    break;
                default:
                    return -1;
            }
           


            return this.tested;
        }

    }
}