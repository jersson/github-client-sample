using System;

using RestSharp;

namespace GitHubClient
{
    public class GitHubConnector
    {
        public string GetUserInformation(string username){

            var client = new RestClient("https://api.github.com/");
            var request = new RestRequest("users/{username}", RestSharp.Method.GET);

            request.AddUrlSegment("username", username);


            IRestResponse response = client.Execute(request);
            var content = response.Content; 

            return content;
        }
    }
}
