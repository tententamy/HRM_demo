using AutoMapper;
using CleanArchitecture.Application.Orders;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Reviews
{
    public static class ReviewDtoMappingExtension
    {
        public static ReviewDto MapToReviewDto(this Review projectFrom, IMapper mapper)
            => mapper.Map<ReviewDto>(projectFrom);

        public static List<ReviewDto> MapToReviewDtoList(this IEnumerable<Review> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToReviewDto(mapper)).ToList();
    }
}
