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
    public class OrderDto : IMapFrom<Order>
    {

        public OrderDto() { }

        public decimal TotalPrice { get; set; }
        public Guid UserId { get; set; }

        public static OrderDto CreateOrder(decimal totalPrice, Guid userId)
        {
            return new OrderDto() { TotalPrice = totalPrice, UserId = userId };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrderDto>();
        }
    }
}
