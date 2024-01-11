using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Reviews.CreateReview
{
    public class CreateReviewCommand : IRequest<Guid>, ICommand
    {
        public CreateReviewCommand(string comment, int rating, Guid userId, Guid productId)
        {
            Comment = comment;
            Rating = rating;
            UserId = userId;
            ProductId = productId;
        }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
    }
}
