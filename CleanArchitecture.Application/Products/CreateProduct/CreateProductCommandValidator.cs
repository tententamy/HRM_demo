using CleanArchitecture.Domain.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Products.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        private readonly IProductRepository _repository;

        public CreateProductCommandValidator(IProductRepository repository)
        {
            _repository = repository;

            ConfigureValidationRules();
        }


        private void ConfigureValidationRules()
        {
            RuleFor(x => x.Name)
             .NotEmpty().WithMessage("Name must not be empty.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description must not be empty.");

            RuleFor(x => x.VendorId)
                .NotEmpty().WithMessage("VendorId must not be empty.");

            RuleFor(x => x.Price)
           .NotEmpty().WithMessage("Price must not be empty.");

            RuleFor(x => x.Brand)
                .NotEmpty().WithMessage("Brand must not be empty.");
        }



    }
}