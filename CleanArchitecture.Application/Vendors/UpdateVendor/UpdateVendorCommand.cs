using MediatR;
using CleanArchitecture.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Vendors.UpdateVendor
{
    public class UpdateVendorCommand : IRequest<VendorDTO>, ICommand
    {

        public UpdateVendorCommand(Guid id, string Name, string PhoneNumber, string Address)
        {
            this.Id = id;
            this.Name = Name;
            this.Address = Address;
            this.PhoneNumber = PhoneNumber;
        }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public Guid Id { get; set; }
        public string? Name { get; set; }
    }
}
