using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleTamagotchi.Domain
{
    public class Food
    {
        private string _name;
        private int _nutritionalValue;
        private int _cost;

        public string Name => _name;
        public int NutritionalValue => _nutritionalValue;
        public int Cost => _cost;

        public Food(string name, int nutritionalValue, int cost)
        {
            _name = name;
            _nutritionalValue = nutritionalValue;
            _cost = cost;
        }
    }
}
