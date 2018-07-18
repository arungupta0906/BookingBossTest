using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookingBoss.WebApi.Models
{
    public class Product
    {
        public ulong Id { get; set; }
        public string Name { get; set; }
        public uint Quantity { get; set; }
        public double Sale_Amount { get; set; }

        public Guid ProductEventId { get; set; }
        [ForeignKey("ProductEventId")]
        public virtual ProductEvent ProductEvent { get; set; }
    }
}
