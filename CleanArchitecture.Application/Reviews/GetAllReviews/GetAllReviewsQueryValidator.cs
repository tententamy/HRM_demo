
using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Reviews.GetAllReviews
{
    public class GetAllReviewsQueryValidator : AbstractValidator<GetAllReviewsQuery>
    {
        public GetAllReviewsQueryValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            
        }

    }
}