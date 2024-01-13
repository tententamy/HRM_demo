using CleanArchitecture.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Vendors.DeleteVendor
{
    public class DeleteVendorCommand : IRequest<VendorDTO>
    {
        public DeleteVendorCommand(Guid id)
        {
            this.Id = id;
        }
        public Guid Id { get; set; }
    }
}
