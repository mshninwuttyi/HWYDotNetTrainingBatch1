using HWYDotNetTrainingBatch1.Assigned.DreamDictionary.Databases.Models;
using HWYDotNetTrainingBatch1.Assigned.DreamDictionary.Domain.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HWYDotNetTrainingBatch1.Assigned.DreamDictionary.WebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly BlogService _blogService;

        public BlogController(BlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet]
        public IActionResult GetBlog()
        {
            var model = _blogService.GetBlogs();
            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlogDetailById(int id)
        {
            var model = _blogService.GetBlogDetailById(id);
            return Ok(model);   
        }
    }
}
