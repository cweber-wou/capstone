using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace NfficiencyPD.Old_App_Code1
{
    public class NavigationManager
    {

        public static SiteMapDataSource GetSiteMapDataSource(string role)
        {

            string url = String.Empty;

            if (role.Equals("Admin"))

                url = "~/Admin/AdminHomePage.aspx";

            else if (role.Equals("User"))

                url = "~/User/UserHomePage.aspx";

            XmlSiteMapProvider xmlSiteMap = new XmlSiteMapProvider();

            System.Collections.Specialized.NameValueCollection myCollection = new System.Collections.Specialized.NameValueCollection(1);

            myCollection.Add("siteMapFile", "Web.sitemap");

            xmlSiteMap.Initialize("provider", myCollection);

            xmlSiteMap.BuildSiteMap();

            SiteMapDataSource siteMap = new SiteMapDataSource();

            siteMap.StartingNodeUrl = url;

            /* This will not show the starting node and hence giving it

            * the horizontal cool look :)

            * */

            siteMap.ShowStartingNode = false;

            return siteMap;

        }




    }
}