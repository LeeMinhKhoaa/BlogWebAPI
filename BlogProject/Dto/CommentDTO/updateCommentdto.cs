using System.ComponentModel.DataAnnotations;

namespace BlogProject.Dto.CommentDTO
{
    public class updateCommentdto
    {
        [Required]
        public string Content;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;

    }
}
