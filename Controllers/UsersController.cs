using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tryitter.Context;
using tryitter.Models;

namespace tryitter.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly TryitterContext _context;

        public UsersController(TryitterContext context)
        {
            _context = context;
        }

        [HttpGet("tryitterposts")]
        public ActionResult<IEnumerable<User>> GetUsersPosts()
        {
            try
            {
                var usersList = _context.Users.Include(p => p.TryitterPosts).Where(u => u.UserId <= 10).ToList();

                if(usersList is null)
                {
                    return NotFound("Estudantes não encontrados");
                }

                return usersList;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema na sua solicitação");
            }
        }

        [HttpGet("{id:int}", Name="GetUser")]
        public ActionResult<User> Get(int id)
        {
            try
            {
                var userById = _context.Users.FirstOrDefault(u => u.UserId == id);

                if(userById is null)
                {
                    return NotFound("Estudante não encontrado");
                }

                return userById;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema na sua solicitação");
            }
        }
        
        [HttpPost]
        public ActionResult Post(User user)
        {
            if(user is null)
                return BadRequest("Dados inválidos");

            _context.Users.Add(user);
            _context.SaveChanges();

            return new CreatedAtRouteResult("GetUser",
                new { id = user.UserId }, user);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, User user)
        {
            if(id != user.UserId)
            {
                return BadRequest("Dados inválidos");
            }

            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(user);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<User> Delete(int id)
        {
            var userById = _context.Users.FirstOrDefault(u => u.UserId == id);

            if(userById is null)
            {
                return NotFound("Estudante não encontrado");
            }

            _context.Users.Remove(userById);
            _context.SaveChanges();

            return Ok();
        }
    }
}