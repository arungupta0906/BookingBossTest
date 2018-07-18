using BookingBoss.WebApi.Controllers;
using BookingBoss.WebApi.Service;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
