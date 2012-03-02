using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



public class Course
{
    //public int cid;
    //public int did;
    //public String description;
    //public int hours;

    public Course()
    {
    }

    public int CID
    { get; set;}

    public int DID
    {
        get
        {
            return did;
        }
        set
        {
            did = value;
        }
    }

    public String Description
    {
        get
        {
            return description;
        }
        set
        {
            description = value;
        }
    }

    public int Hours
    {
        get
        {
            return hours;
        }
        set
        {
            hours = value;
        }
    }

}// end class