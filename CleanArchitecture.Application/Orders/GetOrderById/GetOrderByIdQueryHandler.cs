using AutoMapper;
using CleanArchitecture.Application.Orders.CreateOrder;
using CleanArchitecture.Application.Orders.GetOrderById;
using CleanArchitecture.Application.Reviews;
using CleanArchitecture.Domain.Common.Exceptions;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Orders.GetByIdOrder
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetOrderByIdQueryHandler(IOrderRepository orderRepository, IMapper mapper, IOrderDetailRepository orderDetailRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<OrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.FindByIdAsync(request.Id, cancellationToken);

            if (order == null)
            {
                throw new NotFoundException("Order Does not Exist");
            }

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

            return orderDto;
        }
    }
}