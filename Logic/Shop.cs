using ConsoleTamagotchi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTamagotchi.Logic
{
    internal class Shop
    {
        public List <Food> GetFoods()
        {
            return new List<Food>
            {
                new Food("Стейк", 50, 200),
                new Food("Фарш", 20, 75),
                new Food("Молоко", 5, 10),
                new Food("Вода", 3, 5),
                new Food("Гречка", 28, 78),
                new Food("Сосиски", 30, 80),
                new Food("Пирловка", 21, 70),
                new Food("Рис с мясом", 70, 350),
                new Food("Корм для котов", 25, 100),
                new Food("Корм для собак", 25, 100)
            };
        }



        
    }
}
