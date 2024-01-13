using AutoMapper;
using CleanArchitecture.Domain.Common.Exceptions;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Vendors.GetAllVendors
{
    public class GetAllVendorsCommandHandler : IRequestHandler<GetAllVendorsCommand, List<VendorDTO>>
    {
        private readonly IVendorRepository _vendorRepository;
        private readonly IMapper _mapper;
        public GetAllVendorsCommandHandler(IVendorRepository vendorRepository, IMapper mapper)
        {
            _vendorRepository = vendorRepository;
            _mapper = mapper;
        }

        public async Task<List<VendorDTO>> Handle(GetAllVendorsCommand request, CancellationToken cancellationToken)
        {
            var vendors = await _vendorRepository.FindAllAsync();
            if (vendors == null)
                throw new NotFoundException($"The list is empty");

            return vendors.MapToVendorDtoList(_mapper);
        }
    }
}
