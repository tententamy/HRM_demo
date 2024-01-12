using AutoMapper;
using CleanArchitecture.Domain.Repositories;
using CleanArchitecture.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common.Exceptions;

namespace CleanArchitecture.Application.Orders.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;

        public CreateOrderCommandHandler(IMapper mapper, IOrderRepository orderRepository, IUserRepository userRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _userRepository = userRepository;
        }

        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindByIdAsync(request.UserId, cancellationToken);
            if (user == null)
            {
                throw new NotFoundException("User Does Not Exist");
            }

            var order = new Order
            {
                TotalPrice = request.TotalPrice,
                UserId = request.UserId
            };

            _orderRepository.Add(order);
            await _orderRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return order.Id;
        }
    }
}
