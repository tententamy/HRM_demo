using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Orders.GetOrderById;
using CleanArchitecture.Application.Reviews;
using MediatR;
using System;

namespace CleanArchitecture.Application.Orders.GetOrderById
{
    public class GetOrderByIdQuery : IRequest<OrderDto>, IQuery
    {
        public GetOrderByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}