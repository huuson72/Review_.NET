using JobApplicationSystem.Data;
using JobApplicationSystem.Interface;
using JobApplicationSystem.Models;
using MediatR;

namespace JobApplicationSystem.CQRS.Commands
{
    public record UpdateJobCommand(int Id, string Title, string Description, string Company, string Location) : IRequest<Job?>;

    public class UpdateJobHandler : IRequestHandler<UpdateJobCommand, Job?>
    {
        private readonly IJobRepository _jobRepository;

        public UpdateJobHandler(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task<Job?> Handle(UpdateJobCommand request, CancellationToken cancellationToken)
        {
            var job = await _jobRepository.GetJobById(request.Id);
            if (job == null) return null;

            job.Title = request.Title;
            job.Description = request.Description;
            job.Company = request.Company;
            job.Location = request.Location;

            await _jobRepository.UpdateJob(job);
            return job;
        }
    }

}
