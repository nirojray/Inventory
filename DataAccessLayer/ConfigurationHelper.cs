using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web.Configuration;
namespace DataAccessLayer
{
    public class ConfigurationHelper
    {
        // Caches the connection string
        private static string dbConnectionString;
        // Caches the data provider name 
        private static string dbProviderName;

        static ConfigurationHelper()
        {
            dbConnectionString = WebConfigurationManager.AppSettings["ImagingTool"].ToString();
            dbProviderName = WebConfigurationManager.AppSettings["ImagingToolProvider"].ToString();
        }
        // Returns the connection string for the Revenue database
        public static string DbConnectionString
        {
            get
            {
                return dbConnectionString;
            }
        }

        // Returns the data provider name
        public static string DbProviderName
        {
            get
            {
                return dbProviderName;
            }
        }
    }
}
