using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Products.CreateProduct
{
    public class CreateProductCommand : IRequest<ProductDto>, ICommand
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Brand { get; set; }
        public Guid VendorId { get; set; }


        public CreateProductCommand(string name, string description, decimal price, string brand, Guid vendorId)
        {
            Name = name;
            Description = description;
            Price = price;
            Brand = brand;
            VendorId = vendorId;
        }
    }
}