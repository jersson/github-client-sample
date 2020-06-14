using System;
using Xunit;

using Moq;
using RestSharp;
using GitHubClient;

using Newtonsoft.Json;


namespace GitHubClientTest
{
    public class GitHubConnectorTest
    {
        [Fact]
        public void GetUserInformation()
        {
            //Given
            var mockRestClient = new Mock<RestSharp.RestClient>();
            var response = new RestSharp.RestResponse();
            var username = "jersson";
            dynamic fakeUserInformation = new
            {
                login = username
            };

            response.Content = JsonConvert.SerializeObject(fakeUserInformation);

            mockRestClient.Setup(m => 
                m.Execute(It.IsAny<RestRequest>()))
                .Returns(response);

            var connector = new GitHubConnector(mockRestClient.Object);

            //When
            var result = connector.GetUserInformation(username);

            //Then
            Assert.Equal(username, result.Login);
            mockRestClient.Verify(m => 
                m.Execute(It.IsAny<RestRequest>()), Times.Exactly(1));
        }

    }
}
