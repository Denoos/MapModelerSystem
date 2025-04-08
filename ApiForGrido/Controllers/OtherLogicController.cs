using ApiForGrido.DataBase;
using Grido.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiForGrido.Controllers
{
    public class OtherLogicController : Controller
    {
        DataBasePoint _db;

        OtherLogicController()
            => _db = DataBasePoint.Instance;


        [HttpGet]
        public byte[] GetDefaultPhoto() => _db.GetDefaultPhoto();
    }
}
