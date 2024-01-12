using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Reviews;
using MediatR;
using System;

namespace CleanArchitecture.Application.Orders.UpdateOrder
{
    public class UpdateOrderCommand : IRequest<OrderDto>, ICommand
    {
        public UpdateOrderCommand(Guid id, decimal totalPrice)
        {
            Id = id;
            TotalPrice = totalPrice;
        }

        public Guid Id { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
