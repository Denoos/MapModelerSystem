using ApiForGrido.DataBase;
using Grido.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
       
        DataBasePoint _db;

        AdminController()
            => _db = DataBasePoint.Instance;

        [HttpPost("Add")]
        public bool Add(User user) => _db.AddUser(user);

        [HttpPut("Edit")]
        public bool Edit(User user) => _db.EditUser(user);

        [HttpDelete("Del")]
        public bool Del(User user) => _db.DeleteUser(user);

        [HttpGet("GetOne")]
        public User GetOne(int id) => _db.GetOneUser(id);

        [HttpGet("GetMany")]
        public List<User> GetMany(User user) => _db.GetManyUsers();
        
    }
}
