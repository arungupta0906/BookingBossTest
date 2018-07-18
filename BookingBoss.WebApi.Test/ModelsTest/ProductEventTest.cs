using BookingBoss.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BookingBoss.WebApi.Test.ModelsTest
{
    public class ProductEventTest
    {
        [Fact]
        public void CreateProductEventObject()
        {
            var result = new ProductEvent();
            Assert.NotNull(result);
        }
    }
}
