using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Products.GetProductById
{
    public class GetProductByIdValidator : AbstractValidator<GetProductByIdQuery>
    {

        public GetProductByIdValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("Id can not be empty");
        }
    }
}