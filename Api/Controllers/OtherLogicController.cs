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
        private readonly ILogger<OtherLogicController> _logger;

        OtherLogicController()
            => _db = DataBasePoint.Instance;

        public OtherLogicController(ILogger<OtherLogicController> logger)
            => _logger = logger;

        [HttpGet(Name = "GetDefaultPhoto")]
        public byte[] GetDefaultPhoto() => _db.GetDefaultPhoto();
    }
}
