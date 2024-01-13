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
            Id = id;
            NameUpdated = Name;
            addressUpdated = Address;
            phoneNumberUpdated = PhoneNumber;
        }
        public string? phoneNumberUpdated { get; set; }
        public string? addressUpdated { get; set; }
        public Guid Id { get; set; }
        public string? NameUpdated { get; set; }
    }
}
