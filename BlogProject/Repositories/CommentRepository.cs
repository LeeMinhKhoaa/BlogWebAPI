using BlogProject.Data;
using BlogProject.Dto.Blog;
using BlogProject.Dto.CommentDTO;
using BlogProject.Interfaces;
using BlogProject.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogProject.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly BlogDbcontext _context;
        

        public CommentRepository(BlogDbcontext context) { 
            _context = context;
            
        }
        public async Task<Comment> create(int BlogID,CreateCommentDto commentDto)
        {
            try {
                Comment newComment = new Comment();
                newComment.UpdatedDate = DateTime.Now;
                newComment.Content = commentDto.Content;
                newComment.CreatedDate = DateTime.Now;
                newComment.BlogID = BlogID;
                await _context.Comments.AddAsync(newComment);
                await _context.SaveChangesAsync();
                return newComment;
            }
            catch { 
                return null;
            }
        }
        public async Task<Comment> GetComment(int CommentID) {
            Comment? comment = await _context.Comments.FirstOrDefaultAsync(cm => cm.CommentID == CommentID);
            return comment;
        }
        public async Task<Comment> update(int CommentID, UpdateBlogDto commentDto) { 
            Comment? comment = await GetComment(CommentID);
            if (comment != null) {
                comment.UpdatedDate = DateTime.Now;
                comment.Content = commentDto.Content;
                _context.Comments.Update(comment);
                _context.SaveChanges();
            }
            return comment;
        }
    }
}
