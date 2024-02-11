# usage Open package manager console and paste 
#  .\PublishScript.ps1
# publish the projects...

echo 'publish the projects...'
powershell.exe dotnet publish CoreLoanManagement.WebSite -c Release
powershell.exe dotnet publish CoreLoanManagement.WebApi -c Release

echo 'copy the files to iis folder'
robocopy .\CoreLoanManagement.WebSite\bin\Release\net8.0\publish C:\inetpub\wwwroot\CoreLoanManagement.WebSite\
robocopy .\CoreLoanManagement.WebApi\bin\Release\net8.0\publish C:\inetpub\wwwroot\CoreLoanManagement.WebApi\

echo 'copy the web.config files to the root iis folder'
xcopy /Y .\CoreLoanManagement.WebSite\Configuration\Web.config C:\inetpub\wwwroot\CoreLoanManagement.WebSite\
xcopy /Y .\CoreLoanManagement.WebApi\Configuration\web.config C:\inetpub\wwwroot\CoreLoanManagement.WebApi\

echo 'copy the appsettings.json'
xcopy /Y .\CoreLoanManagement.WebSite\appsettingsSql.json C:\inetpub\wwwroot\CoreLoanManagement.WebSite\appsettings.json

echo 'iisreset...'
iisreset

echo 'open web api in browser'
[system.Diagnostics.Process]::Start("chrome","http://localhost/CoreLoanManagement.WebApi/swagger/index.html")

echo 'open web site in browser'
[system.Diagnostics.Process]::Start("chrome","http://localhost/CoreLoanManagement.WebSite/")
