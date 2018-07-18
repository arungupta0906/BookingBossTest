using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingBoss.WebApi.ViewModel
{
    public class ProductEventVM
    {
        public Guid Id { get; set; }
        public DateTime Timestamp { get; set; }
        public List<ProductVM> Products { get; set; }
    }
}
