using AutoMapper;
using CleanArchitecture.Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Vendors
{
    public class VendorDTO : IMapFrom<Domain.Entities.Vendor>
    {
        public VendorDTO()
        {

        }

        public static VendorDTO Create(Guid Id, string Name, string Address, string PhoneNumber)
        {
            return new VendorDTO
            {
                Id = Id,
                Name = Name,
                Address = Address,
                PhoneNumber = PhoneNumber
            };
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Vendor, VendorDTO>();
        }
    }
}
