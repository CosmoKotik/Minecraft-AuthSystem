using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace EnderAuth.Core
{
    public class Database
    {
        public Database()
        {
            
        }

        public static string[] Select(string columnName, string select = "SELECT username from users")
        {
            string connectionString = "server=" + Environment.GetEnvironmentVariable("db_ip") +
                          ";uid=" + Environment.GetEnvironmentVariable("db_username") +
                          ";pwd=" + Environment.GetEnvironmentVariable("db_password") +
                          ";database=" + Environment.GetEnvironmentVariable("database");

            List<string> result = new List<string>();

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new MySqlCommand(select, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(reader.GetString(columnName));
                        }

                        return result.ToArray();
                    }
                }
            }
        }
    }
}
