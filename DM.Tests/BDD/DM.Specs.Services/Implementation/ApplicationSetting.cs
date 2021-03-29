using System;
using System.Collections.Generic;
using System.Text;
using DM.Specs.Services.Interfaces;

namespace DM.Specs.Services.Implementation
{
    public class ApplicationSettings
    {
        private EnvironmentSetting envSettings;

        public ApplicationSettings(IEnvironmentSetting _environmentSettings)
        {
            envSettings = _environmentSettings.GetEnvironmentSettings();
        }
        public string ApplicationUrl
        {
            get
            {
                return envSettings.BaseUrl;
            }
        }
    }
}
