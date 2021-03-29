using System;
using System.Collections.Generic;
using System.Text;
using DM.Specs.Services.Interfaces;
using TechTalk.SpecFlow;

namespace DM.Specs.Steps
{
	[Binding]
	public class UploadFileStepsDefinition
	{
		private readonly ScenarioContext _scenarioContext;
		private IHttpRequest _httpRequest;
		public UploadFileStepsDefinition(ScenarioContext scenarioContext, IHttpRequest httpRequest)
		{
			_scenarioContext = scenarioContext;
			_httpRequest = httpRequest;
		}

        [Given(@"I have a PDF to upload")]
        public void GivenIHaveAPDFToUpload()
        {
            _scenarioContext.Pending();
        }

        [When(@"I Send the PDF to the API")]
        public void WhenISendThePDFToTheAPI()
        {
            _scenarioContext.Pending();
        }

        [Then(@"it is uploaded succesfully")]
        public void ThenItIsUploadedSuccesfully()
        {
            _scenarioContext.Pending();
        }

        [Given(@"I have a non-pdf to upload")]
        public void GivenIHaveANon_PdfToUpload()
        {
            _scenarioContext.Pending();
        }

        [When(@"I send the non-pdf to the API")]
        public void WhenISendTheNon_PdfToTheAPI()
        {
            _scenarioContext.Pending();
        }

        [Then(@"the API does not accept the file and returns the appropriate messaging and status")]
        public void ThenTheAPIDoesNotAcceptTheFileAndReturnsTheAppropriateMessagingAndStatus()
        {
            _scenarioContext.Pending();
        }

        [Given(@"I have a max pdf size of (.*)MB")]
        public void GivenIHaveAMaxPdfSizeOfMB(int p0)
        {
            _scenarioContext.Pending();
        }

        [When(@"I send the pdf to the API")]
        public void WhenISendThePdfToTheAPI()
        {
            _scenarioContext.Pending();
        }

    }
}
