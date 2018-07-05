using Microsoft.AspNetCore.Mvc;
using Tamagotchi.Models;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tamagotchi.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public ActionResult Index()
        {
            List<TamagotchiPet> allPets = TamagotchiPet.GetAll();
            return View(allPets);
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

        public ActionResult DisplayPetData()
        {
            Console.WriteLine("made it to DisplayPetData");
            return View();
        }
    }
}
