using JobApplicationSystem.Data;
using JobApplicationSystem.Interface;
using MediatR;

namespace JobApplicationSystem.CQRS.Commands
{
    public record DeleteJobCommand(int Id) : IRequest<bool>;

    public class DeleteJobHandler : IRequestHandler<DeleteJobCommand, bool>
    {
        private readonly IJobRepository _jobRepository;

        public DeleteJobHandler(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task<bool> Handle(DeleteJobCommand request, CancellationToken cancellationToken)
        {
            var job = await _jobRepository.GetJobById(request.Id);
            if (job == null) return false;

            await _jobRepository.DeleteJob(request.Id);
            return true;
        }
    }

}
