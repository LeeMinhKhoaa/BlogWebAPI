using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace BlogProject.Models
{
    [Table("Blogs")]
    public class Blog
    {
        public int BlogId {  get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        
        public DateTime? CreatedAt { get; set; } 
        public DateTime? LastUpdate { get; set; } 

        public ICollection<Comment> Comments { get; set; }
    }
}
