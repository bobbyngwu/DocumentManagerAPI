using System;
using System.Collections.Generic;
using System.Text;
using DM.Specs.Services.Interfaces;
using TechTalk.SpecFlow;

namespace DM.Specs.Steps
{
    [Binding]
	public class DeleteFileStepsDefinition
	{
		private readonly ScenarioContext _scenarioContext;
		private IHttpRequest _httpRequest;
		public DeleteFileStepsDefinition(ScenarioContext scenarioContext, IHttpRequest httpRequest)
		{
			_scenarioContext = scenarioContext;
			_httpRequest = httpRequest;
		}

		[Given(@"I have selected a PDF from the list API that I no longer require")]
        public void GivenIHaveSelectedAPDFFromTheListAPIThatINoLongerRequire()
        {
            _scenarioContext.Pending();
        }

        [When(@"I request to delete the PDF")]
        public void WhenIRequestToDeleteThePDF()
        {
            _scenarioContext.Pending();
        }

        [Then(@"the PDF is deleted and will no longer return from the list API and can no longer be downloaded from its location directly")]
        public void ThenThePDFIsDeletedAndWillNoLongerReturnFromTheListAPIAndCanNoLongerBeDownloadedFromItsLocationDirectly()
        {
            _scenarioContext.Pending();
        }

        [Given(@"I attempt to delete a file that does not exist")]
        public void GivenIAttemptToDeleteAFileThatDoesNotExist()
        {
            _scenarioContext.Pending();
        }

        [When(@"I request to delete the non-existing pdf")]
        public void WhenIRequestToDeleteTheNon_ExistingPdf()
        {
            _scenarioContext.Pending();
        }

        [Then(@"the API returns an appropriate response")]
        public void ThenTheAPIReturnsAnAppropriateResponse()
        {
            _scenarioContext.Pending();
        }

    }
}
