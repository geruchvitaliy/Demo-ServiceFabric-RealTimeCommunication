using Api.Models;
using Common.Commands.Device;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class DeviceController : Controller
    {
        private readonly IMediator _mediator;

        public DeviceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("count")]
        public async Task<IActionResult> GetCount()
        {
            var command = new GetDevicesCount();
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet("statuses")]
        public async Task<IActionResult> GetStatuses(int pageNumber, int pageSize)
        {
            var command = new GetDevicesStatuses(pageNumber, pageSize);
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet("ids")]
        public async Task<IActionResult> GetIds(int pageNumber, int pageSize)
        {
            var command = new GetDevicesIds(pageNumber, pageSize);
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet("{id}/profile")]
        public async Task<IActionResult> GetProfile(Guid id)
        {
            var command = new GetProfile(id);
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet("{id}/locations/last")]
        public async Task<IActionResult> GetLastLocation(Guid id)
        {
            var command = new GetLastLocation(id);
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet("{id}/locations")]
        public async Task<IActionResult> GetLocations(Guid id)
        {
            var command = new GetLocations(id);
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPut("sync")]
        public async Task<IActionResult> SyncStatuses()
        {
            var command = new SyncDevicesStatuses();
            await _mediator.Send(command);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> PostDevice([FromBody]PostDevice data)
        {
            var command = new CreateDevice(data.Name);
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPost("{id}/profile")]
        public async Task<IActionResult> PostProfile(Guid id, [FromBody]PostProfile data)
        {
            var command = new UpdateProfile(id, data.Name);
            await _mediator.Send(command);

            return Ok();
        }

        [HttpPost("{id}/location")]
        public async Task<IActionResult> PostLocation(Guid id, [FromBody]PostLocation data)
        {
            var command = new UpdateLocation(id, data.Latitude, data.Longitude, DateTime.UtcNow);
            await _mediator.Send(command);

            return Ok();
        }
    }
}