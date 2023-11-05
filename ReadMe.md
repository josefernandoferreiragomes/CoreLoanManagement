# Loan Management FullStack exercise

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