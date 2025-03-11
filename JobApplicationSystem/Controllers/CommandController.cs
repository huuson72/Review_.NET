using JobApplicationSystem.CQRS.Commands;
using JobApplicationSystem.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobApplicationSystem.Controllers
{
    [ApiController]
    [Route("api/jobs")]
    public class JobCommandController : ControllerBase
    {
        private readonly IMediator _mediator;

        public JobCommandController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Job>> CreateJob(CreateJobCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Job?>> UpdateJob(int id, UpdateJobCommand command)
        {
            if (id != command.Id) return BadRequest();
            return await _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteJob(int id)
        {
            return await _mediator.Send(new DeleteJobCommand(id));
        }
    }

}
