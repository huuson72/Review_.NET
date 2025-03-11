using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobRecruitmentApp.Models
{
    public class Job
    {
        public int Id { get; set; }
        //[Column("Job_Title")]
        public string Title { get; set; }
        public string Company { get; set; }
        [Range(1000, 100000, ErrorMessage = "Mức lương phải từ 1,000 đến 100,000.")]
        public decimal Salary { get; set; }
    }
}
