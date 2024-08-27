using System.ComponentModel.DataAnnotations;

namespace BlogProject.Dto.Blog
{
    public class CreateBlog
    {
        [Required]
        public string? Title { get; set; }
        public string? Content { get; set; }


    }
}
