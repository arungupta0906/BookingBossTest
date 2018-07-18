using BookingBoss.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingBoss.WebApi.ViewModel
{
    public class ProductVM
    {
        public ulong Id { get; set; }
        public string Name { get; set; }
        public uint Quantity { get; set; }
        public double Sale_Amount { get; set; }
    }
}
