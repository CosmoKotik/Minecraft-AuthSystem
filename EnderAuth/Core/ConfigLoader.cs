using Newtonsoft.Json;
using System;

namespace EnderAuth.Core
{
    public class ConfigLoader
    {
        public static void Load()
        {
            string config_raw = System.IO.File.ReadAllText(@"config.ini");
            Config conf = JsonConvert.DeserializeObject<Config>(config_raw);

            Environment.SetEnvironmentVariable("db_ip", conf.db_ip);
            Environment.SetEnvironmentVariable("database", conf.database);
            Environment.SetEnvironmentVariable("db_username", conf.db_username);
            Environment.SetEnvironmentVariable("db_password", conf.db_password);
        }
    }
}
