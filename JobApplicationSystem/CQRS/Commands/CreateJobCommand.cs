using JobApplicationSystem.Data;
using JobApplicationSystem.Interface;
using JobApplicationSystem.Models;
using MediatR;

namespace JobApplicationSystem.CQRS.Commands
{
    public record CreateJobCommand(string Title, string Description, string Company, string Location) : IRequest<Job>;

    public class CreateJobHandler : IRequestHandler<CreateJobCommand, Job>
    {
        private readonly IJobRepository _jobRepository;

        public CreateJobHandler(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task<Job> Handle(CreateJobCommand request, CancellationToken cancellationToken)
        {
            var job = new Job
            {
                Title = request.Title,
                Description = request.Description,
                Company = request.Company,
                Location = request.Location
            };

            await _jobRepository.AddJob(job);
            return job;
        }
    }
}
