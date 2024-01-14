using MediatR;
using CleanArchitecture.Application.Products;

namespace CleanArchitecture.Application.Products.GetProductById
{
    public class GetProductByIdQuery : IRequest<ProductDto>
    {
        public Guid ProductId { get; set; }

        public GetProductByIdQuery(Guid productId)
        {
            ProductId = productId;
        }
    }
}