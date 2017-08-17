using System;
using System.Configuration;
using System.Data.SQLite;
using System.Web.Hosting;

namespace GeekHunter.Database
{
    public class DatabaseManager
    {
        public static string DbFile => HostingEnvironment.ApplicationPhysicalPath + "\\GeekHunter.sqlite";

        public static SQLiteConnection SimpleDbConnection()
        {
            string unitTestDbFile = ConfigurationManager.AppSettings["UnitTestDbFile"];
            var databaseFile = String.IsNullOrWhiteSpace(unitTestDbFile) ? DbFile : unitTestDbFile;
            
            return new SQLiteConnection("Data Source=" + databaseFile);
        }
    }
}