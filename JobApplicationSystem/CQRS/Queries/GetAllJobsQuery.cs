using JobApplicationSystem.Data;
using JobApplicationSystem.Interface;
using JobApplicationSystem.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JobApplicationSystem.CQRS.Queries
{
    public record GetAllJobsQuery() : IRequest<List<Job>>;

    public class GetAllJobsHandler : IRequestHandler<GetAllJobsQuery, List<Job>>
    {
        private readonly IJobRepository _jobRepository;

        public GetAllJobsHandler(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task<List<Job>> Handle(GetAllJobsQuery request, CancellationToken cancellationToken)
        {
            return (await _jobRepository.GetAllJobs()).ToList();
        }
    }

}
