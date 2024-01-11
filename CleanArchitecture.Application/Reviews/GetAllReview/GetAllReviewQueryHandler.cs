using AutoMapper;
using CleanArchitecture.Domain.Common.Exceptions;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Reviews.GetAllReview
{
    public class GetAllReviewQueryHandler : IRequestHandler<GetAllReviewQuery, List<ReviewDto>>
    {
        private readonly IMapper _mapper;
        private readonly IReviewRepository _reviewRepository;

        public GetAllReviewQueryHandler(IMapper mapper, IReviewRepository reviewRepository)
        {
            _mapper = mapper;
            _reviewRepository = reviewRepository;
        }

        public async Task<List<ReviewDto>> Handle(GetAllReviewQuery request, CancellationToken cancellationToken)
        {
            var listReview = await _reviewRepository.FindAllAsync(cancellationToken);
            if(listReview == null) 
            {
                throw new NotFoundException("Does Not Any Review");
            }
            return listReview.MapToReviewDtoList(_mapper);
        }
    }
}
