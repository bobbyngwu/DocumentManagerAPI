using System;
using System.Collections.Generic;
using System.Text;
using DM.Specs.Services.Interfaces;
using TechTalk.SpecFlow;

namespace DM.Specs.Steps
{
    [Binding]
	public class ListFileStepsDefintion
	{
        private readonly ScenarioContext _scenarioContext;
        private IHttpRequest _httpRequest;
        public ListFileStepsDefintion(ScenarioContext scenarioContext, IHttpRequest httpRequest)
        {
            _scenarioContext = scenarioContext;
            _httpRequest = httpRequest;
        }

        [Given(@"I call the new document service API")]
        public void GivenICallTheNewDocumentServiceAPI()
        {
            _scenarioContext.Pending();
        }

        [When(@"I call the API to get a list of documents")]
        public void WhenICallTheAPIToGetAListOfDocuments()
        {
            _scenarioContext.Pending();
        }

        [Then(@"a list of PDFs’ is returned with the following properties: name, location, file-size")]
        public void ThenAListOfPDFsIsReturnedWithTheFollowingPropertiesNameLocationFile_Size()
        {
            _scenarioContext.Pending();
        }

    }
}
