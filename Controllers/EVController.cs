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

        // GET /api/AllNames
        [HttpGet("AllNames")]
        public ActionResult AllNames() {
            IEnumerable<Breed> breeds = _repository.GetAllBreeds();
            List<string> names = new List<string>();
            foreach(Breed item in breeds) {
                names.Add(item.breed_name);
            }
            return Ok(names);
        }

        // GET /api/AllFacts?breed_name=
        [HttpGet("AllFacts")]
        public ActionResult AllFacts([Required] string breed_name) {
            IEnumerable<Breed> breeds = _repository.GetAllBreeds();
            string facts = "";
            string breed_fact = "";
            foreach(Breed item in breeds) {
                if (item.breed_name == breed_name) {facts = item.facts + "," + facts;}
                else {facts += item.facts + ",";}
            }
            facts = facts.Substring(0, facts.Length - 1);
            return Ok(facts);
        }

        static void CallAPI(string url, string urlParameters)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(urlParameters).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsAsync<IEnumerable<DataObject>>().Result;
                return data;
            }
            client.Dispose();
        }

        // GET /api/PredictWeight
        [HttpGet("PredictWeight")]
        public ActionResult PredictWeight(PetDetailsInputDto p) {
            string url = "";
            string urlParameters = "";
            data = CallAPI(url, urlParameters);
            Ok(data);
        }
    }
}
