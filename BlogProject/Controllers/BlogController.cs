using BlogProject.Dto.Blog;
using BlogProject.Dto.CommentDTO;
using BlogProject.Interfaces;
using BlogProject.Models;
using BlogProject.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogRepository _blogRepository;

        public BlogController(IBlogRepository blogRepository) {
            _blogRepository = blogRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var lst_book = await _blogRepository.GetBlogsAsync();
            var blogViewModels = lst_book.Select(blog => new BlogGetALLVM
            {
                BlogId = blog.BlogId,
                Title = blog.Title,
                Content = blog.Content,
                CreatedAt = blog.CreatedAt,
                LastUpdate = blog.LastUpdate
            }).ToList();

            return Ok(blogViewModels);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var blog = await _blogRepository.GetBlogAsync(id);
            if (blog == null)
            {
                return NotFound();
            }
            BlogWithCommentDto blogDTO = new BlogWithCommentDto()
            {
                BlogId = id,
                Title = blog.Title,
                Content = blog.Content,
                CreatedAt = blog.CreatedAt,
                LastUpdate = blog.LastUpdate,
                Comments = blog.Comments.Select(c => new CommentVM
                {
                    CommentID = c.CommentID,
                    Content = c.Content ?? string.Empty, // Handling null by providing an empty string
                    CreatedDate = c.CreatedDate,
                    UpdatedDate = c.UpdatedDate
                }).ToList()
            };
            return Ok(blogDTO);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateBlogDto Updatedto) {
            Blog blog = await _blogRepository.UpdateBlogAsync(id, Updatedto);
            return blog == null ? NotFound():Ok(blog);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBlog blog) {
            if (!ModelState.IsValid)
            {
                BadRequest(blog);
            }
            else
            {
                Blog newblog = await _blogRepository.CreateBlogAsync(blog);
                return Ok(newblog);
            }
            return NoContent();
        }
    }
}
