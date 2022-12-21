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
        private Apis.Apis apis;
        private RestResponse response;

        [Given(@"I have a user")]
        public void GivenIHaveAUser()
        {
            apis = new Apis.Apis();
        }

        [When(@"I send request to delete user (.*)")]
        public void WhenISendRequestToDeleteUser(int userId)
        {
            response = apis.DeleteUser(userId);
        }

        [Then(@"Response status code should be (.*)")]
        public void ThenResponseStatusCodeShouldBe(int statusCode)
        {
            CommonStepMethods.AssertStatusCode(response, statusCode);
        }


    }
}
