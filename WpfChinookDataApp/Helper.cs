using System.Configuration;

namespace WpfChinookDataApp
{
    public static class Helper
    {
        public static string CnnVal(string connectionStringName)
        {
            //return ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
            return "Data Source=C:\\Users\\work\\source\\repos\\databasesoft\\WpfChinookDataApp\\chinook.db;Version=3;";
        }
    }
}
