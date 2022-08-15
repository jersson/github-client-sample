using System.Text;
using System.Linq;

namespace GitHubClient.Types
{
    public class UserInformationProperty
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public UserInformationProperty(): this(string.Empty, string.Empty) {}
        public UserInformationProperty(string name, string type)
        {
            Name = name;
            Type = type;
        }

        public override string ToString()
        {   if (Name.Trim().Length == 0 && Type.Trim().Length == 0)
                return string.Empty;
            
            return $"* {Name}: {Type}";
        }
    }
}