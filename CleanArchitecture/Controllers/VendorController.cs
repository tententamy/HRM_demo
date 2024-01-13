using CleanArchitecture.Api.Controllers.ResponseTypes;
using CleanArchitecture.Application.Vendors.CreateVendor;
using CleanArchitecture.Application.Vendors.DeleteVendor;
using CleanArchitecture.Application.Vendors.GetVendorById;
using CleanArchitecture.Application.Vendors.UpdateVendor;
using CleanArchitecture.Application.Vendors;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CleanArchitecture.Application.Vendors.GetAllVendors;

namespace CleanArchitecture.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private readonly ISender _mediator;

        public VendorController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("getVendorById/{id}")]
        [ProducesResponseType(typeof(JsonResponse<VendorDTO>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<VendorDTO>> GetVendorByID(
           [FromRoute] Guid id,
          CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetVendorCommand(id), cancellationToken);
            return Ok(result);
        }

        [HttpGet("getAllVendors")]
        [ProducesResponseType(typeof(JsonResponse<List<VendorDTO>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<VendorDTO>>> GetAllVendors(
          CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllVendorsCommand(), cancellationToken);
            return Ok(result);
        }

        [HttpPost("create-vendor")]
        [ProducesResponseType(typeof(JsonResponse<VendorDTO>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<VendorDTO>>> CreateVendor(
           [FromBody] CreateVendorCommand command,
         CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        [ProducesResponseType(typeof(JsonResponse<VendorDTO>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<VendorDTO>> DeleteVendor(
            [FromRoute] Guid Id,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new DeleteVendorCommand(Id), cancellationToken);
            return result;
        }

        [HttpPut("update-vendor")]
        [ProducesResponseType(typeof(JsonResponse<VendorDTO>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<VendorDTO>> UpdateVendor(
            [FromBody] UpdateVendorCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }
    }
}
