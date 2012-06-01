﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Concurrent;


namespace RDImageGallery_WebRole.Old_App_Code
{
    public class Report
    {
        private string m_aid; //from report

        public string Aid
        {
            get { return m_aid; }
            set { m_aid = value; }
        }
        private string m_UserID; // from report

        public string UserID
        {
            get { return m_UserID; }
            set { m_UserID = value; }
        }
        private int m_TypeID; // from user choice

        public int TypeID
        {
            get { return m_TypeID; }
            set { m_TypeID = value; }
        }
        private String m_Link; // from report

        public String Link
        {
            get { return m_Link; }
            set { m_Link = value; }
        }
        private int m_TestID; // from calculations

        private ConcurrentDictionary<string, int> keyData;

        public ConcurrentDictionary<string, int> KeyData
        {
            get { return keyData; }
            set { keyData = value; }
        }
        private ConcurrentDictionary<string, int> dic;

        public ConcurrentDictionary<string, int> Dic
        {
            get { return dic; }
            set { dic = value; }
        }

        private LinkedList<int> order;

        public LinkedList<int> Order
        {
            get { return order; }
            set { order = value; }
        }
        private LinkedList<Compare> compared;

        public LinkedList<Compare> Compared
        {
            get { return compared; }
            set { compared = value; }
        }


        public int TestID
        {
            get { return m_TestID; }
            set { m_TestID = value; }
        }
        //private Paper paper;

        public Report() { } //blank constructor 

        public Report(Paper paper)
        {   //copies the common data between reports and papers;
            this.m_aid = paper.AID;
            this.m_Link = paper.Link;
            this.m_UserID = paper.UserID;
            this.compared= new LinkedList<Compare>();
        }
        

        public override String ToString()
        {
            string output;
            output = m_aid.ToString() + "|";
            output += m_UserID.ToString() + "|";
            output += m_TypeID.ToString() + "|";
            output += m_TestID.ToString() + "|";
            output += m_Link.ToString() + "|";
            return output;
        }


    }
}