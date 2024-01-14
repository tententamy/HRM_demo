using CleanArchitecture.Api.Controllers.ResponseTypes;
using CleanArchitecture.Application.Orders;
using CleanArchitecture.Application.Products;
using CleanArchitecture.Application.Products.CreateProduct;
using CleanArchitecture.Application.Products.DeleteProduct;
using CleanArchitecture.Application.Products.GetProductById;
using CleanArchitecture.Application.Products.GetProducts;
using CleanArchitecture.Application.Products.UpdateProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace CleanArchitecture.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ISender _mediator;

        public ProductController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        }


        [HttpPost("create")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<ProductDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<ProductDto>>> CreateProduct(
            [FromBody] CreateProductCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return (new JsonResponse<ProductDto>(result));
        }

        [HttpGet("getAllProducts")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<ProductDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<ProductDto>>>> GetProducts(
           CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetProductsQuery(), cancellationToken);
            return new JsonResponse<List<ProductDto>>(result);
        }
        [HttpGet("getProductById/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<Guid>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<ProductDto>>> GetProduct(
            [FromRoute] Guid id,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetProductByIdQuery(id), cancellationToken);
            return (new JsonResponse<ProductDto>(result));
        }

        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<JsonResponse<ProductDto>>> UpdateProduct(
            
            [FromBody] UpdateProductCommand command,
            CancellationToken cancellationToken = default)
        {
          

            var result = await _mediator.Send(command, cancellationToken);
            return (new JsonResponse<ProductDto>(result)); ;
        }

        [HttpDelete("product/{productId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteProduct(
            [FromRoute] Guid productId,
            CancellationToken cancellationToken = default)
        {
            await _mediator.Send(new DeleteProductCommand(productId), cancellationToken);
            return Ok("success");
        }

    }
}