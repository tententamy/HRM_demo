using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.OrderDetails.Commands.Update
{
    public class UpdateOrderDetailCommandHandler : IRequestHandler<UpdateOrderDetailCommand, bool>
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        public UpdateOrderDetailCommandHandler(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }
        public async Task<bool> Handle(UpdateOrderDetailCommand request, CancellationToken cancellationToken)
        {
            var orderdetail = await _orderDetailRepository.FindByIdAsync(request.Id, cancellationToken);
            if (orderdetail == null)
            {
                throw new DirectoryNotFoundException("OrderDetail does not exits");
            }
            orderdetail.UnitPrice = request.UnitPrice;
            orderdetail.Quantity = request.Quantity;
            orderdetail.Price = request.Price;
            _orderDetailRepository.Update(orderdetail);
            var result = await _orderDetailRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if(result> 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
