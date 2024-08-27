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
        public async Task<IActionResult> Update(int CommentID, UpdateBlogDto commentDto) { 
            if (!ModelState.IsValid)
            {
                BadRequest(commentDto);
            }    
            Comment comment = await _commentRepository.GetComment(CommentID);
            if (comment == null) {
                NotFound();
            }
            Comment cmm = await _commentRepository.update(CommentID, commentDto); // Assuming `create` is an async method
            return Ok(cmm); // Return 200 with the created comment
        }
    }
}
