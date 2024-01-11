using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        [Column(TypeName = "numeric(10, 2)")]
        public decimal Price { get; set; }
        public string Brand { get; set; }

        [ForeignKey("VendorId")]
        public virtual Vendor Vendor { get; set; }
        public Guid VendorId { get; set; }


    }
}
