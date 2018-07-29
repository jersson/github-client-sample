using System;

namespace GitHubClient
{
    public class GitHubConnector
    {
        public string GetUserInformation(string username){

            var client = new RestSharp.RestClient("https://api.github.com/");
            var request = new RestSharp.RestRequest("users/{username}", RestSharp.Method.GET);

            request.AddUrlSegment("username", username);


            RestSharp.IRestResponse response = client.Execute(request);
            var content = response.Content; 


            return content;
        }
    }
}
