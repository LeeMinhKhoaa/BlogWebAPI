using BlogProject.Dto.Blog;
using BlogProject.Dto.CommentDTO;
using BlogProject.Models;

namespace BlogProject.Interfaces
{
    public interface ICommentRepository
    {
        public Task<Comment> create(int BlogID, CreateCommentDto commentDto);
        public Task<Comment> GetComment(int CommentID);
        public Task<Comment> update(int CommentID, UpdateBlogDto commentDto);

        public IEnumerable<Comment> GetAllByBlog(int BlogId);
        public Task<bool> Delete(int CommentID);
    }
}
