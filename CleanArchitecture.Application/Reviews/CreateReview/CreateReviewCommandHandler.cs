using AutoMapper;
using CleanArchitecture.Domain.Repositories;
using CleanArchitecture.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common.Exceptions;

namespace CleanArchitecture.Application.Reviews.CreateReview
{
    public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IReviewRepository _reviewRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;

        public CreateReviewCommandHandler(IMapper mapper, IReviewRepository reviewRepository, IUserRepository userRepository, IProductRepository productRepository)
        {
            _mapper = mapper;
            _reviewRepository = reviewRepository;
            _userRepository = userRepository;
            _productRepository = productRepository;
        }

        public async Task<Guid> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {

            var user = await _userRepository.FindByIdAsync(request.UserId, cancellationToken);
            if (user == null)
            {
                throw new NotFoundException("User Does Not Exist");
            }

            var product = await _productRepository.FindByIdAsync(request.ProductId, cancellationToken);
            if (product == null)
            {
                throw new NotFoundException("Product Does Not Exits");
            }

            var review = new Review()
            {
                rating = request.Rating,
                comment = request.Comment,
                ProductId = request.ProductId,
                UserId = request.UserId,
            };
            _reviewRepository.Add(review);
            await _reviewRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return review.Id;
        }
    }
}