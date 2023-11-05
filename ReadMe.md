# Upgrade Loan Management exercise app to .Net Core

Create new projects in .net core 6.0 for each .net framework project

Start from base dependencies and then follow through

Copy all classes and folders to the new projects

Replace web.config / app.config for appsettings.json

Use built-in dependency injection

Re-add the api's

## Loan Management FullStack exercise

## Architecture
### Databases:
	LoanManagement.DB.Dao.LoanManagementDBContext
	LoanManagementDB

## Data Access Layer
### LoanManagement.DB
	LoanManagementDBContext
		Database Access through EntityFramework
	LoanManagementDBExecuter
		Database Access through SqlDataReader

## Integration layer:
### LoanManagement.Web
	http://localhost:51852/Api/LoanManager/
	http://localhost:51852/Api/LoanInstallment/
	http://localhost:51852/Api/CustomerItem/
	
	Technical Features
		Dependency Injection
		Logging
		Mappers
		Swagger

	Patterns
		Singleton
		Repository

## Presentation layer:
### LoanManagement.WebSite
	http://localhost:61104/
	
	Technical Features
		Dependency Injection
		Generics		

	Patterns
		Singleton
		Repository
		Observable
		Factory

## Libraries
### LoanManagement.Platform
	Nlog
	Unity
	AutoMapper