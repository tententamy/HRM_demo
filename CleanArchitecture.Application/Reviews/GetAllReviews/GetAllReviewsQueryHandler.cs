using AutoMapper;
using CleanArchitecture.Application.Reviews.GetAllReviews;
using CleanArchitecture.Domain.Common.Exceptions;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Reviews.GetAllReviews
{
    public class GetAllReviewsQueryHandler : IRequestHandler<GetAllReviewsQuery, List<ReviewDto>>
    {
        private readonly IMapper _mapper;
        private readonly IReviewRepository _reviewRepository;

        public GetAllReviewsQueryHandler(IMapper mapper, IReviewRepository reviewRepository)
        {
            _mapper = mapper;
            _reviewRepository = reviewRepository;
        }

        public async Task<List<ReviewDto>> Handle(GetAllReviewsQuery request, CancellationToken cancellationToken)
        {
            var listReview = await _reviewRepository.FindAllAsync(cancellationToken);
            if (listReview == null)
            {
                throw new NotFoundException("list is empty");
            }
            return listReview.MapToReviewDtoList(_mapper);
        }
    }
}