using BlogProject.Data;
using BlogProject.Dto.Blog;
using BlogProject.Interfaces;
using BlogProject.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogProject.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogDbcontext _context;

        public BlogRepository(BlogDbcontext context) {
            _context = context;
        }
        public async Task<Blog> CreateBlogAsync(CreateBlog blog)
        {
           
            Blog newBlog = new Blog(); 
            newBlog.Title = blog.Title;
            newBlog.Content = blog.Content;
            newBlog.CreatedAt = DateTime.Now;
            newBlog.LastUpdate = DateTime.Now;
            await _context.Blogs.AddAsync(newBlog);
            await _context.SaveChangesAsync();   
            return newBlog;
        }

        public async Task<bool> DeleteBlogAsync(int blogId)
        {
            Blog? blog = await _context.Blogs.FirstOrDefaultAsync(b => b.BlogId == blogId);
            if (blog == null)
            {
                return false; // Return false if the blog doesn't exist
            }

            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();
            return true; // Return true to indicate the blog was deleted
        }


        public async Task<Blog> GetBlogAsync(int blogId)
        {
            Blog? blog = await _context.Blogs.Include(b => b.Comments).FirstOrDefaultAsync(b => b.BlogId == blogId);
            return blog;
        }

        public async Task<IEnumerable<Blog>> GetBlogsAsync()
        {
            var lst_Blog = await _context.Blogs.ToListAsync();
            return lst_Blog;
        }

        public async Task<Blog> UpdateBlogAsync(int id,UpdateBlogDto updateBlog)
        {
            Blog? blog = await _context.Blogs.FirstOrDefaultAsync(b => b.BlogId == id);
            if (blog != null) { 
                blog.LastUpdate = DateTime.UtcNow;
                blog.Title = updateBlog.Title;
                blog.Content = updateBlog.Content;
            }

            _context.Blogs.Update(blog);

            // Save the changes to the database
            await _context.SaveChangesAsync();
            return blog;
        }

    }
}
