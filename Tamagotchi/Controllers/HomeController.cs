using Microsoft.AspNetCore.Mvc;
using Tamagotchi.Models;
using System;
using Newtonsoft.Json;

namespace Tamagotchi.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreatePet(string name)
        {
            TamagotchiPet pet = new TamagotchiPet(name);
            return Json(new {
              name = pet.GetName(),
              id = pet.GetId(),
              food = pet.GetFood(),
              attention = pet.GetAttention(),
              rest = pet.GetRest()
            });
        }
    }
}
