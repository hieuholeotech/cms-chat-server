# Cms Chat Server
Technologies used:
* .NET 5
* IdentityServer4
* SignalR
* Entity Framework Core

# How to build
* Install the latest .NET 5 SDK
* Config server name, port, database in `appsetting.json` and `appsetting.Development.json` (Cms.WebApplication.API)
* In Nuget Package Console, execute this command: `update-database`
* Set startup project: `Cms.WebApplication.API`