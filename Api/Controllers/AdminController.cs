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

        [HttpPost]
        public bool Add(User user) => _db.AddUser(user);
        [HttpPut]
        public bool Edit(User user) => _db.EditUser(user);
        [HttpDelete]
        public bool Del(User user) => _db.DeleteUser(user);

        //
        //  Создается метод чисто по типу.
        //


        //[HttpGet]
        //public User GetOne(int id) => _db.GetOneUser(id);


        [HttpGet]
        public List<Map> GetMany(User user) => _db.GetManyUsers();
        
    }
}
