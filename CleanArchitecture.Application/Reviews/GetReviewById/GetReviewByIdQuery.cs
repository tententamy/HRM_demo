using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Reviews.GetReviewById
{
    public class GetReviewByIdQuery : IRequest<ReviewDto>, IQuery
    {
        public GetReviewByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}