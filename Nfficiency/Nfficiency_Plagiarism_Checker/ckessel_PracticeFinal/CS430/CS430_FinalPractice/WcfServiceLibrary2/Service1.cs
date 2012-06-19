using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary2
{
    //Methods must corrispond to IService1.cs [Operation Contracts]
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public int GetData(int value)
        {
            return 10;
        }

        public int dollars2Dublons(int value)
        {
            int tmpVal;
            tmpVal = (value * 1532);
            return tmpVal;
        }

        public int dublons2Dollars(int value)
        {
            int tmpVal;
            tmpVal = (value / 1532);
            return tmpVal;
        }

        //I didn't touch anything in here
        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
