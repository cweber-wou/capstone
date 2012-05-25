using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;
using Microsoft.WindowsAzure.ServiceRuntime;


namespace NfficiencyPD.Old_App_Code
{

    public class KeyWCAccess
    {
        private const string tableName = "MessageTable";
        private const string connectionStringName = "DataConnectionString";
        private static CloudStorageAccount storageAccount;
        private CloudTableClient tableClient;
        public KeyWCAccess()
        {
            string connectionString = RoleEnvironment.GetConfigurationSettingValue(connectionStringName);

            storageAccount = CloudStorageAccount.Parse(connectionString);
            tableClient = new CloudTableClient(storageAccount.TableEndpoint.AbsoluteUri, storageAccount.Credentials);
            tableClient.RetryPolicy = RetryPolicies.Retry(3, TimeSpan.FromSeconds(1));
            tableClient.CreateTableIfNotExist(tableName);
        }
        public IEnumerable<KeyWcData> GetEntries()
        {
            TableServiceContext tableServiceContext = tableClient.GetDataServiceContext();

           
            var results = from g in tableServiceContext.CreateQuery<KeyWcData>(tableName)
                          //where g.PartitionKey == DateTime.UtcNow.ToString("MMddyyyy")
                          select g;
            return results;
        }

        public void AddEntry(KeyWcData newItem)
        {
            TableServiceContext tableServiceContext = tableClient.GetDataServiceContext();
            tableServiceContext.AddObject(tableName, newItem);
            tableServiceContext.SaveChanges();
        }
    }
}