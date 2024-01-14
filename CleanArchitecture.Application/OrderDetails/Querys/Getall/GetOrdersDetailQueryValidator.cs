using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.OrderDetails.Querys.FindByOrderId
{
    public class GetOrdersDetailQueryValidator: AbstractValidator<GetOrdersDetailQuery>
    {
        public GetOrdersDetailQueryValidator()
        {
        }
    }
}
