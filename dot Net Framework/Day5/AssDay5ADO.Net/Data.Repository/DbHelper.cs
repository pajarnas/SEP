using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
namespace Data.Repository
{
    class DbHelper
    {
        public static string GetConnectionString()
        {
            IConfigurationBuilder confBuilder = new ConfigurationBuilder();
            IConfigurationRoot confRoot = confBuilder.AddJsonFile("appsettings.json").Build();
            return confRoot.GetConnectionString("MinionsDB");
        }
    }
}
