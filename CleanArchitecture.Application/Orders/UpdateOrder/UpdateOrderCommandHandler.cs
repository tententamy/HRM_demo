using AutoMapper;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Reviews;
using CleanArchitecture.Domain.Common.Exceptions;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Orders.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, OrderDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public UpdateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<OrderDto> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.FindByIdAsync(request.Id, cancellationToken);
            if (order == null)
            {
                throw new NotFoundException("Order Does Not Exist");
            }

            order.TotalPrice = request.TotalPrice;

            _orderRepository.Update(order);
            await _orderRepository.UnitOfWork.SaveChangesAsync();

            return _mapper.Map<OrderDto>(order);
        }
    }
}
