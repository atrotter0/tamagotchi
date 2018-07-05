using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Tamagotchi.Models;

namespace Tamagotchi.Tests
{
    [TestClass]
    public class TamagotchiPetTest
    {
        [TestMethod]
        public void SetGetDecayValue_SetsGetsDecayValue_Int()
        {
            TamagotchiPet pet = new TamagotchiPet();
            pet.SetDecayValue(10);
            Assert.AreEqual(10, pet.GetDecayValue());
        }

        [TestMethod]
        public void SetGetReplenishValue_SetsGetsReplenishValue_Int()
        {
            TamagotchiPet pet = new TamagotchiPet();
            pet.SetReplenishValue(5);
            Assert.AreEqual(5, pet.GetReplenishValue());
        }

        [TestMethod]
        public void FoodDecay_SubtractsFood_Int()
        {
            TamagotchiPet pet = new TamagotchiPet();
            pet.FoodDecay();
            Assert.AreEqual(90, pet.GetFood());
        }

        [TestMethod]
        public void FoodReplenish_AddsFood_Int()
        {
            TamagotchiPet pet = new TamagotchiPet();
            pet.FoodReplenish();
            Assert.AreEqual(110, pet.GetFood());
        }
    }
}
