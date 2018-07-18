# BookingBossTest

This code is written using Visual Studio 2017 in .NET Core 2.1

* Use Microsoft.Extensions.DependencyInjection for Dependency Injection
* Use In Memomry Database for DB Operation
* Use Microsoft.Extensions.Logging for logging 
* Use Serilog nuget package to write logs in file 

Web API consists of three operation:
  1. Saving the Product List with unique Id and time stamp.
  2. Get the list of all the products with unique id and time stamp.
  3. Get the product by product id.
  
Unit Test
---------
1. Use xUnit and Moq framework for unit testing
2. Use In Memomry Database for unit testing
3. Unit testing covers:
    - Model object creation
    - Database operation using Product Service
    - Product Controller methods
