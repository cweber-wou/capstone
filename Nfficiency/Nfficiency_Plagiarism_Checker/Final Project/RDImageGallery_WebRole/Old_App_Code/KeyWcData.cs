using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;
using Microsoft.WindowsAzure.ServiceRuntime; 

namespace RDImageGallery_WebRole.Old_App_Code
{
    public class KeyWcData : TableServiceEntity
    {
    public KeyWcData()
    {
      PartitionKey = DateTime.UtcNow.ToString("MMddyyyy");

      // Row key allows sorting, so we make sure the rows come back in time order.
      RowKey = string.Format("{0:10}_{1}",
                             DateTime.MaxValue.Ticks - DateTime.Now.Ticks,
                             Guid.NewGuid());  
    }   

    public string TID { get; set; }
    public string ifWc { get; set; }
    public string whileWc { get; set; }
    public string forWc { get; set; }
    public string foreachWc { get; set; }
    public string publicWc { get; set; }
    public string privateWc { get; set; }
    public string voidWc { get; set; }
    public string importWc { get; set; }
    public string newWc { get; set; }
    public string constWc { get; set; }
    public string switchWc { get; set; }
    public string staticWc { get; set; }


    }
}