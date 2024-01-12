using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Reviews;
using MediatR;
using System.Collections.Generic;

namespace CleanArchitecture.Application.Orders.GetOrders
{
    public class GetOrdersQuery : IRequest<List<OrderDto>>, IQuery
    {
        public GetOrdersQuery() { }
    }
}
