using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Vendors.CreateVendor
{
    public class CreateVendorCommand : IRequest<VendorDTO>, ICommand
    {
        public CreateVendorCommand(string name, string address, string phonenumber)
        {
            this.name = name;
            this.Address = address;
            this.phoneNumber = phonenumber;
        }
        public string? Address { get; set; }
        public string name { get; set; }
        public string? phoneNumber { get; set; }
    }
}
