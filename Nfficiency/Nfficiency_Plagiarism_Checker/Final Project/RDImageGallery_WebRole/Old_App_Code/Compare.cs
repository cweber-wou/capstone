using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Concurrent;

namespace RDImageGallery_WebRole.Old_App_Code
{
    public class Compare
    {
        private ConcurrentDictionary<string, int> data;

        public ConcurrentDictionary<string, int> Data
        {
            get { return data; }
            set { data = value; }
        }

        private string key;

        public string Key
        {
            get { return key; }
            set { key = value; }
        }

        public Compare()
        {
            data=new ConcurrentDictionary<string,int>();
            key="Not Set";
        }
    }
}