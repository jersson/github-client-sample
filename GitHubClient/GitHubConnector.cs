using System;

using RestSharp;

namespace GitHubClient
{
    public class GitHubConnector
    {
        public GitHubUserInformation GetUserInformation(string username){

            var client = new RestClient("https://api.github.com/");
            var request = new RestRequest("users/{username}", Method.GET);

            request.AddUrlSegment("username", username);


            var response = client.Execute<GitHubUserInformation>(request);

            return response.Data;
        }
    }
}
