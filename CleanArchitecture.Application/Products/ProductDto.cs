using AutoMapper;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Application.Orders;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Products
{
    public class ProductDto : IMapFrom<Product>
    {
        public ProductDto()
        {
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductDto>();
        }
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public Guid VendorId { get; set; }
    }
}