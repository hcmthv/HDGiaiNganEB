
using Microsoft.Extensions.Configuration;
using System.IO;

namespace GiaiNganAPI.DAL
{
    public class ConfigSettings
    {
        public static string connectString { get; set; }
        public static ConfigSettings Instance { get;} = new ConfigSettings();
        public ConfigSettings()
        {
        }

        public void AppSettings(string dbType = null) {
            var configurationBuilder = new ConfigurationBuilder();
            string path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);

            string dataKey = @"ConnectionStrings:{0}";
            switch (dbType)
            {
                case "LO":
                    dataKey = string.Format(dataKey, "LO");
                    break;
                default:
                    dataKey = string.Format(dataKey, "DefaultConnection");
                    break;

            }

            connectString = configurationBuilder.Build().GetSection(dataKey).Value;
        }

    }
}


