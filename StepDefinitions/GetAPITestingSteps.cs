using APIAutomation.Apis;
using APIAutomation.Apis.Model;
using APIAutomation.Utils.Helper;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
[assembly: Parallelize(Workers = 10, Scope = ExecutionScope.ClassLevel)]

namespace APIAutomation.StepDefinitions
{
    [Binding]
    public class GetAPITestingSteps
    {
        private Apis.Apis apis;
        private RestResponse response;
        private CreatedUser createdUser;

        [Given(@"I have baseurl")]
        public void GivenIHaveBaseurl()
        {
            apis = new Apis.Apis();
        }

        [When(@"I send request to get all users")]
        public void WhenISendRequestToGetAllUers()
        {
            response = apis.GetUsers();
        }

        [Then(@"User ""([^""]*)"" should be included")]
        public void ThenUserShouldBeIncluded(string userFullName)
        {
            Users users = ContentHandler.GetContent<Users>(response);
            var userData = users.data.Find(a => a.first_name + " " + a.last_name == userFullName);
            Assert.IsNotNull(userData, $"{ userFullName} should be quried");
        }

        [When(@"I send request to get single user (.*)")]
        public void WhenISendRequestToGetSingleUser(int userId)
        {
            response = apis.GetSingleUser(userId);
        }

        [Then(@"User ""([^""]*)"" detail info will show")]
        public void ThenUserDetailInfoWillShow(string firstName)
        {
            SingleUser user = ContentHandler.GetContent<SingleUser>(response);
            Assert.AreEqual(firstName,user.data.first_name, $"{firstName} should be showing");
        }

        [Then(@"The status code should be (.*)")]
        public void ThenTheStatusCodeShouldBe(int statusCode)
        {
            CommonStepMethods.AssertStatusCode(response, statusCode);
        }

        [When(@"I send request to get resource (.*)")]
        public void WhenISendRequestToGetNotExistResource(int resourceId)
        {
            response = apis.GetSingleResouce(resourceId);
        }


    }
}