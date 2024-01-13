using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities
{
    public class Review : Entity
    {
        public string comment {  get; set; }
        [Range(1, 5)]
        public int rating { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("ProductId")]
        public Guid UserId { get; set; }
        public virtual Product Product { get; set; }
        public Guid ProductId { get; set; }
    }
}
