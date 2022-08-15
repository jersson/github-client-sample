using System;
using Xunit;

using Moq;
using RestSharp;
using GitHubClient;
using GitHubClient.Types;

using Newtonsoft.Json;


namespace GitHubClientTest
{
    public class GitHubConnectorTest
    {

        [Fact]
        public void ValidateUserInformation()
        {
            //Given
            var mockRestClient = new Mock<RestSharp.RestClient>();
            var response = new RestSharp.RestResponse();
            var username = "jersson";

            dynamic fakeUserInformation = new
            {
                login = username, 
                name =  "name",
                company = "company",
                blog = "blog",
                twitter_username = username, 
                html_url = "html_url", 
                public_repos = "public_repos",
                created_at = "created_at",
                updated_at = "updated_at",
            };

            var expectedUser = new UserInformation {
                Login = fakeUserInformation.login,
                FullName = fakeUserInformation.name,
                Company = fakeUserInformation.company,
                Blog = fakeUserInformation.blog,
                TwitterAccount = fakeUserInformation.twitter_username,
                GitHubPage = fakeUserInformation.html_url,
                PublicRepos = fakeUserInformation.public_repos,
                CreationDate = fakeUserInformation.created_at,
                LastUpdate = fakeUserInformation.updated_at,
            };

            response.Content = JsonConvert.SerializeObject(fakeUserInformation);

            mockRestClient.Setup(m => 
                m.Execute(It.IsAny<RestRequest>()))
                .Returns(response);

            var connector = new GitHubConnector(mockRestClient.Object);

            //When
            var result = connector.GetUserInformation(username);

            //Then
            Assert.Equal(expectedUser.Login, result.Login);
            Assert.Equal(expectedUser.FullName, result.FullName);
            Assert.Equal(expectedUser.Company, result.Company);
            Assert.Equal(expectedUser.Blog, result.Blog);
            Assert.Equal(expectedUser.TwitterAccount, result.TwitterAccount);
            Assert.Equal(expectedUser.GitHubPage, result.GitHubPage);
            Assert.Equal(expectedUser.PublicRepos, result.PublicRepos);
            Assert.Equal(expectedUser.CreationDate, result.CreationDate);
            Assert.Equal(expectedUser.LastUpdate, result.LastUpdate);
            Assert.NotEmpty(expectedUser.ToString());

            mockRestClient.Verify(m => 
                m.Execute(It.IsAny<RestRequest>()), Times.Exactly(1));
        }

    }
}
