using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;
using Microsoft.Data.Sqlite;

namespace WpfChinookDataApp
{
    public class RequetesChinook
    {
        public DataTable dt { get; set; }
        public RequetesChinook()
        {
            dt = MainReqAllTest();
        }

        public DataTable MainReqAllTest()
        {
            SqliteConnection connection = new SqliteConnection("Data Source=C:\\Users\\work\\source\\repos\\databasesoft\\WpfChinookDataApp\\data\\chinook.db;");
            //var result = connection.Query("SELECT * from albums").ToList();
            connection.Open();
            SqliteCommand cmd = new SqliteCommand("SELECT * From albums", connection);
            SqliteDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            connection.Close();
            return dt;
        }
    }
}


