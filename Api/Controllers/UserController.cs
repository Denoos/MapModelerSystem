using ApiForGrido.DataBase;
using Grido.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        DataBasePoint _db;

        UserController()
            => _db = DataBasePoint.Instance;

        [HttpPost("Add")]
        public bool Add(Map map) => _db.AddMap(map);
        [HttpPut("Edit")]
        public bool Edit(Map map) => _db.EditMap(map);
        [HttpDelete("Del")]
        public bool Del(Map map) => _db.DeleteMap(map);

        [HttpGet("GetOne")]
        public User GetOne(int id) => _db.GetOneUser(id);

        [HttpGet("GetMany")]
        public List<Map> GetMany(Map map) => _db.GetManyMaps();
    }
}
