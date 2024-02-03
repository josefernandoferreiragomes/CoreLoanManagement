## Deploy to IIS
https://learn.microsoft.com/en-us/aspnet/core/tutorials/publish-to-iis?view=aspnetcore-8.0&tabs=visual-studio#install-the-net-core-hosting-bundle

### create iis application, with publish folder configured
### create iis pool (no managed code)
The user running the pool should be NetworkService
### publish application
>In Package Manager Console, select default project context

#### Web Site
>dotnet publish -c Release

>copy folder ...\CoreLoanManagement\CoreLoanManagement.WebSite\bin\Release\net8.0\publish

>to folder 	C:\inetpub\wwwroot\CoreLoanManagement.WebSite

#### Web Api
...\CoreLoanManagement\CoreLoanManagement.WebApi\bin\Release\net8.0\publish

## Further reading

https://stackoverflow.com/questions/38529123/asp-net-core-404-error-on-iis-10
dotnet publish -c Release -r win-x64 --self-contained

https://stackify.com/how-to-deploy-asp-net-core-to-iis/

https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-aspnetcore-8.0.1-windows-hosting-bundle-installer

	System.InvalidOperationException: Application is running inside IIS process but is not configured to use IIS server.
	https://learn.microsoft.com/en-us/aspnet/core/test/troubleshoot-azure-iis?view=aspnetcore-8.0

	https://stackoverflow.com/questions/58080353/application-is-running-inside-iis-process-but-is-not-configured-to-use-iis-serve