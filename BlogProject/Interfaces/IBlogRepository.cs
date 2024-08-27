using BlogProject.Dto.Blog;
using BlogProject.Models;

namespace BlogProject.Interfaces
{
    public interface IBlogRepository
    {
        public Task<IEnumerable<Blog>> GetBlogsAsync();
        public Task<Blog> GetBlogAsync(int blogId);
        public Task<Blog> CreateBlogAsync(CreateBlog blog);
        public Task<bool> DeleteBlogAsync(int blogId);
        public Task<Blog> UpdateBlogAsync(int id, UpdateBlogDto blog);

    }
}
