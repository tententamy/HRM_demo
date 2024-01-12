using AutoMapper;
using CleanArchitecture.Application.Orders.GetOrderById;
using CleanArchitecture.Application.Reviews;
using CleanArchitecture.Domain.Common.Exceptions;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Orders.GetByIdOrder
{
    public class GetByIdOrderQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetByIdOrderQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<OrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.FindByIdAsync(request.Id, cancellationToken);
            if (order == null)
            {
                throw new NotFoundException("Order Does not Exist");
            }
            return _mapper.Map<OrderDto>(order);
        }
    }
}
