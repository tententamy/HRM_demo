using AutoMapper;
using CleanArchitecture.Application.Reviews;
using CleanArchitecture.Domain.Common.Exceptions;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Orders.GetOrders
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetOrdersQuery, List<OrderDto>>
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;

        public GetAllOrdersQueryHandler(IMapper mapper, IOrderRepository orderRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        public async Task<List<OrderDto>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            var listOrders = await _orderRepository.FindAllAsync(cancellationToken);
            if (listOrders == null)
            {
                throw new NotFoundException("No Orders Found");
            }

            return listOrders.MapToOrderDtoList(_mapper);
        }
    }
}
