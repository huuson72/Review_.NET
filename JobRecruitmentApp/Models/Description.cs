namespace JobRecruitmentApp.Models
{
    public class Description
    {
        public int Id { get; set; }  // Đổi chữ "id" thành "Id" theo convention
        public string Title { get; set; }
        public string Content { get; set; } // Đổi "description" thành "Content" để tránh trùng với tên class
    }

}
