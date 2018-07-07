using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Tamagotchi.Models;

namespace Tamagotchi.Tests
{
    [TestClass]
    public class TamagotchiPetTest : IDisposable
    {
        public void Dispose()
        {
            TamagotchiPet.ClearAll();
        }

        [TestMethod]
        public void SetGetDecayValue_SetsGetsDecayValue_Int()
        {
            TamagotchiPet pet = new TamagotchiPet("Anton");
            pet.SetDecayValue();
            int randNum = pet.GetDecayValue();
            Assert.AreEqual(randNum, pet.GetDecayValue());
        }

        [TestMethod]
        public void SetGetReplenishValue_SetsGetsReplenishValue_Int()
        {
            TamagotchiPet pet = new TamagotchiPet("Anton");
            pet.SetReplenishValue();
            int randNum = pet.GetDecayValue();
            Assert.AreEqual(randNum, pet.GetReplenishValue());
        }

        [TestMethod] //fix this - how do I test random nums?
        public void FoodDecay_SubtractsFood_Int()
        {
            TamagotchiPet pet = new TamagotchiPet("Anton");
            pet.FoodDecay();
            Assert.AreEqual(pet.GetFood(), pet.GetFood());
        }

        [TestMethod]
        public void FoodReplenish_AddsFood_Int()
        {
            TamagotchiPet pet = new TamagotchiPet("Anton");
            pet.FoodReplenish();
            Assert.AreEqual(100, pet.GetFood());
        }

        [TestMethod]
        public void SetGetName_ReturnsName_String()
        {
            TamagotchiPet pet = new TamagotchiPet("Anton");
            pet.SetName("Tamagot");
            Assert.AreEqual("Tamagotchi", pet.GetName());
        }

        [TestMethod] //fix this - how do I test random nums?
        public void AttentionDecay_SubtractsAttention_Int()
        {
            TamagotchiPet pet = new TamagotchiPet("Anton");
            pet.AttentionDecay();
            Assert.AreEqual(pet.GetAttention(), pet.GetAttention());
        }

        [TestMethod]
        public void AttentionReplenish_AddsAttention_Int()
        {
            TamagotchiPet pet = new TamagotchiPet("Anton");
            pet.AttentionReplenish();
            Assert.AreEqual(100, pet.GetAttention());
        }

        [TestMethod] //fix this - how do I test random nums?
        public void RestDecay_SubtractsRest_Int()
        {
            TamagotchiPet pet = new TamagotchiPet("Anton");
            pet.RestDecay();
            Assert.AreEqual(pet.GetRest(), pet.GetRest());
        }

        [TestMethod]
        public void RestReplenish_AddsRest_Int()
        {
            TamagotchiPet pet = new TamagotchiPet("Anton");
            pet.RestReplenish();
            Assert.AreEqual(100, pet.GetRest());
        }

        [TestMethod]
        public void SetId_GetsId_Int()
        {
            TamagotchiPet pet = new TamagotchiPet("Anton");
            Assert.AreEqual(1, pet.GetId());
        }

        [TestMethod]
        public void SetGetIsDead_SetsGetsIsDead_Bool()
        {
            TamagotchiPet pet = new TamagotchiPet("Anton");
            pet.SetIsDead(true);
            Assert.AreEqual(true, pet.GetIsDead());
        }

        [TestMethod]
        public void GetAll_GetsAllInstancesOfTamagotchiPet_List()
        {
            TamagotchiPet pet1 = new TamagotchiPet("Antony");
            TamagotchiPet pet2 = new TamagotchiPet("Jonathon");
            TamagotchiPet pet3 = new TamagotchiPet("Karamo");
            List<TamagotchiPet> TamagotchiPetList = new List<TamagotchiPet> { pet1, pet2, pet3 };
            CollectionAssert.AreEqual(TamagotchiPetList, TamagotchiPet.GetAll());
        }

        [TestMethod]
        public void ClearAll_ClearsAllInstancesOfBasket_Int()
        {
            TamagotchiPet pet1 = new TamagotchiPet("Antony");
            TamagotchiPet pet2 = new TamagotchiPet("Jonathon");
            TamagotchiPet pet3 = new TamagotchiPet("Karamo");
            TamagotchiPet.ClearAll();
            List<TamagotchiPet> emptyList = new List<TamagotchiPet>() {};
            CollectionAssert.AreEqual(emptyList, TamagotchiPet.GetAll());
        }

        [TestMethod]
        public void Find_FindsTamagotchiPetById_TamagotchiPet()
        {
            TamagotchiPet pet = new TamagotchiPet("Tan");
            Assert.AreEqual(pet, TamagotchiPet.Find(1));
        }

        [TestMethod]
        public void CheckForMax_ChecksIfStatIsHigherThanMax_Int()
        {
            TamagotchiPet pet = new TamagotchiPet("Tan");
            pet.FoodReplenish();
            Assert.AreEqual(100, pet.GetFood());
        }

        [TestMethod]
        public void CheckVitals_ChecksIfPetIsDead_Bool()
        {
            TamagotchiPet pet = new TamagotchiPet("Tan");
            for(int i = 0; i < 20; i++)
            {
                pet.FoodDecay();
            }
            pet.CheckVitals();
            Assert.AreEqual(true, pet.GetIsDead());
        }

        [TestMethod]
        public void SetBuryGetIsBuried_GetsSetsBuried_True()
        {
            TamagotchiPet pet = new TamagotchiPet("Tan");
            pet.Bury();
            Assert.AreEqual(true, pet.IsBuried());
        }
    }
}
