using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Products.GetProducts
{
    public class GetProductValidator :  AbstractValidator<GetProductsQuery>

    {

        public GetProductValidator() {
            
        }
    }
}
