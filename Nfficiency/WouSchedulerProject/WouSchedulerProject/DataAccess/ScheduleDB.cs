using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel;


[DataObject(true)]
public static class ScheduleDB
{
  //  [DataObjectMethod(DataObjectMethodType.Select)]
  //  public static List<Course> GetAllCourses();

    private static string GetConnectionString()
    {
        return ConfigurationManager.ConnectionStrings
            ["ServerDB"].ConnectionString;
    }
}