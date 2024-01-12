using CleanArchitecture.Domain.Common.Exceptions;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.OrderDetails.Commands.Delete
{
    public class DeleteOrderDetailCommandHandler : IRequestHandler<DeleteOrderDetailCommand, bool>
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        public DeleteOrderDetailCommandHandler(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }
        async Task<bool> IRequestHandler<DeleteOrderDetailCommand, bool>.Handle(DeleteOrderDetailCommand request, CancellationToken cancellationToken)
        {
            var orderdetail = await _orderDetailRepository.FindByIdAsync(request.Id, cancellationToken);
            if(orderdetail == null)
            {
                throw new NotFoundException("Orderdetail does not exits");
            }
            _orderDetailRepository.Remove(orderdetail);
            var result= await _orderDetailRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if(result > 0)
            {
                return true;
            }
            return false;
        }
    }
}
