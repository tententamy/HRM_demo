using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Reviews.UpdateReview
{
    public class UpdateReviewCommand : IRequest<ReviewDto>, ICommand
    {
        public UpdateReviewCommand(Guid Id, string comment, int rating)
        {
            this.Id = Id;
            this.comment = comment;
            this.rating = rating;
        }

        public Guid Id { get; set; }
        public string comment { get; set; }
        public int rating { get; set; }
    }
}