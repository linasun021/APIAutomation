using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIAutomation.StepDefinitions
{
    public class CommonStepMethods
    {
        public static void AssertStatusCode(RestResponse response, int statusCode)
        {
            Assert.AreEqual(statusCode, Convert.ToInt32(response.StatusCode), $"Status code shoud be {statusCode}");
        }
    }
}
