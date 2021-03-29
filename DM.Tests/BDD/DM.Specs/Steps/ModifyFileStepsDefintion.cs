using System;
using System.Collections.Generic;
using System.Text;
using DM.Specs.Services.Interfaces;
using TechTalk.SpecFlow;

namespace DM.Specs.Steps
{
    [Binding]
	public class ModifyFileStepsDefintion
	{
        private readonly ScenarioContext _scenarioContext;
        private IHttpRequest _httpRequest;
        public ModifyFileStepsDefintion(ScenarioContext scenarioContext, IHttpRequest httpRequest)
        {
            _scenarioContext = scenarioContext;
            _httpRequest = httpRequest;
        }

        [Given(@"I have a list of PDFs’")]
        public void GivenIHaveAListOfPDFs()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I choose to re-order the list of PDFs’")]
        public void WhenIChooseToRe_OrderTheListOfPDFs()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the list of PDFs’ is returned in the new order for subsequent calls to the API")]
        public void ThenTheListOfPDFsIsReturnedInTheNewOrderForSubsequentCallsToTheAPI()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
