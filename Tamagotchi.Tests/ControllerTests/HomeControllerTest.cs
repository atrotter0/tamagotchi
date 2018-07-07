using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Tamagotchi.Controllers;
using Tamagotchi.Models;

namespace Tamagotchi.Tests
{
    [TestClass]
    public class HomeControllerTest : IDisposable
    {
        public void Dispose()
        {
            TamagotchiPet.ClearAll();
        }

        [TestMethod]
        public void Index_ReturnsCorrectView_True()
        {
            HomeController controller = new HomeController();
            ActionResult Index = controller.Index();
            Assert.IsInstanceOfType(Index, typeof(ViewResult));
        }

        [TestMethod]
        public void Index_HasCorrectModelType_Account()
        {
            ViewResult Index = new HomeController().Index() as ViewResult;
            var result = Index.ViewData.Model;
            Assert.IsInstanceOfType(result, typeof(List<TamagotchiPet>));
        }

        [TestMethod]
        public void DisplayPetData_ReturnsCorrectView_True()
        {
            TamagotchiPet pet = new TamagotchiPet("Gandalf");
            HomeController controller = new HomeController();
            ActionResult DisplayPetData = controller.DisplayPetData(1);
            Assert.IsInstanceOfType(DisplayPetData, typeof(ViewResult));
        }

        [TestMethod]
        public void DisplayPetData_HasCorrectModelType_Account()
        {
            TamagotchiPet pet = new TamagotchiPet("Gandalf");
            ViewResult DisplayPetData = new HomeController().DisplayPetData(1) as ViewResult;
            var result = DisplayPetData.ViewData.Model;
            Assert.IsInstanceOfType(result, typeof(List<TamagotchiPet>));
        }

        [TestMethod]
        public void BuryPet_ReturnsCorrectView_True()
        {
            TamagotchiPet pet = new TamagotchiPet("Balrog");
            HomeController controller = new HomeController();
            ActionResult BuryPet = controller.BuryPet(1);
            Assert.IsInstanceOfType(BuryPet, typeof(ViewResult));
        }

        [TestMethod]
        public void BuryPet_HasCorrectModelType_Account()
        {
            TamagotchiPet pet = new TamagotchiPet("Sauron");
            ViewResult BuryPet = new HomeController().BuryPet(1) as ViewResult;
            var result = BuryPet.ViewData.Model;
            Assert.IsInstanceOfType(result, typeof(List<TamagotchiPet>));
        }
    }
}
