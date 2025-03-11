using JobRecruitmentApp.Appcodes;
using JobRecruitmentApp.Interface;
using JobRecruitmentApp.Models;
using Microsoft.EntityFrameworkCore;

namespace JobRecruitmentApp.Repository
{
    public class JobRepository : IJobRepository
    {
        private readonly JobContext _context;

        public JobRepository(JobContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Job>> GetAllJobs()
        {
            return await _context.Jobs.ToListAsync();
        }

        public async Task<Job> GetJobById(int id)
        {
            return await _context.Jobs.FindAsync(id);
        }

        public async Task AddJob(Job job)
        {
            _context.Jobs.Add(job);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateJob(Job job)
        {
            _context.Entry(job).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteJob(int id)
        {
            var job = await _context.Jobs.FindAsync(id);
            if (job != null)
            {
                _context.Jobs.Remove(job);
                await _context.SaveChangesAsync();
            }
        }
    }
}
