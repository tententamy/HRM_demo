using CleanArchitecture.Domain.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Products.DeleteProduct
{
    public class DeleteProductValidator :  AbstractValidator<DeleteProductCommand>
    {
        private readonly IProductRepository _repository;
        public DeleteProductValidator(IProductRepository repository)
        {
            _repository = repository;

            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(x => x.productId)
                .MustAsync(async (id, cancellationToken) => await _repository.FindByIdAsync(id, cancellationToken) != null)
                .WithMessage("There is no Product with that id.");
        }

    }
}
