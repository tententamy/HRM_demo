using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Products.GetProducts
{
    public class GetProductsQuery : IRequest<List<ProductDto>>

    {
        public GetProductsQuery() { }

    }
}
