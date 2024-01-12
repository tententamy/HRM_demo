using MediatR;
using System;
using CleanArchitecture.Application.Common.Interfaces;

namespace CleanArchitecture.Application.Orders.DeleteOrder
{
    public class DeleteOrderCommand : IRequest<bool>, ICommand
    {
        public DeleteOrderCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
