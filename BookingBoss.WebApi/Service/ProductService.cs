using BookingBoss.WebApi.DataContext;
using BookingBoss.WebApi.Models;
using BookingBoss.WebApi.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookingBoss.WebApi.Service
{
    public class ProductService : IProductService
    {
        private readonly WebApiContext _context;
        private readonly ILogger _logger;

        public ProductService(WebApiContext context, ILogger<ProductService> logger)
        {
            if (_context == null)
                _context = context;
            _logger = logger;            
        }

        public IEnumerable<ProductEventVM> GetAllProducts()
        {
            try
            {
                var result = from events in _context.ProductEvents
                             select new ProductEventVM
                             {
                                 Id = events.Id,
                                 Timestamp = events.Timestamp,
                                 Products = (from product in _context.Products
                                             where product.ProductEventId == events.Id
                                             select new ProductVM
                                             {
                                                 Id = product.Id,
                                                 Name = product.Name,
                                                 Quantity = product.Quantity,
                                                 Sale_Amount = product.Sale_Amount
                                             }).ToList()
                             };
                return result.AsEnumerable();
            }
            catch(Exception ex)
            {
                _logger.LogError($"Exception while getting product list from Service : {ex}", null);
                return null;
            }
        }

        public bool SaveProducts(List<ProductEvent> products)
        {
            try
            {
                if (products == null || products.Count == 0)
                    return true;
                _context.ProductEvents.AddRange(products);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception while saving product list in Service : {ex}", null);
                return false;
            }
        }


        public ProductEventVM GetProduct(ulong ProductID)
        {
            try
            {
                var temp = _context.Products.Where(x => x.Id == ProductID).Include(x => x.ProductEvent).FirstOrDefault();
                if (temp == null)
                    return null;
                var result = new ProductEventVM
                {
                    Id = temp.ProductEvent.Id,
                    Timestamp = temp.ProductEvent.Timestamp,
                    Products = new List<ProductVM>
                    {
                        new ProductVM
                        {
                            Id = temp.Id,
                            Name = temp.Name,
                            Quantity = temp.Quantity,
                            Sale_Amount = temp.Sale_Amount
                        }
                    }
                };
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception while getting product {ProductID} from Service : {ex}", null);
                return null;
            }
        }
        
    }
}
