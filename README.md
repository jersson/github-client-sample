# github-client-sample
![.NET Core](https://github.com/jersson/github-client-sample/workflows/GitHubClient%20Sample/badge.svg?branch=master)

This is a dotnetcore library I've created as an example to connect and get github information. It's kinda one of my pet projects :innocent:

## What's the folder structure?
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

## What does the code do?
I've created a connector to the [GitHub API](https://developer.github.com/v3/), I'm using the [RestSharp](http://restsharp.org/getting-started/#basic-usage) library for get the information that I need to consume.

The `GitHubConnector` class contains all you need to get the required information.
```c#
public class GitHubConnector
{
    private IRestClient _client { get; set; }

    public GitHubConnector(): this(new RestClient()) {}

    public GitHubConnector(IRestClient client){
        var uri = new Uri("https://api.github.com/");

        _client =  client;
        _client.BaseUrl = uri;
    }
    public GitHubUserInformation GetUserInformation(string username)
    {
        var request = new RestRequest("users/{username}", Method.GET);
        request.AddUrlSegment("username", username);

        var response = _client.Execute<GitHubUserInformation>(request);

        return response.Data;
    }
}
``` 

## how to compile the code?
You can use the `dotnet build` command in any folder, even in the root folder
```
Build succeeded.
    0 Warning(s)
    0 Error(s)

Time Elapsed 00:00:02.12
```

## how to run the code?
This is a class library so you can run a console client I built, it's just an example and you can use the `dotnet run` command:
```
GitHubConsoleDemo$ dotnet run
Put your GitHub username: jersson
Hello jersson this is your GitHub information:
* login: jersson
* name: Jersson Dongo
* company: McKinsey & Company
* blog: http://jersson.net
* html_url: https://github.com/jersson
* public_repos: 12
* created_at: 2012-02-20T01:07:28Z
* updated_at: 2020-06-12T19:19:08Z
```

## how to test the code?
You can run the `dotnet test` command in the root folder or the test folder:
```
$ dotnet test
Test Run Successful.
Total tests: 1
     Passed: 1
 Total time: 1.0996 Seconds
```

I'm using [**xUnit**](https://xunit.net/docs/getting-started/netcore/cmdline) for the test cases I've written and [**moq**](https://github.com/Moq/moq4/wiki/Quickstart) to mock the use of the `RestClient` object, this is a really [interesting post](https://softchris.github.io/pages/dotnet-moq.html) about moq. If you want to read about dependency injection, you can go to [this post](https://www.c-sharpcorner.com/UploadFile/85ed7a/dependency-injection-in-C-Sharp/).