using Microsoft.AspNetCore.Mvc;

using EV.Dtos;

namespace EV.Controllers
{
    [Route("api")]
    [ApiController]
    public class DataController : Controller {

        // POST /api/PetDetails
        [HttpPost("PetDetails")]
        public ActionResult PetDetails(PetDetailsInputDto p) {
            return Ok(p);
        }

        // GET /api/Out
        [HttpGet("Out")]
        public ActionResult Out() {
            return Ok("asd");
        }
    }
}