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
            var usersList = _context.Users.Include(p => p.TryitterPosts).Where(u => u.UserId <= 10).ToList();

            if(usersList is null)
            {
                return NotFound("Usuários não encontrados");
            }

            return usersList;
        }

        [HttpGet("{id:int}", Name="GetUser")]
        public ActionResult<User> Get(int id)
        {
            var userById = _context.Users.FirstOrDefault(u => u.UserId == id);

            if(userById is null)
            {
                return NotFound("Usuário não encontrado");
            }

            return userById;
        }
        
        [HttpPost]
        public ActionResult Post(User user)
        {
            if(user is null)
                return BadRequest();

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
                return BadRequest();
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
                return NotFound("Usuário não encontrado");
            }

            _context.Users.Remove(userById);
            _context.SaveChanges();

            return Ok();
        }
    }
}