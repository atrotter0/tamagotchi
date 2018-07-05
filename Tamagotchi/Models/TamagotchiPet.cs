using System;
using System.Collections.Generic;

namespace Tamagotchi.Models
{
    public class TamagotchiPet
    {
        private string _name;
        private int _food;
        private int _attention;
        private int _rest;
        private int _decayValue = 10;
        private int _replenishValue = 10;
        private int _id;

        private static List<TamagotchiPet> _basket = new List<TamagotchiPet>() {};

        public TamagotchiPet(string name)
        {
            this.SetName(name);
            _name = this.GetName();
            _food = 100;
            _attention = 100;
            _rest = 100;
            _basket.Add(this);
            _id = _basket.Count;
        }

        public void SetName(string name)
        {
            _name = name + "chi";
        }

        public string GetName()
        {
            return _name;
        }

        public int GetId()
        {
            return _id;
        }

        public void SetDecayValue(int decayValue)
        {
            _decayValue = decayValue;
        }

        public int GetDecayValue()
        {
            return _decayValue;
        }

        public void SetReplenishValue(int replenishValue)
        {
            _replenishValue = replenishValue;
        }

        public int GetReplenishValue()
        {
            return _replenishValue;
        }

        public void FoodDecay()
        {
            _food -= this.GetDecayValue();
        }

        public void FoodReplenish()
        {
            _food += this.GetReplenishValue();
        }

        public int GetFood()
        {
            return _food;
        }

        public void AttentionDecay()
        {
            _attention -= this.GetDecayValue();
        }

        public void AttentionReplenish()
        {
            _attention += this.GetReplenishValue();
        }

        public int GetAttention()
        {
            return _attention;
        }

        public void RestDecay()
        {
            _rest -= this.GetDecayValue();
        }

        public void RestReplenish()
        {
            _rest += this.GetReplenishValue();
        }

        public int GetRest()
        {
            return _rest;
        }

        public static List<TamagotchiPet> GetAll()
        {
            return _basket;
        }

        public static void ClearAll()
        {
            _basket.Clear();
        }

        public static TamagotchiPet Find(int searchId)
        {
           return _basket[searchId-1];
        }
    }
}
