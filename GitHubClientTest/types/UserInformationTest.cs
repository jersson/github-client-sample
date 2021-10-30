using System;
using Xunit;

using Moq;
using RestSharp;
using GitHubClient;
using GitHubClient.Types;

using Newtonsoft.Json;


namespace GitHubClientTest
{
    public class UserInformationTest
    {
        [Fact]
        public void ValidateUserInformation()
        {
            //Given
            var userInformation = new UserInformation {
                Login = "Login",
                FullName = "FullName",
                Company = "Company",
                Blog = "Blog",
                Twitter = "Twitter",
                GitHubPage = "GitHubPage",
                PublicRepos = "PublicRepos",
                CreationDate = "CreationDate",
                LastUpdate = "LastUpdate",
            };

            //When
            var result = userInformation.ToString();

            //Then
            Assert.NotEmpty(result);
        }
        [Fact (Skip = "It's not working, we need to implement a proper way")]
        public void ValidateEmptyUserInformation()
        {
            //Given
            var userInformation = new UserInformation {
                Login = "",
                FullName = "",
                Company = "",
                Blog = "",
                Twitter = "",
                GitHubPage = "",
                PublicRepos = "",
                CreationDate = "",
                LastUpdate = "",
            };

            //When
            var result = userInformation.ToString();

            //Then
            Assert.Empty(result);
        }
    }
}
