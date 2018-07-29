using System;

using GitHubClient;


namespace GitHubConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Put your GitHub username: ");
            var username = Console.ReadLine();

            var connector = new GitHubConnector();
            var gitHubInformation = connector.GetUserInformation(username);

            Console.WriteLine("Hello {0} this is your GitHub information:", username);
            Console.WriteLine(gitHubInformation);
        }
    }
}
