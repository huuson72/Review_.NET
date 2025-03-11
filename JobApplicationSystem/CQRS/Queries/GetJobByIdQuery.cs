using JobApplicationSystem.Data;
using JobApplicationSystem.Interface;
using JobApplicationSystem.Models;
using MediatR;

namespace JobApplicationSystem.CQRS.Queries
{
    public record GetJobByIdQuery(int Id) : IRequest<Job?>;

    public class GetJobByIdHandler : IRequestHandler<GetJobByIdQuery, Job?>
    {
        private readonly IJobRepository _jobRepository;

        public GetJobByIdHandler(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task<Job?> Handle(GetJobByIdQuery request, CancellationToken cancellationToken)
        {
            return await _jobRepository.GetJobById(request.Id);
        }
    }
}
