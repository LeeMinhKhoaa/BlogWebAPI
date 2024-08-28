using BlogProject.Dto.Blog;
using BlogProject.Dto.CommentDTO;
using BlogProject.Interfaces;
using BlogProject.Models;
using BlogProject.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace BlogProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IBlogRepository _blogRepository;
        private readonly ICommentRepository _commentRepository;

        public CommentController(IBlogRepository blogRepository,ICommentRepository commentRepository) {
            _blogRepository = blogRepository;
            _commentRepository = commentRepository;
        }
        [HttpPost]
        public async Task<IActionResult> Create(int BlogID, CreateCommentDto commentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return the model state errors
            }

            Blog blog = await _blogRepository.GetBlogAsync(BlogID);
            if (blog == null)
            {
                return NotFound(); // Return 404 if the blog is not found
            }

            Comment cmm = await _commentRepository.create(blog.BlogId, commentDto); // Assuming `create` is an async method
            return Ok(cmm); // Return 200 with the created comment
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,UpdateBlogDto commentDto) { 
            if (!ModelState.IsValid)
            {
                BadRequest(commentDto);
            }    
            Comment comment = await _commentRepository.GetComment(id);
            if (comment == null) {
                NotFound();
            }
            Comment cmm = await _commentRepository.update(id, commentDto); // Assuming `create` is an async method
            return Ok(cmm); // Return 200 with the created comment
        }
        [HttpGet("{BlogID}")]
        public async Task<IActionResult> GetAllCommentByBlog(int BlogID) {
            Blog blog = await _blogRepository.GetBlogAsync(BlogID);
            if (blog == null) { 
                return NotFound();
            }
            IEnumerable<Comment> comments = _commentRepository.GetAllByBlog(BlogID);
            var commentsViewModels = comments.Select(comment => new CommentVM
            {
                CommentID = comment.CommentID,
                Content = comment.Content,
                CreatedDate = comment.CreatedDate,
                UpdatedDate = comment.UpdatedDate
            }).ToList();
            return Ok(commentsViewModels);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            Comment comment = await _commentRepository.GetComment(id);
            if (comment == null)
                return NotFound();
            bool result = await _commentRepository.Delete(id);
            if (result)
                return Ok("Comment with id : " + id + " was deleted");
            else
                return BadRequest();
        }
    }
}
