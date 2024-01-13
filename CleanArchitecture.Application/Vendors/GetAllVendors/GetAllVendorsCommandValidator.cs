using CleanArchitecture.Application.Vendors.GetVendorById;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Vendors.GetAllVendors
{
    public class GetAllVendorsCommandValidator : AbstractValidator<GetAllVendorsCommand>
    {
        public GetAllVendorsCommandValidator()
        {
        }

    }
}
