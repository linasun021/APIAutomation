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
        private Apis.Apis baseApiTests;
        private RestResponse response;
        private CreatedUser createdUser;
        private Register register;
        private Login login;

        public PostApiTestingSteps()
        {
            baseApiTests = new Apis.Apis();
        }
        [Given(@"I have user name ""([^""]*)"" and job ""([^""]*)""")]
        public void GivenIHaveUserNameAndJob(string name, string job)
        {
            createdUser = new CreatedUser();
            createdUser.name = name;
            createdUser.job = job;
        }


        [When(@"I send request to create a user")]
        public void WhenISendRequestToCreateAUser()
        {
            response = baseApiTests.CreateNewUser(createdUser);
        }

        [Then(@"User ""([^""]*)"" is created")]
        public void ThenUserIsCreated(string name)
        {
            CreatedUser responseUser = ContentHandler.GetContent<CreatedUser>(response);
            Assert.AreEqual(name, responseUser.name, $"{name} should be created");
        }

        [Given(@"I want to register with email ""([^""]*)"" and password ""([^""]*)""")]
        public void GivenIWantToRegisterWithEmailAndPassword(string email, string password)
        {
            register = new Register();
            register.email = email;
            register.password = password;
        }

        [When(@"I send request to register")]
        public void WhenISendRequestToRegister()
        {
            response = baseApiTests.Register(register);
        }

        [Then(@"User with Id (.*) and token ""([^""]*)"" is registered successfully")]
        public void ThenUserWithIdAndTokenIsRegisteredSuccessfully(int id, string token)
        {
            RegisterResp registerResp = ContentHandler.GetContent<RegisterResp>(response);
            Assert.AreEqual(id, registerResp.id, $"id should be {id}");
            Assert.AreEqual(token, registerResp.token, $"token should be {token}");
        }

        [Then(@"I get error message ""([^""]*)""")]
        public void ThenIGetErrorMessage(string errorMessage)
        {
            RegisteFailedResp registeFailedResp = ContentHandler.GetContent<RegisteFailedResp>(response);
            Assert.AreEqual(errorMessage, registeFailedResp.error, $"error should be {errorMessage}");
        }

        [Then(@"I get status code (.*)")]
        public void ThenIGetStatusCode(int statusCode)
        {
            CommonStepMethods.AssertStatusCode(response, statusCode);
        }

        [Given(@"I want to login with email ""([^""]*)"" and password ""([^""]*)""")]
        public void GivenIWantLoginWithEmailAndPassword(string email, string password)
        {
            login  = new Login();
            login.email = email; 
            login.password = password;

        }


        [When(@"I send request to login")]
        public void WhenISendRequestToLogin()
        {
            response = baseApiTests.Login(login);
        }

        [Then(@"Login successfully with token ""([^""]*)""")]
        public void ThenLoginSuccessfullyWithToken(string token)
        {
            LoginResp loginResp = ContentHandler.GetContent<LoginResp>(response);
            Assert.AreEqual(token, loginResp.token, $"token should be {token}");
        }

    }
}
