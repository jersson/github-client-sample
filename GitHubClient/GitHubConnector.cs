using System;
using RestSharp;
using Newtonsoft.Json;

using GitHubClient.Types;

namespace GitHubClient
{
    public class GitHubConnector
    {
        private IRestClient _restClient { get; set; }

        public GitHubConnector(): this(new RestClient()) {}

        public GitHubConnector(IRestClient client){
            var uri = new Uri("https://api.github.com/");

            this._restClient = client;
            this._restClient.BaseUrl = uri;
        }

        public UserInformation GetUserInformation(string username)
        {
            var request = new RestRequest("users/{username}", Method.GET);
            request.AddUrlSegment("username", username);

            var gitHubResponse = _restClient.Execute(request);
            dynamic gitHubObject = JsonConvert.DeserializeObject(gitHubResponse.Content);

            var result = new UserInformation{
                Login = gitHubObject.login,
                FullName =  gitHubObject.name,
                Company = gitHubObject.company,
                Blog = gitHubObject.blog,
                GitHubPage = gitHubObject.html_url, 
                PublicRepos = gitHubObject.public_repos,
                CreationDate = gitHubObject.created_at,
                LastUpdate = gitHubObject.updated_at,
                Twitter = $"@{gitHubObject.twitter_username}"
            };

            return result;
        }
    }
}
