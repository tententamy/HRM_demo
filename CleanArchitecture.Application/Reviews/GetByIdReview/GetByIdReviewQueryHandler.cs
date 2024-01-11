using AutoMapper;
using CleanArchitecture.Domain.Common.Exceptions;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Reviews.GetByIdReview
{
    public class GetByIdReviewQueryHandler : IRequestHandler<GetByIdReviewQuery,ReviewDto>
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public GetByIdReviewQueryHandler(IReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        public async Task<ReviewDto> Handle(GetByIdReviewQuery request, CancellationToken cancellationToken)
        {
            var review = await _reviewRepository.FindByIdAsync(request.Id,cancellationToken);
            if (review == null)
            {
                throw new NotFoundException("Reviews Does not Exist");
            }
            return review.MapToReviewDto(_mapper);
        }
    }
}
