using System;
using System.Collections.Generic;
using System.Text;
using DM.Specs.Services.Interfaces;
using TechTalk.SpecFlow;

namespace DM.Specs.Steps
{
    [Binding]
	public class DownloadFileStepsDefinition
	{
		private readonly ScenarioContext _scenarioContext;
		private IHttpRequest _httpRequest;
		public DownloadFileStepsDefinition(ScenarioContext scenarioContext, IHttpRequest httpRequest)
		{
			_scenarioContext = scenarioContext;
			_httpRequest = httpRequest;
		}

		[Given(@"I have chosen a PDF from the list API")]
        public void GivenIHaveChosenAPDFFromTheListAPI()
        {
            _scenarioContext.Pending();
        }

        [When(@"I request the location for one of the PDF's")]
        public void WhenIRequestTheLocationForOneOfThePDFS()
        {
            _scenarioContext.Pending();
        }

        [Then(@"the PDF is downloaded")]
        public void ThenThePDFIsDownloaded()
        {
            _scenarioContext.Pending();
        }

    }
}
