Online Shop's Cabify
===========

You can visit it in: appmuestra.com

Online Shop's Cabify is one simulation of online shop. The application will  check the total amount of your purchase with the actuality discounts of the products.

The source code is production-ready. It is easy to grow and easy to add new functionality.

## Requirements for start-up

	* Visual Studio 2017
	* IIS 
	* Microsoft SQL Server

## Front end

	* HTML
	* CSS
	* Bootstrap


## Application's principles

	* SOLID
	* KISS
	* DRY
	* BDD (SpecFlow - Business Requirements)
	* TDD
	* Patterns: MVC

## Application logic

	* Dependency Injection
	* IoC Containers (Ninject - Manager of lifetime of the objects)
	* Unit Tests
	* Integration Tests
	* LINQ to SQL


## Clarification

	I use dependency injection so that I can use another to inject the dependencies of the objects. The injector, normally, is an ioc container who deals with injecting the necessary dependencies and taking care of the lifetime of the objects created (dependencies).

	The creation of two types of models (DTO, DAO) is because the controller does not have to directly modify the models of the database (DAO), but through a copy (DTO).