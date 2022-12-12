using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            var users = _context.Users.ToList();
            if(users is null)
            {
                return NotFound("Usuários não encontrados");
            }

            return users;
        }

        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var user = _context.Users.FirstOrDefault(p => p.UserId == id);
            if(user is null)
            {
                return NotFound("Usuário não encontrado");
            }

            return user;
        }
    }
}