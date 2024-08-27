namespace BlogProject.Dto.CommentDTO
{
    public class CommentVM
    {
        public int CommentID { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
