using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = new Guid();
            CreateTimes = DateTime.Now;
            LastUpdateTimes = DateTime.Now;
        }

        [Key]
        public Guid Id { get; set; }
        public DateTime CreateTimes { get; set; }
        public DateTime LastUpdateTimes { get; set; }
    }
}

