using APIAutomation.Apis.Model;
using APIAutomation.Utils.Helper;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIAutomation.Apis
{
    public class BaseApiTests
    {
        public RestResponse GetUsers()
        {
            RestResponse response =  new RequestHandler().GetResponse("api/users?page=2", Method.Get).Result;
            return response;
        }

        public RestResponse GetSingleUser()
        {
            RestResponse response = new RequestHandler().GetResponse("api/users/2", Method.Get).Result;
            return response;
        }

        public RestResponse SingleUserNotFound()
        {
            RestResponse response =new RequestHandler().GetResponse("api/users/23", Method.Get).Result;
            return response;
        }

        public RestResponse SingleResouceNotFound()
        {
            RestResponse response = new RequestHandler().GetResponse("api/unknown/23", Method.Get).Result;
            return response;
        }

        public RestResponse CreateNewUser(CreatedUser payload)
        {
            RestResponse response = new RequestHandler().GetResponse("api/users", Method.Post, ContentHandler.SerializeJsonString(payload)).Result;
            return response;
        }
        public RestResponse DeleteUser()
        {
            RestResponse response = new RequestHandler().GetResponse("api/users/2", Method.Delete).Result;
            return response;
        }

        public RestResponse Register(dynamic payload)
        {
            RestResponse response = new RequestHandler().GetResponse("api/register", Method.Post, ContentHandler.SerializeJsonString(payload)).Result;
            return response;
        }

        public RestResponse Login(dynamic payload)
        {
            RestResponse response = new RequestHandler().GetResponse("api/login", Method.Post, ContentHandler.SerializeJsonString(payload)).Result;
            return response;
        }
    }
}
