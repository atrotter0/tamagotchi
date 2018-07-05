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
        private int _decayValue = 0;
        private int _replenishValue = 10;
        private int _id;
        private bool _isDead = false;

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

        public void SetDecayValue()
        {
            Random random = new Random();
            _decayValue = random.Next(5, 15);
        }

        public int GetDecayValue()
        {
            this.SetDecayValue();
            return _decayValue;
        }

        public void SetReplenishValue()
        {
            Random random = new Random();
            _replenishValue = random.Next(5, 15);
        }

        public int GetReplenishValue()
        {
            this.SetReplenishValue();
            return _replenishValue;
        }

        public void FoodDecay()
        {
            _food -= this.GetDecayValue();
        }

        public void FoodReplenish()
        {
            _food += this.GetReplenishValue();
            _food = this.StatCheck(_food);
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
            _attention = this.StatCheck(_attention);
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
            _rest = this.StatCheck(_rest);
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

        public bool CheckVitals()
        {
            if (this.GetFood() <= 0 || this.GetAttention() <= 0 || this.GetRest() <= 0)
            {
              this._isDead = true;
            }
            return _isDead;
        }

        public int StatCheck(int stat)
        {
            if (stat > 100)
            {
                stat = 100;
            }
            return stat;
        }
    }
}
