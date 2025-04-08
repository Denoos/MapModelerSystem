using ApiForGrido.DataBase;
using Grido.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiForGrido.Controllers
{
    public class AdminController : Controller
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
        [HttpGet]
        public User GetOne(User user) => _db.GetOneUser();
        [HttpGet]
        public List<Map> GetMany(User user) => _db.GetManyUsers();
    }
}
