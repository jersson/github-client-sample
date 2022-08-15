using System.Text;
using System.Linq;
using Newtonsoft.Json;
namespace GitHubClient.Types
{
    public class UserInformation
    {
        private string _twitterAccount;

        [JsonProperty("login")]
        public string Login { get; set; }
        
        [JsonProperty("name")]
        public string FullName { get; set; }

        [JsonProperty("company")]
        public string Company { get; set; }

        [JsonProperty("blog")]
        public string Blog { get; set; }

        [JsonProperty("html_url")]
        public string GitHubPage { get; set; }

        [JsonProperty("public_repos")]
        public string PublicRepos { get; set; }

        [JsonProperty("created_at")]
        public string CreationDate { get; set; }

        [JsonProperty("updated_at")]
        public string LastUpdate { get; set; }
        
        [JsonProperty("twitter_username")]
        public string TwitterAccount 
        { 
            get 
            {
                return _twitterAccount;
            } 
            set
            {
                _twitterAccount = $"@{value}";
            } 
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            var properties = this.GetType().GetProperties();

            foreach (var prop in properties)
            {
                builder.Append(new UserInformationProperty(prop.Name, prop.GetValue(this).ToString()));
                builder.AppendLine();
            }
            
            return builder.ToString().Trim();
        }
    }
}