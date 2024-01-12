using AutoMapper;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Orders.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, bool>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public DeleteOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.FindByIdAsync(request.Id, cancellationToken);
            if (order == null)
            {
                return false;
            }

            _orderRepository.Remove(order);
            await _orderRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
