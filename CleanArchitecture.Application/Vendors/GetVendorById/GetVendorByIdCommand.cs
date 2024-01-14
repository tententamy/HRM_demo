using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Vendors.GetVendorById
{
    public class GetVendorCommand : IRequest<VendorDTO>
    {
        public GetVendorCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
