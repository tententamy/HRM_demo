using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Vendors
{
    public static class VendorMappingExstention
    {
        public static VendorDTO MapToVendorDTO(this Domain.Entities.Vendor projectFrom, IMapper mapper)
            => mapper.Map<VendorDTO>(projectFrom);
        public static List<VendorDTO> MapToVendorDtoList(this IEnumerable<Domain.Entities.Vendor> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToVendorDTO(mapper)).ToList();
    }
}
