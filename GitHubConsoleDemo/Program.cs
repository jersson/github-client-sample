using System;

using GitHubClient;
using GitHubClient.Types;


namespace GitHubConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Put your GitHub username: ");
            var username = Console.ReadLine();

            var connector = new GitHubConnector();
            UserInformation gitHubInformation = connector.GetUserInformation(username);

            Console.WriteLine($"Hello {username}, this is your GitHub information:");
            Console.WriteLine(gitHubInformation);
        }
    }
}
