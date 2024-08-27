using BlogProject.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogProject.Data
{
    public class BlogDbcontext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Comment> Comments { get; set; }
        public BlogDbcontext(DbContextOptions<BlogDbcontext> options) : base(options) { 
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Blog>().Property(b => b.Content).HasColumnType("Text");

            modelBuilder.Entity<Comment>().Property(t => t.Content)
                                        .HasColumnName("CommentContent");
            modelBuilder.Entity<Comment>()
                        .Property(p => p.Content)
                        .HasColumnType("ntext");
            // Tạo khóa ngoại giữa Blog và Department
            modelBuilder.Entity<Comment>()
               .HasOne(c => c.Blog)        // Một Comment thuộc về một Blog
               .WithMany(b => b.Comments)  // Một Blog có nhiều Comment
               .HasForeignKey(c => c.BlogID);
             
        }

    }
}
