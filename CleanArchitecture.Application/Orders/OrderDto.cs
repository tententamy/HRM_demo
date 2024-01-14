using AutoMapper;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Orders
{
    public class OrderDto : IMapFrom<Order>
    {
        public OrderDto()
        {
        }

        public Guid Id { get; set; }
        public decimal Total { get; set; }

        public List<ResponseItem> Items { get; set; }

        public static OrderDto Create(Guid id, decimal total, List<ResponseItem> Items)
        {
            return new OrderDto
            {
                Id = id,
                Total = total,
                Items = Items
            };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrderDto>();
        }
    }

    public class ResponseItem
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public int Volume {  get; set; }
        public decimal TotalPrice { get; set; }
    }
}
