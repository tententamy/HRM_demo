using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities
{
    public class Order : Entity
    {
        [Column(TypeName = "numeric(10, 2)")]
        public decimal TotalPrice { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public Guid UserId { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
