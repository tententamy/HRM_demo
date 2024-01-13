using AutoMapper;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Reviews.DeleteReview
{
    public class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommand, bool>
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public DeleteReviewCommandHandler(IReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
        {
            var review = await _reviewRepository.FindByIdAsync(request.Id, cancellationToken);
            if (review == null)
            {
                return false;
            }
            _reviewRepository.Remove(review);
            await _reviewRepository.UnitOfWork.SaveChangesAsync();
            return true;
        }
    }
}