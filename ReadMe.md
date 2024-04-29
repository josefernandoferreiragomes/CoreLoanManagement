# Observer Pattern Examples
	Simulate Loan functionality
	example 1: Using amount, interest rate, and duration input text boxes as observables, and installment text box as observer
	example 2: Using duration and installment text boxes as observables, and installment sum as observer

	view:
	\CoreLoanManagement\CoreLoanManagement.WebSite\Views\Loan\SimulateLoan.cshtml
	js:	
	\CoreLoanManagement\CoreLoanManagement.WebSite\wwwroot\lib\SimulateLoan\SimulateLoan.js

	... other featues being documented

# Upgrade Loan Management exercise app to .Net Core

### Create new projects in .net core 6.0 for each .net framework project

### Start from base dependencies and then follow through

### Copy all classes and folders to the new projects. And correct build errors

### Replace web.config / app.config for appsettings.json

### Use built-in dependency injection instead of unity

### Re-add the api's
The various entities, initially with separate api's and url's, have been merged into a single base url, with different entity urls

### Add / correct client-side libraries paths

### WebSite project - add client side library jqueryui

### Add custom script folders/files on the wwwroot/lib folder
And correct paths for custom scripts files

### EF Core
https://learn.microsoft.com/en-us/ef/core/dbcontext-configuration/
      PM > Install-Package Microsoft.EntityFrameworkCore.SqlServer

### Deploy to IIS
	Read file DeployToIIS.md

# Documentation of original solution, for reference...
	
	https://github.com/josefernandoferreiragomes/LoanManagement