using System.ComponentModel.DataAnnotations;

namespace JobRecruitmentApp.DTOs
{
    public class JobDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên công việc không được để trống.")]
        [StringLength(100, ErrorMessage = "Tên công việc không được vượt quá 100 ký tự.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Lương không được để trống.")]
        [Range(1, 100000, ErrorMessage = "Lương phải nằm trong khoảng 1 - 100,000.")]
        public decimal Salary { get; set; }
    }
}
