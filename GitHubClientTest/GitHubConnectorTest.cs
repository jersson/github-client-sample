using System;
using Xunit;

using Moq;
using RestSharp;
using GitHubClient;
using GitHubClient.Types;


namespace GitHubClientTest
{
    public class GitHubConnectorTest
    {
        [Fact]
        public void GetUserInformation()
        {
            //Given
            var mockRestClient = new Mock<RestSharp.RestClient>();
            var response = new RestSharp.RestResponse<GitHubUserInformation>();
            var userInformation = new GitHubUserInformation();
            var username = "jersson";
            
            userInformation.login = username;
            response.Data = userInformation;

            mockRestClient.Setup(m => 
                m.Execute<GitHubUserInformation>(It.IsAny<RestRequest>()))
                .Returns(response);

            var connector = new GitHubConnector(mockRestClient.Object);

            //When
            var result = connector.GetUserInformation(username);

            //Then
            Assert.Equal(username, result.login);
            mockRestClient.Verify(m => 
                m.Execute<GitHubUserInformation>(It.IsAny<RestRequest>()), Times.Exactly(1));
        }

    }
}
