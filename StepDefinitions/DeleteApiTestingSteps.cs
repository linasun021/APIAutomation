using APIAutomation.Apis;
using Gherkin;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace APIAutomation.StepDefinitions
{
    [Binding]
    public class DeleteApiTestingSteps
    {
        private BaseApiTests baseApiTests;
        private RestResponse response;

        [Given(@"I have a user")]
        public void GivenIHaveAUser()
        {
            baseApiTests= new BaseApiTests();
        }

        [When(@"I send rquest to delte a user")]
        public void WhenISendRquestToDelteAUser()
        {
            response = baseApiTests.DeleteUser();
        }

        [Then(@"Response status code should be (.*)")]
        public void ThenResponseStatusCodeShouldBe(int statusCode)
        {
            CommonStepMethods.AssertStatusCode(response, statusCode);
        }


    }
}
