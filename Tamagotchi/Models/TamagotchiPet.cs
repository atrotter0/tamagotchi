using System;
using System.Collections.Generic;

namespace Tamagotchi.Models
{
    public class TamagotchiPet
    {
        const int MAX_STAT = 100;
        private string _name;
        private int _food;
        private int _attention;
        private int _rest;
        private int _decayValue;
        private int _replenishValue;
        private int _id;
        private bool _isDead = false;
        private static List<TamagotchiPet> _basket = new List<TamagotchiPet>() {};

        public TamagotchiPet(string name)
        {
            this.SetName(name);
            _name = this.GetName();
            _food = MAX_STAT;
            _attention = MAX_STAT;
            _rest = MAX_STAT;
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
            _food = this.CheckForMax(_food);
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
            _attention = this.CheckForMax(_attention);
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
            _rest = this.CheckForMax(_rest);
        }

        public int GetRest()
        {
            return _rest;
        }

        public int CheckForMax(int stat)
        {
            if (stat > MAX_STAT)
            {
                stat = MAX_STAT;
            }
            return stat;
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

        public void SetIsDead(bool isDead)
        {
            _isDead = isDead;
        }

        public bool GetIsDead()
        {
            return _isDead;
        }

        public bool CheckVitals()
        {
            if (this.GetFood() <= 0 || this.GetAttention() <= 0 || this.GetRest() <= 0)
            {
                this.SetIsDead(true);
            }
            return this.GetIsDead();
        }
    }
}
