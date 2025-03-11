using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using JobRecruitmentApp.Models;
using JobRecruitmentApp.DTOs;
using JobRecruitmentApp.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobRecruitmentApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobRepository _jobRepository;
        private readonly IMapper _mapper;

        public JobController(IJobRepository jobRepository, IMapper mapper)
        {
            _jobRepository = jobRepository;
            _mapper = mapper;
        }

        // API GET: /api/job
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobDTO>>> GetJobs()
        {
            var jobs = await _jobRepository.GetAllJobs();
            return Ok(_mapper.Map<List<JobDTO>>(jobs));
        }

        // API GET: /api/job/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<JobDTO>> GetJob(int id)
        {
            var job = await _jobRepository.GetJobById(id);
            if (job == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<JobDTO>(job));
        }

        // API POST: /api/job
        [HttpPost]
        public async Task<ActionResult> AddJob([FromBody] JobDTO jobDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Trả về lỗi nếu dữ liệu không hợp lệ
            }

            var job = _mapper.Map<Job>(jobDTO);
            await _jobRepository.AddJob(job);
            return CreatedAtAction(nameof(GetJob), new { id = job.Id }, _mapper.Map<JobDTO>(job));
        }


        // API PUT: /api/job/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateJob(int id, JobDTO jobDTO)
        {
            var existingJob = await _jobRepository.GetJobById(id);
            if (existingJob == null)
            {
                return NotFound();
            }

            _mapper.Map(jobDTO, existingJob); // Cập nhật dữ liệu từ DTO vào object gốc
            await _jobRepository.UpdateJob(existingJob);
            return NoContent();
        }

        // API DELETE: /api/job/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteJob(int id)
        {
            var existingJob = await _jobRepository.GetJobById(id);
            if (existingJob == null)
            {
                return NotFound();
            }

            await _jobRepository.DeleteJob(id);
            return NoContent();
        }
    }
}
