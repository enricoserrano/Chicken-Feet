using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EV.Controllers
{
    [Route("api")]
    [ApiController]
    public class DataController : Controller {

        // POST /api/PetData
        [HttpPost("PetData")]
        public ActionResult PetDetails(PetDetailsInputDto p) {
            return Ok(p);
        }
    }
}