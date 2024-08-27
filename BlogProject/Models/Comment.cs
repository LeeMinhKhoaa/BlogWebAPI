using System.ComponentModel.DataAnnotations.Schema;

namespace BlogProject.Models
{
    [Table("Comments")]
    public class Comment
    {
        public int CommentID {  get; set; }
        public string Content {  get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public int BlogID { get; set; }
        public virtual Blog? Blog { get; set; }

    }
}
