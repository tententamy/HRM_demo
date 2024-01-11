using AutoMapper;
using CleanArchitecture.Domain.Common.Exceptions;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Reviews.UpdateReview
{
    public class UpdateReviewCommandHandler : IRequestHandler<UpdateReviewCommand, ReviewDto>
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public UpdateReviewCommandHandler(IReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        public async Task<ReviewDto> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            var review = await _reviewRepository.FindByIdAsync(request.Id,cancellationToken);
            if (review == null) 
            {
                throw new NotFoundException("Review Does Not Exist");
            }
            review.comment = request.comment;
            review.rating = request.rating;
            _reviewRepository.Update(review);
            await _reviewRepository.UnitOfWork.SaveChangesAsync();
            return review.MapToReviewDto(_mapper);
        }
    }
}
