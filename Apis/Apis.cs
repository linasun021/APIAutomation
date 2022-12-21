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
    public class Apis
    {
        public RestResponse GetUsers()
        {
            RestResponse response =  new RequestHandler().GetResponse("api/users?page=2", Method.Get).Result;
            return response;
        }

        public RestResponse GetSingleUser(int userId)
        {
            RestResponse response = new RequestHandler().GetResponse("api/users/"+userId, Method.Get).Result;
            return response;
        }

        public RestResponse GetSingleResouce(int resourceId)
        {
            RestResponse response = new RequestHandler().GetResponse("api/unknown/"+resourceId, Method.Get).Result;
            return response;
        }

        public RestResponse CreateNewUser(CreatedUser payload)
        {
            RestResponse response = new RequestHandler().GetResponse("api/users", Method.Post, ContentHandler.SerializeJsonString(payload)).Result;
            return response;
        }
        public RestResponse DeleteUser(int userId)
        {
            RestResponse response = new RequestHandler().GetResponse("api/users/"+userId, Method.Delete).Result;
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
