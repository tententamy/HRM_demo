using AutoMapper;
using CleanArchitecture.Domain.Common.Exceptions;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Vendors.DeleteVendor
{
    public class DeleteVendorCommandHandler : IRequestHandler<DeleteVendorCommand, VendorDTO>
    {
        private readonly IVendorRepository _vendorRepository;
        private readonly IMapper _mapper;
        public DeleteVendorCommandHandler(IVendorRepository vendorRepository, IMapper mapper)
        {
            _vendorRepository = vendorRepository;
            _mapper = mapper;
        }
        public async Task<VendorDTO> Handle(DeleteVendorCommand request, CancellationToken cancellationToken)
        {
            var vendor = await _vendorRepository.FindByIdAsync(request.Id, cancellationToken);
            if (vendor == null)
            {
                throw new NotFoundException("Vendor not found for deletion.");
            }
            _vendorRepository.Remove(vendor);
            await _vendorRepository.UnitOfWork.SaveChangesAsync();
            return vendor.MapToVendorDTO(_mapper);
        }
    }
}
