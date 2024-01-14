using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Products.UpdateProduct
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
    {

        public UpdateProductValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("ProductId must not be empty");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Price must not be empty");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description must not be empty");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name must not be empty");
            RuleFor(x => x.Brand).NotEmpty().WithMessage("Brand must not be empty");
            RuleFor(x => x.VendorId).NotEmpty().WithMessage("VendorId must not be empty");
        }
    }
}