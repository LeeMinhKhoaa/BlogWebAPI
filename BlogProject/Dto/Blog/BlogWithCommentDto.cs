using BlogProject.Dto.CommentDTO;
using BlogProject.Models;

namespace BlogProject.Dto.Blog
{
    public class BlogWithCommentDto
    {
        public int BlogId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? LastUpdate { get; set; }

        public ICollection<CommentVM> Comments { get; set; }
    }
}
