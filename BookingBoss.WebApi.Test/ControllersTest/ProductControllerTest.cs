using BookingBoss.WebApi.Controllers;
using BookingBoss.WebApi.Models;
using BookingBoss.WebApi.Service;
using BookingBoss.WebApi.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BookingBoss.WebApi.Test.ControllersTest
{
    public class ProductControllerTest
    {
        private readonly Mock<ILogger<ProductController>> _logger;
        private readonly Mock<IProductService> _service;

        public ProductControllerTest()
        {
            _logger = new Mock<ILogger<ProductController>>();
            _service = new Mock<IProductService>();            
        }

        [Fact]
        public void CreateProductControllerObject()
        {
            ProductController result = new ProductController(_service.Object, _logger.Object);
            Assert.NotNull(result);
        }

        [Fact]
        public void GetAllProductsTest()
        {
            _service.Setup(x => x.GetAllProducts()).Returns(GetOutputData());
            ProductController _controller = new ProductController(_service.Object, _logger.Object);
            var result = _controller.GetAllProducts();
            Assert.IsType<JsonResult>(result);
        }

        [Fact]
        public void GetAllProductsTestForEmpty()
        {
            _service.Setup(x => x.GetAllProducts()).Returns(new List<ProductEventVM>());
            ProductController _controller = new ProductController(_service.Object, _logger.Object);
            var result = _controller.GetAllProducts();
            Assert.IsType<NotFoundObjectResult>(result);            
        }

        [Fact]
        public void GetAllProductsTestForNull()
        {
            _service.Setup(x => x.GetAllProducts()).Returns((List<ProductEventVM>)null);
            ProductController _controller = new ProductController(_service.Object, _logger.Object);
            var result = _controller.GetAllProducts();
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void PutProductsSaveSuccess()
        {
            ProductController _controller = new ProductController(_service.Object, _logger.Object);
            _service.Setup(x => x.SaveProducts(It.IsAny<List<ProductEvent>>())).Returns(true);
            var result = _controller.PutProducts(GetInputData().ToArray());
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void PutProductsSaveFail()
        {
            ProductController _controller = new ProductController(_service.Object, _logger.Object);
            _service.Setup(x => x.SaveProducts(It.IsAny<List<ProductEvent>>())).Returns(false);
            var result = _controller.PutProducts(GetInputData().ToArray());
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void GetProductSucess()
        {
            ProductController _controller = new ProductController(_service.Object, _logger.Object);
            _service.Setup(x => x.GetProduct(It.IsAny<ulong>())).Returns(GetSingleOutputData);
            var result = _controller.GetProduct(1);
            Assert.IsType<JsonResult>(result);
        }

        [Fact]
        public void GetProductNotExists()
        {
            ProductController _controller = new ProductController(_service.Object, _logger.Object);
            _service.Setup(x => x.GetProduct(It.IsAny<ulong>())).Returns((ProductEventVM)null);
            var result = _controller.GetProduct(1);
            Assert.IsType<NotFoundObjectResult>(result);
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

        private ProductEventVM GetSingleOutputData()
        {
            var lstProductVM = new ProductEventVM
            {
                Id = new Guid("2da1a1ad-4d88-4794-b162-e22e5d2cc8dd"),
                Timestamp = DateTime.UtcNow,
                Products = new List<ProductVM>
                                    {
                                        new ProductVM { Id = 1, Name = "Product 1", Quantity = 5, Sale_Amount = 100.00 },                                        
                                    }
            };
            return lstProductVM;
        }
    }
}
