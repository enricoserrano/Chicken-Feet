using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

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

        // TO-DO: Code for referencing the Python back-end through APIs to set C# as the controller
        // public class DataObject
        // {
        //     public string Name { get; set; }
        // }
        // static void CallAPI(string url, string urlParameters)
        // {
        //     HttpClient client = new HttpClient();
        //     client.BaseAddress = new Uri(url);

        //     client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //     HttpResponseMessage response = client.GetAsync(urlParameters).Result;
        //     if (response.IsSuccessStatusCode)
        //     {
        //         var DataObject = response.Content.ReadAsAsync<IEnumerable<DataObject>>().Result;
        //         return DataObject;
        //     }
        //     client.Dispose();
        // }

        // // GET /api/PredictWeight
        // [HttpGet("PredictWeight")]
        // public ActionResult PredictWeight(PetDetailsInputDto p) {
        //     string url = "https://mysterious-cliffs-03988.herokuapp.com/https://pythonapi21.herokuapp.com/predictHealthyWeight";
        //     string urlParameters = "?breed=" + p.breed + "&sex=" + p.gender + "&age=" + p.age + "&weight=" + p.weight + "&height=" + p.height;
        //     data = CallAPI(url, urlParameters);
        //     Ok(data);
        // }
        // // GET /api/PredictIllness
        // [HttpGet("PredictIllness")]
        // public ActionResult PredictIllness(PetDetailsInputDto p) {
        //     string url = "https://mysterious-cliffs-03988.herokuapp.com/https://pythonapi21.herokuapp.com/predictIllness";
        //     string urlParameters = "?breed=" + p.breed + "&sex=" + p.gender + "&age=" + p.age + "&weight=" + p.weight + "&height=" + p.height;
        //     data = CallAPI(url, urlParameters);
        //     Ok(data);
        // }
        // // GET /api/PredictBehaviour
        // [HttpGet("PredictBehaviour")]
        // public ActionResult PredictBehaviour(PetDetailsInputDto p) {
        //     string url = "https://mysterious-cliffs-03988.herokuapp.com/https://pythonapi21.herokuapp.com/predictBehaviour";
        //     string urlParameters = "?breed=" + p.breed + "&sex=" + p.gender + "&age=" + p.age + "&weight=" + p.weight + "&height=" + p.height;
        //     data = CallAPI(url, urlParameters);
        //     Ok(data);
        // }
    }
}
