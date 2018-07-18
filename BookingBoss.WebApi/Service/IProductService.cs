using BookingBoss.WebApi.Models;
using BookingBoss.WebApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingBoss.WebApi.Service
{
    public interface IProductService
    {
        IEnumerable<ProductEventVM> GetAllProducts();
        bool SaveProducts(List<ProductEvent> products);
        ProductEventVM GetProduct(ulong ProductID);
    }
}
