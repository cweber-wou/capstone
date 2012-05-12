using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.StorageClient;
using Microsoft.WindowsAzure.StorageClient.Protocol;


namespace CS430_ASPNET_Role_Records
{
    public class Global : System.Web.HttpApplication
    {

       protected void Application_Start()
        {           
            //(CDLTLL) Configuration for Windows Azure settings
            CloudStorageAccount.SetConfigurationSettingPublisher(
                (configName, configSettingPublisher) =>
                {
                    var connectionString =
                        RoleEnvironment.GetConfigurationSettingValue(configName);
                    configSettingPublisher(connectionString);
                }
            );
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }

    }
}
