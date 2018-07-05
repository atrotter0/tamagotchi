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
            pet.FoodDecay();
            pet.AttentionDecay();
            pet.RestDecay();
          }
          return View("DisplayPetData", allPets);
        }
    }
}
