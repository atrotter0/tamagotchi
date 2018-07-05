using System;
using System.Collections.Generic;

namespace Tamagotchi.Models
{
    public class TamagotchiPet
    {
        private int _food;
        private int _attention;
        private int _rest;
        private int _decayValue = 10;
        private int _replenishValue = 10;

        private static List<TamagotchiPet> _basket = new List<TamagotchiPet>() {};

        public TamagotchiPet()
        {
            _food = 100;
            _attention = 100;
            _rest = 100;
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
    }
}
