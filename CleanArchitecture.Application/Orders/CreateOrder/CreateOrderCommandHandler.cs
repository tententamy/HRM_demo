using AutoMapper;
using CleanArchitecture.Domain.Common.Exceptions;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Orders.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, OrderDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IProductRepository _productRepository;


        public CreateOrderCommandHandler(IMapper mapper, IOrderRepository orderRepository, IUserRepository userRepository, IOrderDetailRepository orderDetailRepository, IProductRepository productRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _userRepository = userRepository;
            _orderDetailRepository = orderDetailRepository;
            _productRepository = productRepository;
        }


        public async Task<OrderDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindByIdAsync(request.UserId);
            if (user == null)
            {
                throw new NotFoundException("User does not exist");
            }
            decimal TotalPrice = 0;
            foreach (var items in request.Items)
            {
                var product = await _productRepository.FindByIdAsync(items.ProductId);
                if (product == null)
                {
                    throw new NotFoundException($"Not found Product with Id {items.ProductId}");
                }
                if (items.Volume == 0)
                {
                    throw new Exception("Volume can't be 0");
                }
                TotalPrice = product.Price * items.Volume;
            }

            var order = new Order
            {
                TotalPrice = TotalPrice,
                UserId = request.UserId,
            };

            var responseItems = new List<ResponseItem>();

            _orderRepository.Add(order);
            await _orderRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            foreach (var item in request.Items)
            {
                var product = await _productRepository.FindByIdAsync(item.ProductId);
                var reponseItem = new ResponseItem
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    Volume = item.Volume,
                    TotalPrice = item.Volume * product.Price,
                };

                responseItems.Add(reponseItem);


                var orderDetail = new OrderDetail
                {
                    OrderId = order.Id,
                    ProductId = product.Id,
                    Quantity = item.Volume,
                    UnitPrice = (double)product.Price,
                    Price = item.Volume * product.Price
                };

                _orderDetailRepository.Add(orderDetail);
                await _orderDetailRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            }

            var orderDto = new OrderDto
            {
                Id = order.Id,
                Total = order.TotalPrice,
                Items = responseItems,
            };

            return orderDto;
        }
    }
}
