using ApiForGrido.DataBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OtherLogicController : ControllerBase
    {
        DataBasePoint _db;
        public OtherLogicController()
            => _db = DataBasePoint.Instance;

        [HttpGet("GetDefaultPhoto")]
        public byte[] GetDefaultPhoto() => _db.GetDefaultPhoto();
    }
}
