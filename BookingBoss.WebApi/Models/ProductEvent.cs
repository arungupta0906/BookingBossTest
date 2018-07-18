using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingBoss.WebApi.Models
{
    public class ProductEvent
    {
        public Guid Id { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        public virtual ICollection<Product> Products { get; set; }
    }
}
