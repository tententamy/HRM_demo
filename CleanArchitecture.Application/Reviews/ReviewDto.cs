using AutoMapper;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace CleanArchitecture.Application.Reviews
{
    public class ReviewDto : IMapFrom<Review>
    {

        public ReviewDto() { }

        public string Comment { get; set; }
        public int Rating { get; set; }
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }

        public static ReviewDto CreateReview(string comment, int rating, Guid UserId, Guid ProductId)
        {
            return new ReviewDto
            {
                Comment = comment,
                Rating = rating,
                UserId = UserId,
                ProductId = ProductId
            };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Review, ReviewDto>();
        }
    }
}