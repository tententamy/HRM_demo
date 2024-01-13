using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Orders.CreateOrder
{
    public class CreateOrderCommand : IRequest<OrderDto>, ICommand
    {
        public CreateOrderCommand(decimal TotalPrice, Guid UserId, List<Item> Items)
        {
            this.TotalPrice = TotalPrice;
            this.UserId = UserId;
            this.Items = Items;
        }

        public decimal TotalPrice { get; set; }
        public Guid UserId { get; set; }
        public List<Item> Items { get; set; }
    }

    public class Item
    {
        public Guid ProductId { get; set; }
        public int Volume { get; set; }
    }
}
