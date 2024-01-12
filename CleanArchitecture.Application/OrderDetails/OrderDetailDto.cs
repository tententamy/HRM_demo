using AutoMapper;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Application.Reviews;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.OrderDetails
{
    public class OrderDetailDTO : IMapFrom<OrderDetail>
    {
        public OrderDetailDTO() { }

        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public decimal Price { get; set; }
        public static OrderDetailDTO CreateOrderDetail(Guid id, int quantity, double unitPrice, decimal price)
        {
            return new OrderDetailDTO
            {
                Id = id,
                Quantity = quantity,
                UnitPrice = unitPrice,
                Price = price
            };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<OrderDetail, OrderDetailDTO>();
        }
    }
}
