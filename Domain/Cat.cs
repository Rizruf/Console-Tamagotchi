using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTamagotchi.Domain
{
    internal class Cat : Pet
    {
        public Cat(string name) : base(name)
        {

        }

        public override void MakeSound()
        {
            Console.WriteLine("Мяф!");
        }

        public override void Feed()
        {
            base.Feed();
            Console.WriteLine("Мрррр... Чавк Чавк Чавк...");
        }

        public override void Play()
        {
            base.Play();
            Console.WriteLine("Вы чешете пузико коту он очень доволен, вошкается и мурчит");
            MakeSound();
        }

        public override void ToCaress()
        {
            base.ToCaress();
            Console.WriteLine("Мрррр .. Мррррр .. Мрррр ..");
        }

        public override void Walk()
        {
            base.Walk();
            Console.WriteLine("Кот прогулялся и сделал свои грязные делишки!");
        }
    }
}
