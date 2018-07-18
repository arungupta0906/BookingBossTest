# BookingBossTest

This code is written using Visual Studio 2017 in .NET Core 2.1

Run this Web Api as other normal .NET Web API


* Use Microsoft.Extensions.DependencyInjection for Dependency Injection
* Use In Memomry Database for DB Operation
* Use Microsoft.Extensions.Logging for logging 
* Use Serilog nuget package to write logs in file 

Web API consists of three operation:
  1. Saving the Product List with unique Id and time stamp.
        http://localhost:61247/api/product/PutProducts
          [{
              "id":"2da1a1ad-4d88-4794-b162-e22e5d2cc8dd",
              "timestamp": "2018-07-18T10:29:33.0842849Z",
              "products":[{"name":"Product 1","quantity":5,"sale_Amount":100.0},
                    {"name":"Product 2","quantity":50,"sale_Amount":500.0},
                    {"name":"Product 3","quantity":30,"sale_Amount":300.0},
                    {"name":"Product 4","quantity":500,"sale_Amount":200.0},
                    {"name":"Product 5","quantity":100,"sale_Amount":1000.0}]
            },
            {
              "id":"13d06b5c-81b8-4132-bab3-e96a47a14bc0",
              "timestamp": "2018-07-18T10:29:33.0842849Z",
              "products":[{"name":"Product 10","quantity":5,"sale_Amount":100.0},
                    {"name":"Product 11","quantity":50,"sale_Amount":500.0}]
            }
            ]
  2. Get the list of all the products with unique id and time stamp.
        http://localhost:61247/api/product/GetAllProducts
          [
            {
                "id": "2da1a1ad-4d88-4794-b162-e22e5d2cc8dd",
                "timestamp": "2018-07-18T10:29:33.0842849Z",
                "products": [
                    {
                        "id": 1,
                        "name": "Product 1",
                        "quantity": 5,
                        "sale_Amount": 100
                    },
                    {
                        "id": 2,
                        "name": "Product 2",
                        "quantity": 50,
                        "sale_Amount": 500
                    },
                    {
                        "id": 3,
                        "name": "Product 3",
                        "quantity": 30,
                        "sale_Amount": 300
                    },
                    {
                        "id": 4,
                        "name": "Product 4",
                        "quantity": 500,
                        "sale_Amount": 200
                    },
                    {
                        "id": 5,
                        "name": "Product 5",
                        "quantity": 100,
                        "sale_Amount": 1000
                    }
                ]
            },
            {
                "id": "13d06b5c-81b8-4132-bab3-e96a47a14bc0",
                "timestamp": "2018-07-18T10:29:33.0842849Z",
                "products": [
                    {
                        "id": 6,
                        "name": "Product 10",
                        "quantity": 5,
                        "sale_Amount": 100
                    },
                    {
                        "id": 7,
                        "name": "Product 11",
                        "quantity": 50,
                        "sale_Amount": 500
                    }
                ]
            }
        ]
  3. Get the product by product id.
      http://localhost:61247/api/product/GetProduct/1
          {
                "id": "2da1a1ad-4d88-4794-b162-e22e5d2cc8dd",
                "timestamp": "2018-07-18T10:29:33.0842849Z",
                "products": [
                    {
                        "id": 1,
                        "name": "Product 1",
                        "quantity": 5,
                        "sale_Amount": 100
                    }
                   ]
                 }
  
Unit Test
---------
1. Use xUnit and Moq framework for unit testing
2. Use In Memomry Database for unit testing
3. Unit testing covers:
    - Model object creation
    - Database operation using Product Service
    - Product Controller methods
