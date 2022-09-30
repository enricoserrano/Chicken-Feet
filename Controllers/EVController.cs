using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

using EV.Data;
using EV.Models;
using EV.Dtos;

namespace EV.Controllers
{
    [Route("api")]
    [ApiController]
    public class DataController : Controller {

        private readonly IEVRepo _repository;
        
        public DataController(IEVRepo repository) {
            _repository = repository;
        }
        
        // POST /api/PetDetails
        [HttpPost("PetDetails")]
        public ActionResult PetDetails(PetDetailsInputDto p) {
            return Ok(p);
        }

        // GET /api/AllBreeds
        [HttpGet("AllBreeds")]
        public ActionResult AllBreeds() {
            IEnumerable<Breed> breeds = _repository.GetAllBreeds();
            return Ok(breeds);
        }

        // GET /api/BreedInfo?breed_name=
        [HttpGet("BreedInfo")]
        public ActionResult BreedInfo([Required] string breed_name) {
            Breed? breed = _repository.GetBreed(breed_name);
            if (breed != null) {return Ok(breed);};
            return NotFound("Not in DB");
        }
    }
}
