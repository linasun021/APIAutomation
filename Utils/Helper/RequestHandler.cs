using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace APIAutomation.Utils.Helper
{
    public  class RequestHandler
    {
        private RestClient client;
        private RestRequest request;

        public async Task<RestResponse> GetResponse(string endPoint,Method requestMethod, string payload = "")
        {
            var url = Path.Combine(UrlHandler.baseUrl, endPoint);
            client = new RestClient(url);
            request = new RestRequest();
            request.Method = requestMethod;
            request.AddHeader("Accept", "application/json");
            if (request.Method is Method.Post)
            {
                request.AddParameter("application/json", payload, ParameterType.RequestBody);
            }
            if (request.Method is Method.Delete)
            {
                return await client.DeleteAsync(request);
            }
            return await client.ExecuteAsync(request);
        }
    }
}
