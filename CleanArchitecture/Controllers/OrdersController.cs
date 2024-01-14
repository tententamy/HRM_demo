using CleanArchitecture.Api.Controllers.ResponseTypes;
using CleanArchitecture.Application.Orders;
using CleanArchitecture.Application.Orders.CreateOrder;
using CleanArchitecture.Application.Orders.DeleteOrder;
using CleanArchitecture.Application.Orders.GetAllOrders;
using CleanArchitecture.Application.Orders.GetOrderById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace CleanArchitecture.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class OrdersController : ControllerBase
    {
        private readonly ISender _mediator;

        public OrdersController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// </summary>
        /// <response code="201">Successfully created.</response>
        /// <response code="400">One or more validation errors have occurred.</response>
        /// <response code="401">Unauthorized request.</response>
        /// <response code="403">Forbidden request.</response>
        /// 


        [HttpPost("create")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<OrderDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<OrderDto>>> CreateOrder(
            [FromBody] CreateOrderCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        
        [HttpDelete("delete/{id}")]
        [Authorize(Policy = "StaffPolicy")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteOrder([FromRoute] Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new DeleteOrderCommand(id), cancellationToken);
            return Ok(result);
        }

        
        //[HttpPut("api/order/{id}")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status403Forbidden)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        //public async Task<ActionResult> UpdateOrder(
        //    [FromRoute] Guid id,
        //    [FromBody] UpdateOrderCommand command,
        //    CancellationToken cancellationToken = default)
        //{
        //    if (command.Id == default)
        //    {
        //        command.Id = id;
        //    }

        //    if (id != command.Id)
        //    {
        //        return BadRequest();
        //    }

        //    await _mediator.Send(command, cancellationToken);
        //    return NoContent();
        //}

        
        [HttpGet("getOrderById/{id}")]
        [Authorize(Policy = "StaffPolicy")]
        [ProducesResponseType(typeof(OrderDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<OrderDto>> GetOrderById(
            [FromRoute] Guid id,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetOrderByIdQuery(id), cancellationToken);
            return result == null ? NotFound() : Ok(result);
        }

        
        [HttpGet("getAllOrders")]
        [Authorize(Policy = "StaffPolicy")]
        [ProducesResponseType(typeof(List<OrderDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<OrderDto>>> GetOrders(CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllOrdersQuery(), cancellationToken);
            return Ok(result);
        }
    }
}
