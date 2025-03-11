using JobApplicationSystem.Models;

namespace JobApplicationSystem.Interface
{
    public interface IJobRepository
    {
        Task<IEnumerable<Job>> GetAllJobs();
        Task<Job> GetJobById(int id);
        Task AddJob(Job job);
        Task UpdateJob(Job job);
        Task DeleteJob(int id);
    }
}
