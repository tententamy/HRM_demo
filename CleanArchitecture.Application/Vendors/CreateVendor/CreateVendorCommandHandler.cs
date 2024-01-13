using AutoMapper;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Vendors.CreateVendor
{
    public class CreateVendorCommandHandler : IRequestHandler<CreateVendorCommand, VendorDTO>
    {
        private readonly IVendorRepository _repository;
        private readonly IMapper _mapper;
        public CreateVendorCommandHandler(IVendorRepository vendorRepository, IMapper mapper)
        {
            _repository = vendorRepository;
            _mapper = mapper;
        }

        public async Task<VendorDTO> Handle(CreateVendorCommand request, CancellationToken cancellationToken)
        {
            var vendor = new Domain.Entities.Vendor
            {
                Address = request.Address,
                PhoneNumber = request.phoneNumber,
                Name = request.name
            };
            _repository.Add(vendor);
            await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return vendor.MapToVendorDTO(_mapper);
        }
    }
}
