using Microsoft.AspNetCore.Mvc;
using tryitter.Context;
using tryitter.Models;

namespace tryitter.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly TryitterContext _context;

        public PostsController(TryitterContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Post>> Get()
        {
            var posts = _context.Posts.ToList();
            if(posts is null)
            {
                return NotFound("Posts não encontrados");
            }

            return posts;
        }
    }
}