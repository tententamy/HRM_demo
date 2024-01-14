using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;


namespace CleanArchitecture.Application.OrderDetails.Commands.Create
{
    public class CreateOrderDetailCommand: IRequest<bool>, ICommand
    {
        public CreateOrderDetailCommand(Guid orderid, Guid productid, int quantity, double unitprice, decimal price) 
        { 
            this.OrderId = orderid;
            this.ProductId = productid;
            this.Quantity = quantity;
            this.Price = price;
            this.UnitPrice = unitprice;
        }

        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int      Quantity { get; set; }
        public double   UnitPrice { get; set; }
        public decimal  Price { get; set; }

    }
}
