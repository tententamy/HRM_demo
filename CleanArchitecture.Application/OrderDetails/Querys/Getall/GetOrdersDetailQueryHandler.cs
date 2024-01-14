using AutoMapper;
using CleanArchitecture.Domain.Common.Exceptions;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.OrderDetails.Querys.FindByOrderId
{
    public class GetOrdersDetailQueryHandler : IRequestHandler<GetOrdersDetailQuery, List<OrderDetailDTO>>
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IMapper _mapper;
        public GetOrdersDetailQueryHandler(IOrderDetailRepository orderDetailRepository, IMapper mapper)
        {
            _orderDetailRepository = orderDetailRepository;
            _mapper = mapper;
        }
        public async Task<List<OrderDetailDTO>> Handle(GetOrdersDetailQuery request, CancellationToken cancellationToken)
        {
            var orderdetails = await _orderDetailRepository.FindAll(cancellationToken);
            if(orderdetails == null || !orderdetails.Any())
            {
                throw new NotFoundException($"Does not exits any orderdetail");
            }
            return orderdetails.MapToOrderDetailDtoList(_mapper);
        }
    }
}
