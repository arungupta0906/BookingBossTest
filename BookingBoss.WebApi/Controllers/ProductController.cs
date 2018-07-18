using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BookingBoss.WebApi.DataContext;
using BookingBoss.WebApi.Models;
using BookingBoss.WebApi.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookingBoss.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        private readonly ILogger _logger;

        public ProductController(IProductService service, ILogger<ProductController> logger) 
        {
            _logger = logger;
            _service = service;           
        }

        [HttpGet]
        [Route("GetAllProducts")]
        public IActionResult GetAllProducts()
        {
            try
            {
                var result = _service.GetAllProducts();
                _logger.LogInformation($"Product List extracted succesfully from service.", null);
                return new JsonResult(result.AsEnumerable());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception while getting all products {ex}", null);
                return BadRequest("Could not retrieve data");
            }
        }

        [HttpPost]
        [Route("PutProducts")]
        public IActionResult PutProducts([FromBody]ProductEvent[] products)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                _service.SaveProducts(products.ToList());
                _logger.LogInformation($"Products saves succesfully.", null);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception while getting all products {ex}", null);
                return BadRequest("Could not insert data");
            }
        }

        [HttpGet]
        [Route("GetProduct/{ProductID}")]
        public IActionResult GetProduct(ulong ProductID)
        {
            try
            {
                var result = _service.GetProduct(ProductID);

                if(result != null)
                    return new JsonResult(result);
                else
                    return new JsonResult("No record exists !!!");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception while getting product {ProductID} {ex}", null);
                return BadRequest("Could not retrieve data");
            }
        }
    }
}
