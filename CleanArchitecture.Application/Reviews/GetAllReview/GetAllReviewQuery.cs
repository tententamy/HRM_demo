using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Reviews.GetAllReview
{
    public class GetAllReviewQuery : IRequest<List<ReviewDto>>, IQuery
    {
        public GetAllReviewQuery() { }
    }
}
