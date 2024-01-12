using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using System;

namespace CleanArchitecture.Application.Orders.CreateOrder
{
    public class CreateOrderCommand : IRequest<Guid>, ICommand
    {
        public CreateOrderCommand(decimal totalPrice, Guid userId)
        {
            TotalPrice = totalPrice;
            UserId = userId;
        }

        public decimal TotalPrice { get; set; }
        public Guid UserId { get; set; }
    }
}
