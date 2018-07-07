using System;
using System.Collections.Generic;

namespace Tamagotchi.Models
{
    public class TamagotchiPet
    {
        private const int _MIN_REPLENISH_START = 1;
        private const int _MIN_REPLENISH_END = 11;
        private const int _MID_REPLENISH_START = 5;
        private const int _MID_REPLENISH_END = 11;
        private const int _MAX_REPLENISH_START = 10;
        private const int _MAX_REPLENISH_END = 21;
        private const int _MIN_DECAY_VALUE = 5;
        private const int _MAX_DECAY_VALUE = 11;
        private const int _MAX_STAT_VALUE = 100;

        private string _name;
        private int _level = 1;
        private int _food;
        private int _attention;
        private int _rest;
        private Random _randomNum;
        private int _decayValue;
        private int _replenishValue;
        private int _id;
        private bool _isDead = false;
        private bool _buried = false;
        private static List<TamagotchiPet> _basket = new List<TamagotchiPet>() {};

        public TamagotchiPet(string name)
        {
            this.SetName(name);
            _name = this.GetName();
            _food = _MAX_STAT_VALUE;
            _attention = _MAX_STAT_VALUE;
            _rest = _MAX_STAT_VALUE;
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

        public int GetLevel()
        {
            return _level;
        }

        public void LevelUp()
        {
            _level++;
        }

        public void GenerateRandomSeed()
        {
            Random random = new Random();
            _randomNum = random;
        }

        public void SetRandomSeed(Random random)
        {
            _randomNum = random;
        }

        public Random GetRandomSeed()
        {
            return _randomNum;
        }

        public void SetDecayValue()
        {
            this.GenerateRandomSeed();
            _decayValue = _randomNum.Next(_MIN_DECAY_VALUE, _MAX_DECAY_VALUE);
        }

        public int GetDecayValue()
        {
            this.SetDecayValue();
            return _decayValue;
        }

        public void SetReplenishValue(int min, int max)
        {
            this.GenerateRandomSeed();
            _replenishValue = _randomNum.Next(min, max);
        }

        public int GetReplenishValue(int min, int max)
        {
            this.SetReplenishValue(min, max);
            return _replenishValue;
        }

        public void FoodDecay()
        {
            _food -= this.GetDecayValue();
        }

        public void FoodReplenish()
        {
            _food += this.GetReplenishValue(_MID_REPLENISH_START, _MID_REPLENISH_END);
            _food = this.CheckForMax(_food);
            _attention += this.GetReplenishValue(_MIN_REPLENISH_START, _MIN_REPLENISH_END);
            _attention = this.CheckForMax(_rest);
            _rest += this.GetReplenishValue(_MIN_REPLENISH_START, _MIN_REPLENISH_END);
            _rest = this.CheckForMax(_rest);
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
            _attention += this.GetReplenishValue(_MAX_REPLENISH_START, _MAX_REPLENISH_END);
            _attention = this.CheckForMax(_attention);
            this.RestDecay();
            this.FoodDecay();
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
            _rest += this.GetReplenishValue(_MID_REPLENISH_START, _MID_REPLENISH_END);
            _rest = this.CheckForMax(_rest);
            _attention += this.GetReplenishValue(_MID_REPLENISH_START, _MID_REPLENISH_END);
            _attention = this.CheckForMax(_attention);
            this.FoodDecay();
        }

        public int GetRest()
        {
            return _rest;
        }

        public int CheckForMax(int stat)
        {
            if (stat > _MAX_STAT_VALUE)
            {
                stat = _MAX_STAT_VALUE;
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

        public void Bury() {
            _buried = true;
        }

        public bool IsBuried() {
            return _buried;
        }
    }
}
