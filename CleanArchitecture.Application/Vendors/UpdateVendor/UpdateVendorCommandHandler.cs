using AutoMapper;
using CleanArchitecture.Domain.Common.Exceptions;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Vendors.UpdateVendor
{
    public class UpdateVendorCommandHandler : IRequestHandler<UpdateVendorCommand, VendorDTO>
    {
        private readonly IVendorRepository _vendorRepository;
        private readonly IMapper _mapper;
        public UpdateVendorCommandHandler(IVendorRepository vendorRepository, IMapper mapper)
        {
            _vendorRepository = vendorRepository;
            _mapper = mapper;
        }

        public async Task<VendorDTO> Handle(UpdateVendorCommand request, CancellationToken cancellationToken)
        {
            var vendor = await _vendorRepository.FindByIdAsync(request.Id, cancellationToken);
            if (vendor == null)
                throw new NotFoundException($"Vendor with ID : {request.Id} is not found");

            vendor.Name = request.Name;
            vendor.PhoneNumber = request.PhoneNumber ;
            vendor.Address = request.Address;

            _vendorRepository.Update(vendor);
            await _vendorRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return vendor.MapToVendorDTO(_mapper);
        }
    }
}
