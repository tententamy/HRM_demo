using CleanArchitecture.Application.Orders.GetOrderById;
using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Orders.GetAllOrders
{

    public class GetAllOrdersQueryValidator : AbstractValidator<GetAllOrdersQuery>
    {
        public GetAllOrdersQueryValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
        }
    }
}
