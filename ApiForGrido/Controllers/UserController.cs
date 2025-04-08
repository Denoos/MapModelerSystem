using ApiForGrido.DataBase;
using Grido.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiForGrido.Controllers
{
    public class UserController : Controller
    {
        DataBasePoint _db;

        UserController()
            => _db = DataBasePoint.Instance;


        [HttpPost]
        public bool Add(Map map) => _db.AddMap(map);
        [HttpPut]
        public bool Edit(Map map) => _db.EditMap(map);
        [HttpDelete]
        public bool Del(Map map) => _db.DeleteMap(map);
        [HttpGet]
        public Map GetOne(int id) => _db.GetOneMap(id);
        [HttpGet]
        public List<Map> GetMany(Map map) => _db.GetManyMaps();
    }
}
