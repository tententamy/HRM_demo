using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities
{
    public class OrderDetail : Entity
    {
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        [Column(TypeName = "numeric(10, 2)")]
        public decimal Price { get; set; }

        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }
        public Guid OrderId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        public Guid ProductId { get; set; }
    }
}
