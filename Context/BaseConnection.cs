using System;
using MySql.Data.MySqlClient;

namespace freeEnergyResortAPI.Context
{
    public class BaseConnection
    {
        protected string ConnectionString { get; set; }

        public BaseConnection(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        protected MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}