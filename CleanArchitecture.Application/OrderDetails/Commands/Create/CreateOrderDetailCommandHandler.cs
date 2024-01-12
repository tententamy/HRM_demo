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

namespace CleanArchitecture.Application.OrderDetails.Commands.Create
{
    public class CreateOrderDetailCommandHandler : IRequestHandler<CreateOrderDetailCommand, bool>
    {
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IMapper _mapper;
        public CreateOrderDetailCommandHandler(
            IMapper mapper, 
            IProductRepository productRepository, 
            IOrderDetailRepository orderDetailRepository,
            IOrderRepository orderRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
        }
        public async Task<bool> Handle(CreateOrderDetailCommand request, CancellationToken cancellationToken)
        {
            if(await _orderRepository.FindByIdAsync(request.OrderId, cancellationToken) == null)
            {
                throw new NotFoundException($"Does not exits Order with Id {request.OrderId}");
            }
            if (await _productRepository.FindByIdAsync(request.ProductId, cancellationToken) == null)
            {
                throw new NotFoundException($"Does not exits Product with Id {request.ProductId}");
            }
            var orderdetail = new OrderDetail
            {
                OrderId = request.OrderId,
                ProductId = request.ProductId,
                UnitPrice = request.UnitPrice,
                Quantity = request.Quantity,
                Price = request.Price,
            };
            _orderDetailRepository.Add(orderdetail);
            var result= await _orderDetailRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if(result > 0)
            {
                return true;
            }
            return false;
        }
    }
}
