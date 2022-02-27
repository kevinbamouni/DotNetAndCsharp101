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
        public DataTable employees { get; set; }
        public DataTable artists { get; set; }
        public DataTable customers { get; set; }
        public RequetesChinook()
        {
            dt = MainReqAllTest();
            employees = Empoyees();
            artists = Artists();
            customers = Customers().Result;
        }

        public async Task<DataTable> Customers()
        {
                SqliteConnection connection = new SqliteConnection("Data Source=C:\\Users\\work\\source\\repos\\databasesoft\\WpfChinookDataApp\\data\\chinook.db;");
                connection.Open();
                SqliteCommand cmd = new SqliteCommand("SELECT * From customers", connection);
                SqliteDataReader reader = await cmd.ExecuteReaderAsync();
                DataTable dt = new DataTable();
                dt.Load(reader);
                connection.Close();
                return dt;
        }

        public DataTable Artists()
        {
            SqliteConnection connection = new SqliteConnection("Data Source=C:\\Users\\work\\source\\repos\\databasesoft\\WpfChinookDataApp\\data\\chinook.db;");
            connection.Open();
            SqliteCommand cmd = new SqliteCommand("SELECT * From artists", connection);
            SqliteDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            connection.Close();
            return dt;
        }

        public DataTable Empoyees()
        {
            SqliteConnection connection = new SqliteConnection("Data Source=C:\\Users\\work\\source\\repos\\databasesoft\\WpfChinookDataApp\\data\\chinook.db;");
            connection.Open();
            SqliteCommand cmd = new SqliteCommand("SELECT * From employees", connection);
            SqliteDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            connection.Close();
            return dt;
        }

        public DataTable MainReqAllTest()
        {
            SqliteConnection connection = new SqliteConnection("Data Source=C:\\Users\\work\\source\\repos\\databasesoft\\WpfChinookDataApp\\data\\chinook.db;");
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


