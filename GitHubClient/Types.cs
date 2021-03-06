using System.Text;

namespace GitHubClient.Types
{
    public class GitHubUserInformation
    {

        public string Login { get; set; }

        public string FullName { get; set; }

        public string Company { get; set; }

        public string Blog { get; set; }

        public string GitHubPage { get; set; }

        public string PublicRepos { get; set; }

        public string CreationDate { get; set; }

        public string LastUpdate { get; set; }
        public string Twitter { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();
            var properties = this.GetType().GetProperties();

            foreach (var prop in properties)
            {
                builder.AppendFormat("* {0}: {1}", prop.Name, prop.GetValue(this));
                builder.AppendLine();
            }
            
            var result = builder.ToString().Trim();
            return result;
        }
    }
}