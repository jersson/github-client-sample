using System.Text;
using System.Linq;

namespace GitHubClient.Types
{
    public class UserInformationProperty
    {
        public UserInformationProperty()
        {
            Name = string.Empty;
            Type = string.Empty;
        }
        public UserInformationProperty(string name, string type)
        {
            Name = name;
            Type = type;
        }

        public string Name { get; set; }

        public string Type { get; set; }

        public override string ToString()
        {   if (Name.Trim().Length == 0 && Type.Trim().Length == 0) 
                return string.Empty;
            
            return $"* {Name}: {Type}";
        }
    }
}