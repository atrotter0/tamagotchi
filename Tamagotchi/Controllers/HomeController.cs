using Microsoft.AspNetCore.Mvc;
using Tamagotchi.Models;
using System;
using System.Collections.Generic;

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
              level = pet.GetLevel(),
              exp = pet.GetExp(),
              nextLevel = pet.GetNextLevel(),
              id = pet.GetId(),
              food = pet.GetFood(),
              attention = pet.GetAttention(),
              rest = pet.GetRest()
            });
        }

        public ActionResult DisplayPetData(int id)
        {
            TamagotchiPet pet = TamagotchiPet.Find(id);
            List<TamagotchiPet> singlePetList = new List<TamagotchiPet>() { pet };
            return View(singlePetList);
        }

        public ActionResult AddFood(int id)
        {
          TamagotchiPet pet = TamagotchiPet.Find(id);
          pet.FoodReplenish();
          return Json(new {
            name = pet.GetName(),
            level = pet.GetLevel(),
            exp = pet.GetExp(),
            nextLevel = pet.GetNextLevel(),
            id = pet.GetId(),
            food = pet.GetFood(),
            attention = pet.GetAttention(),
            rest = pet.GetRest()
          });
        }

        public ActionResult AddAttention(int id)
        {
          TamagotchiPet pet = TamagotchiPet.Find(id);
          pet.AttentionReplenish();
          return Json(new {
            name = pet.GetName(),
            level = pet.GetLevel(),
            exp = pet.GetExp(),
            nextLevel = pet.GetNextLevel(),
            id = pet.GetId(),
            food = pet.GetFood(),
            attention = pet.GetAttention(),
            rest = pet.GetRest()
          });
        }

        public ActionResult AddRest(int id)
        {
          TamagotchiPet pet = TamagotchiPet.Find(id);
          pet.RestReplenish();
          return Json(new {
            name = pet.GetName(),
            level = pet.GetLevel(),
            exp = pet.GetExp(),
            nextLevel = pet.GetNextLevel(),
            id = pet.GetId(),
            food = pet.GetFood(),
            attention = pet.GetAttention(),
            rest = pet.GetRest()
          });
        }

        public ActionResult Decay()
        {
          List<TamagotchiPet> allPets = TamagotchiPet.GetAll();
          foreach(TamagotchiPet pet in allPets)
          {
              pet.RunLifeCycle();
          }
          return View("DisplayPetData", allPets);
        }

        [HttpPost("/pet/bury/{id}")]
        public ActionResult BuryPet(int id)
        {
            TamagotchiPet pet = TamagotchiPet.Find(id);
            pet.Bury();
            List<TamagotchiPet> allPets = TamagotchiPet.GetAll();
            return View("DisplayPetData", allPets);
        }
    }
}
