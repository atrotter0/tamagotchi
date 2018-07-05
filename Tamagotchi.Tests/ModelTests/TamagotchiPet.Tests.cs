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

        [TestMethod]
        public void SetGetName_ReturnsName_String()
        {
            TamagotchiPet pet = new TamagotchiPet();
            pet.SetName("Tamagot");
            Assert.AreEqual("Tamagotchi", pet.GetName());
        }

        [TestMethod]
        public void AttentionDecay_SubtractsAttention_Int()
        {
            TamagotchiPet pet = new TamagotchiPet();
            pet.AttentionDecay();
            Assert.AreEqual(90, pet.GetAttention());
        }

        [TestMethod]
        public void AttentionReplenish_AddsAttention_Int()
        {
            TamagotchiPet pet = new TamagotchiPet();
            pet.AttentionReplenish();
            Assert.AreEqual(110, pet.GetAttention());
        }

        [TestMethod]
        public void RestDecay_SubtractsRest_Int()
        {
            TamagotchiPet pet = new TamagotchiPet();
            pet.RestDecay();
            Assert.AreEqual(90, pet.GetRest());
        }

        [TestMethod]
        public void RestReplenish_AddsRest_Int()
        {
            TamagotchiPet pet = new TamagotchiPet();
            pet.RestReplenish();
            Assert.AreEqual(110, pet.GetRest());
        }

        [TestMethod]
        public void SetId_GetsId_Int()
        {
            TamagotchiPet pet = new TamagotchiPet();
            Assert.AreEqual(1, pet.GetId());
        }

        [TestMethod]
        public void GetAll_GetsAllInstancesOfTamagotchiPet_List()
        {
            TamagotchiPet pet1 = new TamagotchiPet();
            TamagotchiPet pet2 = new TamagotchiPet();
            TamagotchiPet pet3 = new TamagotchiPet();
            List<TamagotchiPet> TamagotchiPetList = new List<TamagotchiPet> { pet1, pet2, pet3 };
            CollectionAssert.AreEqual(TamagotchiPetList, TamagotchiPet.GetAll());
        }

        [TestMethod]
        public void ClearAll_ClearsAllInstancesOfBasket_Int()
        {
            TamagotchiPet pet1 = new TamagotchiPet();
            TamagotchiPet pet2 = new TamagotchiPet();
            TamagotchiPet pet3 = new TamagotchiPet();
            TamagotchiPet.ClearAll();
            List<TamagotchiPet> emptyList = new List<TamagotchiPet>() {};
            CollectionAssert.AreEqual(emptyList, TamagotchiPet.GetAll());
        }

        [TestMethod]
        public void Find_FindsTamagotchiPetById_TamagotchiPet()
        {
            TamagotchiPet pet = new TamagotchiPet();
            Assert.AreEqual(pet, TamagotchiPet.Find(1));
        }
    }
}
