using AutoMapper;
using CleanArchitecture.Application.Orders.CreateOrder;
using CleanArchitecture.Domain.Common.Exceptions;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Orders.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, string>
    {
        private readonly IOrderRepository _orderRepository;

        public DeleteOrderCommandHandler(IOrderRepository orderRepository, IUserRepository userRepository)
        {
            
            _orderRepository = orderRepository;
        }


        public async Task<string> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.FindByIdAsync(request.Id, cancellationToken);

            if (order == null)
            {
                throw new NotFoundException("The order does not exist");
            }

            _orderRepository.Remove(order);
            await _orderRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return "Delete Success";
        }
    }
}
