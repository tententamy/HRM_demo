using AutoMapper;
using CleanArchitecture.Application.Orders;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Products
{
    public static class ProductDtoMappingExtensions
    {

        public static ProductDto MapToProductDto(this Product projectFrom, IMapper mapper)
           => mapper.Map<ProductDto>(projectFrom);

        public static List<ProductDto> MapToProductDtoList(this IEnumerable<Product> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToProductDto(mapper)).ToList();
    }
}