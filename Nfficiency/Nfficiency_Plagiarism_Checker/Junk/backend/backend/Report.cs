using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace backend
{
    public class Report
    {
        public int AID; //from report
        public string UserID; // from report
        public int TypeID; // from user choice
        public String Link; // from report
        public int TestID; // from calculations
        //private Paper paper;

        public Report() { } //blank constructor 

        public Report(Paper paper)
        {   //copies the common data between reports and papers;
            this.AID = paper.AID;
            this.Link = paper.Link;
            this.UserID = paper.UserID;
        }

        public override String ToString()
        {
            string output;
            output = AID.ToString()+"|";
            output += UserID.ToString() + "|";
            output += TypeID.ToString() + "|";
            output += TestID.ToString() + "|";
            output += Link.ToString() + "|";
            return output;
        }

    
    }
}