using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TS.DAL.DataContext
{
    public class AppConfiguration
    {
        public string ConnectionString { get; set; }

        public string Secret { get; set; }

        public AppConfiguration()
        {
            var configBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");

            configBuilder.AddJsonFile(path, false);

            var root = configBuilder.Build();

            var appSetting = root.GetSection("ConnectionStrings:Database");
            var secret = root.GetSection("AppSettings:Secret");

            ConnectionString = appSetting.Value;
            Secret = secret.Value;
        }
    }
}
