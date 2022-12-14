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

        //pega todos os posts
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

        //pega post pelo seu id
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

        //pega posts pelo id do estudante
        [HttpGet("User")]
        public ActionResult<IEnumerable<TryitterPost>> GetPostsByUserId(int id)
        {
            var postsByUserId = _context.TryitterPosts.Where(p => p.UserId == id).AsNoTracking().ToList();

            if(postsByUserId is null)
            {
                return NotFound("Post(s) não encontrado(s)");
            }

            return postsByUserId;
        }
        
        //cria um post
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

        //altera um post pelo seu id
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

        //deleta um post pelo seu id
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