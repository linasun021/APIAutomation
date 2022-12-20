using APIAutomation.Apis.Model;
using APIAutomation.Apis;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIAutomation.Utils.Helper;
namespace APIAutomation.StepDefinitions
{
    [Binding]
    public class PostApiTestingSteps
    {
        private BaseApiTests baseApiTests;
        private RestResponse response;
        private CreatedUser createdUser;
        private Register register;
        private Login login;

        public PostApiTestingSteps()
        {
            baseApiTests = new BaseApiTests();
        }
        [Given(@"I have user name ""([^""]*)"" and job ""([^""]*)""")]
        public void GivenIHaveUserNameAndJob(string name, string job)
        {
            createdUser = new CreatedUser();
            createdUser.name = name;
            createdUser.job = job;
        }


        [When(@"I send rquest to create a users")]
        public void WhenISendRquestToCreateAUsers()
        {
            response = baseApiTests.CreateNewUser(createdUser);
        }

        [Then(@"User ""([^""]*)"" has been created")]
        public void ThenUserHasBeenCreated(string name)
        {
            CreatedUser responseUser = ContentHandler.GetContent<CreatedUser>(response);
            Assert.AreEqual(name, responseUser.name, $"{name} should be created");
        }

        [Given(@"I want registe with email ""([^""]*)"" and password ""([^""]*)""")]
        public void GivenIWantRegisteWithEmailAndPassword(string email, string password)
        {
            register = new Register();
            register.email = email;
            register.password = password;
        }

        [When(@"I send rquest to regist")]
        public void WhenISendRquestToRegist()
        {
            response = baseApiTests.Register(register);
        }

        [Then(@"User with Id (.*) and token ""([^""]*)"" registe successfully")]
        public void ThenUserWithIdAndTokenRegisteSuccessfully(int id, string token)
        {
            RegisterResp registerResp = ContentHandler.GetContent<RegisterResp>(response);
            Assert.AreEqual(id, registerResp.id, $"id should be {id}");
            Assert.AreEqual(token, registerResp.token, $"token should be {token}");
        }

        [Then(@"I got error message ""([^""]*)""")]
        public void ThenIGotErrorMessage(string errorMessage)
        {
            RegisteFailedResp registeFailedResp = ContentHandler.GetContent<RegisteFailedResp>(response);
            Assert.AreEqual(errorMessage, registeFailedResp.error, $"error should be {errorMessage}");
        }

        [Then(@"I got status code (.*)")]
        public void ThenIGotStatusCode(int statusCode)
        {
            CommonStepMethods.AssertStatusCode(response, statusCode);
        }

        [Given(@"I want login with email ""([^""]*)"" and password ""([^""]*)""")]
        public void GivenIWantLoginWithEmailAndPassword(string email, string password)
        {
            login  = new Login();
            login.email = email; 
            login.password = password;

        }


        [When(@"I send rquest to login")]
        public void WhenISendRquestToLogin()
        {
            response = baseApiTests.Login(login);
        }

        [Then(@"Login successful with token ""([^""]*)""")]
        public void ThenLoginSuccessfulWithToken(string token)
        {
            LoginResp loginResp = ContentHandler.GetContent<LoginResp>(response);
            Assert.AreEqual(token, loginResp.token, $"token should be {token}");
        }

    }
}
