using BookingBoss.WebApi.DataContext;
using BookingBoss.WebApi.Models;
using BookingBoss.WebApi.Service;
using BookingBoss.WebApi.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BookingBoss.WebApi.Test.ServiceTest
{
    public class ProductServiceTest
    {
        private WebApiContext _context;
        private readonly Mock<ILogger<ProductService>> _logger;

        public ProductServiceTest()
        {
            _logger = new Mock<ILogger<ProductService>>();

            var options = new DbContextOptionsBuilder<WebApiContext>()
                .UseInMemoryDatabase(databaseName: "ProductList")
                .Options;

            _context = new WebApiContext(options);

            //_context.Products.AddRange(
            //    new Product { Id = 1, Name = "Product 1", Quantity = 5, Sale_Amount = 100.00, ProductEventId = new Guid("2da1a1ad-4d88-4794-b162-e22e5d2cc8dd") },
            //    new Product { Id = 2, Name = "Product 2", Quantity = 4, Sale_Amount = 400.00, ProductEventId = new Guid("2da1a1ad-4d88-4794-b162-e22e5d2cc8dd") },
            //    new Product { Id = 3, Name = "Product 3", Quantity = 8, Sale_Amount = 800.00, ProductEventId = new Guid("13d06b5c-81b8-4132-bab3-e96a47a14bc0") }
            //    );

            //_context.ProductEvents.AddRange(
            //    new ProductEvent { Id = new Guid("2da1a1ad-4d88-4794-b162-e22e5d2cc8dd"), Timestamp = DateTime.UtcNow },
            //    new ProductEvent { Id = new Guid("13d06b5c-81b8-4132-bab3-e96a47a14bc0"), Timestamp = DateTime.UtcNow }
            //    );
        }

        [Fact]
        public void SaveProductsTest()
        {
            var options = new DbContextOptionsBuilder<WebApiContext>()
                .UseInMemoryDatabase(databaseName: "ProductListSaveTest")
                .Options;

            _context = new WebApiContext(options);
            IProductService _service = new ProductService(_context, _logger.Object);
            var lstProducts = GetInputData();
            var result = _service.SaveProducts(lstProducts);
            Assert.True(result);
        }

        [Fact]
        public void SaveProductsNullOrEmptyTest()
        {
            IProductService _service = new ProductService(_context, _logger.Object);
            var resultNull = _service.SaveProducts(null);
            Assert.True(resultNull);
            var resultEmpty= _service.SaveProducts(new List<ProductEvent>());
            Assert.True(resultEmpty);
        }

        [Fact]
        public void GetAllProductsTest()
        {
            IProductService _service = new ProductService(_context, _logger.Object);
            var lstProducts = GetInputData();
            var lstProductVMs = GetOutputData();
            _service.SaveProducts(lstProducts);
            var result = _service.GetAllProducts().ToList();
            Assert.NotNull(result);
            Assert.Equal(lstProductVMs.Count, result.Count);
            foreach (ProductEventVM p in lstProductVMs)
            {
                var temp = result.Where(x => x.Id == p.Id).FirstOrDefault();
                Assert.NotNull(temp);
                Assert.Equal(p.Products.Count, temp.Products.Count);
            }
        }

        [Fact]
        public void GetProductTestNull()
        {
            IProductService _service = new ProductService(_context, _logger.Object);            
            var result = _service.GetProduct(10);
            Assert.Null(result);            
        }

        [Fact]
        public void GetProductTestProductID1()
        {
            IProductService _service = new ProductService(_context, _logger.Object);
            var lstProducts = GetInputData();
            _service.SaveProducts(lstProducts);
            var expectedResult = new ProductEventVM
            {
                Id = new Guid("2da1a1ad-4d88-4794-b162-e22e5d2cc8dd"),
                Timestamp = DateTime.UtcNow,
                Products = new List<ProductVM>
                {
                    new ProductVM { Id = 1, Name = "Product 1", Quantity = 5, Sale_Amount = 100.00 }
                }
            };
            var result = _service.GetProduct(1);
            Assert.NotNull(result);
            Assert.Equal(expectedResult.Id, result.Id);
            Assert.Equal((ulong)1, result.Products[0].Id);
        }

        [Fact]
        public void GetProductTestProductID3()
        {
            IProductService _service = new ProductService(_context, _logger.Object);
            //var lstProducts = GetInputData();
            //_service.SaveProducts(lstProducts);
            var expectedResult = new ProductEventVM
            {
                Id = new Guid("13d06b5c-81b8-4132-bab3-e96a47a14bc0"),
                Timestamp = DateTime.UtcNow,
                Products = new List<ProductVM>
                {
                    new ProductVM { Id = 3, Name = "Product 3", Quantity = 8, Sale_Amount = 800.00 }
                }
            };
            var result = _service.GetProduct(3);
            Assert.NotNull(result);
            Assert.Equal(expectedResult.Id, result.Id);
            Assert.Equal((ulong)3, result.Products[0].Id);
        }

        private List<ProductEvent> GetInputData()
        {
            var lstProducts = new List<ProductEvent>
            {
                new ProductEvent {
                                    Id = new Guid("2da1a1ad-4d88-4794-b162-e22e5d2cc8dd"),
                                    Timestamp = DateTime.UtcNow,
                                    Products = new List<Product>
                                    {
                                        new Product { Id = 1, Name = "Product 1", Quantity = 5, Sale_Amount = 100.00 },
                                        new Product { Id = 2, Name = "Product 2", Quantity = 4, Sale_Amount = 400.00 },
                                    }
                                },
                new ProductEvent {
                                    Id = new Guid("13d06b5c-81b8-4132-bab3-e96a47a14bc0"),
                                    Timestamp = DateTime.UtcNow,
                                    Products = new List<Product>
                                    {
                                        new Product { Id = 3, Name = "Product 3", Quantity = 8, Sale_Amount = 800.00 }
                                    }
                                 }
            };
            return lstProducts;
        }

        private List<ProductEventVM> GetOutputData()
        {
            var lstProductVMs = new List<ProductEventVM>
            {
                new ProductEventVM {
                                    Id = new Guid("2da1a1ad-4d88-4794-b162-e22e5d2cc8dd"),
                                    Timestamp = DateTime.UtcNow,
                                    Products = new List<ProductVM>
                                    {
                                        new ProductVM { Id = 1, Name = "Product 1", Quantity = 5, Sale_Amount = 100.00 },
                                        new ProductVM { Id = 2, Name = "Product 2", Quantity = 4, Sale_Amount = 400.00 },
                                    }
                                },
                new ProductEventVM {
                                    Id = new Guid("13d06b5c-81b8-4132-bab3-e96a47a14bc0"),
                                    Timestamp = DateTime.UtcNow,
                                    Products = new List<ProductVM>
                                    {
                                        new ProductVM { Id = 3, Name = "Product 3", Quantity = 8, Sale_Amount = 800.00 }
                                    }
                                 }
            };
            return lstProductVMs;
        }
    }
}
