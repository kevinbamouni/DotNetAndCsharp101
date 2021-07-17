using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace sqliteinversdata
{
    public static class Helper
    {
        public static string CnnVal(string connectionStringName)
        {
            return ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
        }
    }
}
