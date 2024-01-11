using CleanArchitecture.Application.Reviews.CreateReview;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Reviews.UpdateReview
{
    public class UpdateReviewCommandValidator : AbstractValidator<UpdateReviewCommand>
    {
        
        public UpdateReviewCommandValidator() 
        {
            ConfigureValidationRules();        
        }


        private void ConfigureValidationRules()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("ID is required");
            RuleFor(x => x.comment).NotEmpty().WithMessage("Comment is required");
            RuleFor(x => x.rating).InclusiveBetween(1, 5).WithMessage("Rating must be between 1 and 5");
        }
    }
}
