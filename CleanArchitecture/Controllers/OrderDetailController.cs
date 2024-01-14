using CleanArchitecture.Api.Controllers.ResponseTypes;
using CleanArchitecture.Application.OrderDetails;
using CleanArchitecture.Application.OrderDetails.Commands.Create;
using CleanArchitecture.Application.OrderDetails.Commands.Delete;
using CleanArchitecture.Application.OrderDetails.Commands.Update;
using CleanArchitecture.Application.OrderDetails.Querys.FindById;
using CleanArchitecture.Application.OrderDetails.Querys.FindByOrderId;
using CleanArchitecture.Application.Orders.CreateOrder;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace CleanArchitecture.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly ISender _mediator;
        public OrderDetailController(ISender mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("create")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<bool>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<bool>>> Create(
           [FromBody] CreateOrderDetailCommand command,
           CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<bool>(result));
        }
        [HttpPost("update")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<bool>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<bool>>> Update(
          [FromBody] UpdateOrderDetailCommand command,
          CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<bool>(result));
        }
        [HttpPost("delete/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<bool>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<bool>>> Delete(
          Guid id,
          CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new DeleteOrderDetailCommand(id: id), cancellationToken);
            return Ok(new JsonResponse<bool>(result));
        }
        [HttpGet("getbyid/{Id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<OrderDetailDTO>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<OrderDetailDTO>>> GetById(
          [FromRoute] Guid Id,
          CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetOrderDetailQuery(id: Id), cancellationToken);
            return Ok(new JsonResponse<OrderDetailDTO>(result));
        }
        [HttpGet("getallorderdetail")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<OrderDetailDTO>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<OrderDetailDTO>>>> GetAll(
          CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetOrdersDetailQuery(), cancellationToken);
            return Ok(new JsonResponse<List<OrderDetailDTO>>(result));
        }
    }
}
