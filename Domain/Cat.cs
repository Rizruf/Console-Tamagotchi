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

        public override string MakeSound()
        {
            return "Мяф!";
        }

        public override string Feed()
        {
            string baseMessage = base.Feed();
            return baseMessage + "Мрррр... Чавк Чавк Чавк...";
        }

        public override string Play()
        {
            string baseMessage = base.Play();
            MakeSound();
            return baseMessage + $"{MakeSound()} Вы чешете пузико коту он очень доволен, вошкается и мурчит";
        }

        public override string ToCaress()
        {
            string baseMessage = base.ToCaress();
            return baseMessage + "Мрррр .. Мррррр .. Мрррр ..";
        }

        public override string Walk()
        {
            string baseMessage = base.Walk();
            return baseMessage + "Кот прогулялся и сделал свои грязные делишки!";
        }
    }
}
