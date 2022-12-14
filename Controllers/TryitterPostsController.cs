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
        private readonly TryitterContext _context;

        public TryitterPostsController(TryitterContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TryitterPost>> Get()
        {
            try
            {
                var postsList = _context.TryitterPosts.AsNoTracking().Take(20).ToList();

                if(postsList is null)
                {
                    return NotFound("Posts não encontrados");
                }

                return postsList;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema na sua solicitação");
            }
        }

        [HttpGet("{id:int}", Name="GetPost")]
        public ActionResult<TryitterPost> Get(int id)
        {
            try
            {
                   var postById = _context.TryitterPosts.FirstOrDefault(p => p.TryitterPostId == id);

                if(postById is null)
                {
                    return NotFound("Post não encontrado");
                }

                return postById;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema na sua solicitação");
            }
        }
        
        [HttpPost]
        public ActionResult Post(TryitterPost tryitterPost)
        {
            if(tryitterPost is null)
                return BadRequest("Dados inválidos");

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
                return BadRequest("Dados inválidos");
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