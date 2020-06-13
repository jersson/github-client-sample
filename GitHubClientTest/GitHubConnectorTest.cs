using System;
using Xunit;

using GitHubClient;

namespace GitHubClientTest
{
    public class GitHubConnectorTest
    {
        [Fact]
        public void GetUserInformation()
        {
            //Given
            var connector = new GitHubConnector();

            //When
            var username = "jersson";
            var result = connector.GetUserInformation(username);

            //Then
            Assert.Equal(username, result.login);
        }

    }
}
