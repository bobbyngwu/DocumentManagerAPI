using System;
using System.Collections.Generic;
using System.Text;
using BoDi;
using DM.Specs.Services.Implementation;
using DM.Specs.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using TechTalk.SpecFlow;

namespace DM.Specs.Hooks
{
	[Binding]
	public class Hook
	{
        private IObjectContainer _objectContainer;
        private IHttpRequest _httpRequest;
        private IHostingEnvironment _hostingEnvironment;
        private IEnvironmentSetting environmentSetting;
        [BeforeScenario]
        public void Initialize(IObjectContainer objectContainer, IHttpRequest httpRequest)
        {

            try
            {
                _objectContainer = objectContainer;
                _hostingEnvironment = (IHostingEnvironment)new HostingEnvironment();
                //initialize Environment 
                environmentSetting = new EnvironmentSetting(_hostingEnvironment);
                //initilise httpApplicationUrl
                ApplicationSettings appSettings = new ApplicationSettings(environmentSetting);
                _httpRequest = httpRequest;
  
                //register components for IoC
                _objectContainer.RegisterInstanceAs(_httpRequest);
                _objectContainer.RegisterInstanceAs(environmentSetting);

            }
            catch (Exception ex)
            {
            }
        }
    }
}
