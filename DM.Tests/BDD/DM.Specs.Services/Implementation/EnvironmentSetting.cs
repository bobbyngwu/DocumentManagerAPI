using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using DM.Specs.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;


namespace DM.Specs.Services.Implementation
{
    public class EnvironmentSetting : IEnvironmentSetting
    {
        private string EnvironmentName { get; set; }
        public string BaseUrl { get; set; }
        public Dictionary<EndpointUrl, string> Enpoints { get; set; }
        public EnvironmentSetting() { }
        public EnvironmentSetting(IHostingEnvironment hostingEnv)
        {
            EnvironmentName = hostingEnv.EnvironmentName;
            IConfiguration config = BuildConfiguration(EnvironmentName);
            BaseUrl = config.GetValue<string>("BaseUrl");
            // get Pages
            Enpoints = new Dictionary<EndpointUrl, string>();
            Enpoints.Add(EndpointUrl.UploadDocumentUrl, config.GetValue<string>("EndPoint:UploadDocumentUrl"));
            Enpoints.Add(EndpointUrl.DeleteDocumentUrl, config.GetValue<string>("EndPoint:DeleteDocumentUrl"));
        }
        public EnvironmentSetting GetEnvironmentSettings() => this;

        private static IConfigurationRoot BuildConfiguration(string environment)
        {
            IConfigurationBuilder _config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            _config.AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            return _config.Build();
        }

    }
}
