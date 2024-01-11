using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Reviews.GetByIdReview
{
    public class GetByIdReviewQuery : IRequest<ReviewDto>, IQuery
    {
        public GetByIdReviewQuery(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
