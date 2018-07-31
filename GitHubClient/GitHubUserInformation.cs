using System.Text;

namespace GitHubClient
{
    public class GitHubUserInformation
    {
        public GitHubUserInformation(){

        }

        public string login { get; set; }
        public string name { get; set; }

        public string company { get; set; }
        public string blog { get; set; }
        public string html_url { get; set; }

        public string public_repos { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }



        public override string ToString(){
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