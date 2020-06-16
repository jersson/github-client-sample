# github-client-sample
![.NET Core](https://github.com/jersson/github-client-sample/workflows/GitHubClient%20Sample/badge.svg?branch=master)

This is a dotnetcore library I've created as an example to connect and get github information. It's kinda one of my pet projects :innocent:

## Summary
- [what's the folder structure?](#whats-the-folder-structure)
- [what does the code do?](#what-does-the-code-do)
- [how to compile the code?](#how-to-compile-the-code)
- [how to run the code?](#how-to-run-the-code)
- [how to test the code?](#how-to-test-the-code)

## what's the folder structure?
```
.
├── GitHubClient
│   ├── GitHubClient.csproj
│   ├── GitHubConnector.cs
│   └── Types.cs
├── GitHubClientTest
│   ├── GitHubClientTest.csproj
│   └── GitHubConnectorTest.cs
├── GitHubConsoleDemo
│   ├── GitHubConsoleDemo.csproj
│   └── Program.cs
├── README.md
└── github-client-sample.sln
```

## what does the code do?
I've created a connector to the [GitHub API](https://developer.github.com/v3/), I'm using the [RestSharp](http://restsharp.org/getting-started/#basic-usage) library for get the information I need to consume and the [Json.NET](https://www.newtonsoft.com/json) library to serialize it.

The `GitHubConnector` class contains all you need to get the required information.
```c#
public class GitHubConnector
{
    private IRestClient _client { get; set; }

    public GitHubConnector(): this(new RestClient()) {}

    public GitHubConnector(IRestClient client){
        var uri = new Uri("https://api.github.com/");

        _client = client;
        _client.BaseUrl = uri;
    }
    public GitHubUserInformation GetUserInformation(string username)
    {
        var request = new RestRequest("users/{username}", Method.GET);
        request.AddUrlSegment("username", username);
        
        var gitHubResponse = _client.Execute(request);
        dynamic gitHubObject = JsonConvert.DeserializeObject(gitHubResponse.Content);

        var result = new GitHubUserInformation{
            Login = gitHubObject.login,
            FullName =  gitHubObject.name,
            Company = gitHubObject.company,
            Blog = gitHubObject.blog,
            GitHubPage = gitHubObject.html_url, 
            PublicRepos = gitHubObject.public_repos,
            CreationDate = gitHubObject.created_at,
            LastUpdate = gitHubObject.updated_at
        };

        return result;
    }
}
``` 

## how to compile the code?
You can use the `dotnet build` command in the root folder
```
Build succeeded.
    0 Warning(s)
    0 Error(s)

Time Elapsed 00:00:01.31
```

## how to run the code?
This is a class library so you can run a console client I built, it's just an example and you can use the `dotnet run --project GitHubConsoleDemo` command in the root folder or the `dotnet run` command in the `GitHubConsoleDemo` folder:
```
Put your GitHub username: jersson
Hello jersson this is your GitHub information:
* Login: jersson
* FullName: Jersson Dongo
* Company: McKinsey & Company
* Blog: http://jersson.net
* GitHubPage: https://github.com/jersson
* PublicRepos: 12
* CreationDate: 02/20/2012 01:07:28
* LastUpdate: 06/13/2020 04:57:14
```

## how to test the code?
You can run the `dotnet test` command in the root folder or the test folder:
```
Test Run Successful.
Total tests: 1
     Passed: 1
 Total time: 1.3628 Seconds
```

I'm using [**xUnit**](https://xunit.net/docs/getting-started/netcore/cmdline) for the test cases I've written and [**moq**](https://github.com/Moq/moq4/wiki/Quickstart) to mock the use of the `RestClient` object, this is a really [interesting post](https://softchris.github.io/pages/dotnet-moq.html) about moq. If you want to read about dependency injection, you can go to [this post](https://www.c-sharpcorner.com/UploadFile/85ed7a/dependency-injection-in-C-Sharp/).