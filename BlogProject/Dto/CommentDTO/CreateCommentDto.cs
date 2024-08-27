using BlogProject.Models;

namespace BlogProject.Dto.CommentDTO
{
    public class CreateCommentDto
    {
        public string Content { get; set; }
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
    }
}
