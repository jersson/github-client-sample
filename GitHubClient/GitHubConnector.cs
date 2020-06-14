using System;
using RestSharp;

using GitHubClient.Types;

namespace GitHubClient
{
    public class GitHubConnector
    {
        private IRestClient _client { get; set; }

        public GitHubConnector(): this(new RestClient()) {}

        public GitHubConnector(IRestClient client){
            var uri = new Uri("https://api.github.com/");

            _client =  client;
            _client.BaseUrl = uri;
        }
        public GitHubUserInformation GetUserInformation(string username)
        {
            var request = new RestRequest("users/{username}", Method.GET);
            request.AddUrlSegment("username", username);

            var response = _client.Execute<GitHubUserInformation>(request);

            return response.Data;
        }
    }
}
