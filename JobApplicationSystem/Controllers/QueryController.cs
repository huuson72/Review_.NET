using JobApplicationSystem.CQRS.Queries;
using JobApplicationSystem.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobApplicationSystem.Controllers
{
    [ApiController]
    [Route("api/jobs")]
    public class JobQueryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public JobQueryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Job>>> GetAllJobs()
        {
            return await _mediator.Send(new GetAllJobsQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Job?>> GetJobById(int id)
        {
            return await _mediator.Send(new GetJobByIdQuery(id));
        }
    }

}
