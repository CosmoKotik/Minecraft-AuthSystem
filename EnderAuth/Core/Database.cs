using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace EnderAuth.Core
{
    public class Database
    {
        public Database()
        {
            
        }

        public static string Select()
        {
            string connectionString = "server=" + Environment.GetEnvironmentVariable("db_ip") +
                          ";uid=" + Environment.GetEnvironmentVariable("db_username") +
                          ";pwd=" + Environment.GetEnvironmentVariable("db_password") +
                          ";database=" + Environment.GetEnvironmentVariable("database");

            string[] result = { };

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new MySqlCommand("SELECT username from users", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        int i = 0;
                        while (reader.Read())
                        {
                            result[i] = reader.GetString(i);
                            i = i + 1;
                        }

                        return result.ToString();
                    }
                }
            }
        }
    }
}
