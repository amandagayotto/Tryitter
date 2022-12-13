using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tryitter.Context;
using tryitter.Models;

namespace tryitter.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TryitterPostsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TryitterPostsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TryitterPost>> Get()
        {
            var postsList = _context.TryitterPosts.ToList();

            if(postsList is null)
            {
                return NotFound("Posts não encontrados");
            }

            return postsList;
        }

        [HttpGet("{id:int}", Name="GetPost")]
        public ActionResult<TryitterPost> Get(int id)
        {
            var postById = _context.TryitterPosts.FirstOrDefault(p => p.TryitterPostId == id);

            if(postById is null)
            {
                return NotFound("Post não encontrado");
            }

            return postById;
        }
        
        [HttpPost]
        public ActionResult Post(TryitterPost tryitterPost)
        {
            if(tryitterPost is null)
                return BadRequest();

            _context.TryitterPosts.Add(tryitterPost);
            _context.SaveChanges();

            return new CreatedAtRouteResult("GetPost",
                new { id = tryitterPost.TryitterPostId }, tryitterPost);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, TryitterPost tryitterPost)
        {
            if(id != tryitterPost.TryitterPostId)
            {
                return BadRequest();
            }

            _context.Entry(tryitterPost).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(tryitterPost);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var postById = _context.TryitterPosts.FirstOrDefault(p => p.TryitterPostId == id);

            if(postById is null)
            {
                return NotFound("Post não encontrado");
            }

            _context.TryitterPosts.Remove(postById);
            _context.SaveChanges();

            return Ok();
        }
    }
}