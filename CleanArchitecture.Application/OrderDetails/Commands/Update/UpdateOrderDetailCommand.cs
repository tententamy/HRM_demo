using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.OrderDetails.Commands.Update
{
    public class UpdateOrderDetailCommand: IRequest<bool>, ICommand
    {
        public UpdateOrderDetailCommand(Guid id, int quantity, double unitPrice, decimal price)
        {
            Id = id;
            Quantity = quantity;
            UnitPrice = unitPrice;
            Price = price;
        }
        public Guid Id {  get; set; }   
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public decimal Price { get; set; }
    }
}
