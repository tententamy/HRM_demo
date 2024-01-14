using AutoMapper;
using CleanArchitecture.Application.Orders.GetOrderById;
using CleanArchitecture.Domain.Common.Exceptions;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Orders.GetAllOrders
{

    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, List<OrderDto>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetAllOrdersQueryHandler(IOrderRepository orderRepository, IMapper mapper, IOrderDetailRepository orderDetailRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<OrderDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.FindAllAsync(cancellationToken);

            if (orders == null)
            {
                throw new NotFoundException("The order list is empty");
            }

            var orderDtos = new List<OrderDto>();

            foreach (var order in orders)
            {
                var orderRepos = await _orderDetailRepository.FindAllAsync(cancellationToken);

                var orderDetails = orderRepos.Where(x => x.OrderId == order.Id).ToList();

                var responseItems = new List<ResponseItem>();
                foreach (var orderDetail in orderDetails)
                {
                    var product = await _productRepository.FindByIdAsync(orderDetail.ProductId);

                    if (product == null)
                    {
                        throw new NotFoundException($"Not found Product with Id {orderDetail.ProductId}");
                    }

                    var responseItem = new ResponseItem()
                    {
                        ProductId = product.Id,
                        ProductName = product.Name,
                        TotalPrice = orderDetail.Quantity * product.Price,
                        Volume = orderDetail.Quantity
                    };
                    responseItems.Add(responseItem);
                }

                var orderDto = new OrderDto
                {
                    Id = order.Id,
                    Total = order.TotalPrice,
                    Items = responseItems
                };

                orderDtos.Add(orderDto);
            }

            return orderDtos;
        }
    }
}
