using AutoMapper;
using CleanArchitecture.Domain.Common.Exceptions;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.OrderDetails.Querys.FindById
{
    public class GetOrderDetailQueryHandler : IRequestHandler<GetOrderDetailQuery, OrderDetailDTO>
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IMapper _mapper;
        public GetOrderDetailQueryHandler(IOrderDetailRepository orderDetailRepository, IMapper mapper)
        {
            _orderDetailRepository = orderDetailRepository;
            _mapper = mapper;
        }
        public async Task<OrderDetailDTO> Handle(GetOrderDetailQuery request, CancellationToken cancellationToken)
        {
            var orderdetail = await _orderDetailRepository.FindByIdAsync(request.Id, cancellationToken);
            if (orderdetail == null)
            {
                throw new NotFoundException("OrderDetail does not exits");
            }
            return orderdetail.MapToOrderDetailDto(_mapper);
        }
    }
}
