using BookingBoss.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BookingBoss.WebApi.Test.ModelsTest
{
    public class ProductTest
    {
        [Fact]
        public void CreateProductObject()
        {
            var result = new Product();
            Assert.NotNull(result);
        }
    }
}
