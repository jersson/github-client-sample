# github-client-sample
![.NET Core](https://github.com/jersson/github-client-sample/workflows/GitHubClient%20Sample/badge.svg?branch=master)
This is a dotnetcore library I've created as an example to connect and get github information. It's kinda one of my pet projects :innocent:

## what's the folder structure?
```
.
├── GitHubClient
│   ├── GitHubClient.csproj
│   ├── GitHubConnector.cs
│   └── GitHubUserInformation.cs
├── GitHubClientTest
│   ├── GitHubClientTest.csproj
│   └── GitHubConnectorTest.cs
├── GitHubConsoleDemo
│   ├── GitHubConsoleDemo.csproj
│   └── Program.cs
├── README.md
└── github-client-sample.sln
```

## how to build the code?
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
 Total time: 2.0739 Seconds
```