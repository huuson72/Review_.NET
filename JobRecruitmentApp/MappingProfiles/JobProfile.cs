using AutoMapper;
using JobRecruitmentApp.Models;
using JobRecruitmentApp.DTOs;

namespace JobRecruitmentApp.MappingProfiles
{
    public class JobProfile : Profile
    {
        public JobProfile()
        {
            // Ánh xạ từ Job -> JobDTO
            CreateMap<Job, JobDTO>();

            // Nếu cần ánh xạ ngược (DTO -> Entity)
            CreateMap<JobDTO, Job>();
        }
    }
}
