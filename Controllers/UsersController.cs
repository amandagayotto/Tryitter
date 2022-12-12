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

        [HttpGet("posts")]
        public ActionResult<IEnumerable<User>> GetUsersPosts()
        {
            var users = _context.Users.Include(p => p.Posts).ToList();
            if(users is null)
            {
                return NotFound("Usuários não encontrados");
            }

            return users;
        }

        [HttpGet("{id}", Name="GetUser")]
        public ActionResult<User> Get(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == id);
            if(user is null)
            {
                return NotFound("Usuário não encontrado");
            }

            return user;
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
    }
}