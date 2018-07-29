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
        var result = connector.GetUserInformation("jersson");

        //Then

        Assert.True(result.Length > 0);
        }
        
    }
}
