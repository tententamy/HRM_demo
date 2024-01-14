using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.OrderDetails.Querys.FindByOrderId
{
    public class GetOrdersDetailQuery: IRequest<List<OrderDetailDTO>>, IQuery
    {
        public GetOrdersDetailQuery()
        {
        }
    }
}
