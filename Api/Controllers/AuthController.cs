using ApiForGrido.DataBase;
using Grido.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        DataBasePoint _db;
        public AuthController()
            => _db = DataBasePoint.Instance;

        [HttpPost("Reg")]
        public bool Reg(User user) => _db.AddUser(user);

        [HttpPut("Upd")]
        public bool Upd(User user) => _db.EditUser(user);

        [HttpDelete("Rem")]
        public bool Rem(User user) => _db.DeleteUser(user);

        [HttpGet("Auth")]
        public User Auth(User user) => _db.AuthUser(user);
    }
}
