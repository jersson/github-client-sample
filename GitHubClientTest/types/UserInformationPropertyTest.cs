using System;
using Xunit;

using Moq;
using RestSharp;
using GitHubClient;
using GitHubClient.Types;

using Newtonsoft.Json;


namespace GitHubClientTest
{
    public class UserInformationPropertyTest
    {
        [Fact]
        public void ValidateSingleInformationProperty()
        {
            //Given
            var name = "Name";
            var type = "Type";
            var property = new UserInformationProperty(name, type);

            //When
            var result = property.ToString();
            var expected = "* Name: Type";

            //Then
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ValidateEmptyInformationProperty()
        {
            //Given
            var property = new UserInformationProperty();

            //When
            var result = property.ToString();
            var expected = string.Empty;

            //Then
            Assert.Equal(expected, result);
        }

    }
}
