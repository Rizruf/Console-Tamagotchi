using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTamagotchi.Domain
{
    internal class Dog : Pet
    {
        public Dog(string name) : base(name)
        {

        }

        public override string MakeSound()
        {
            return "Гав-Гав!";
        }

        public override string Feed()
        {
            // Вызываем базовый метод, получаем строку, добавляем свою
            string baseMessage = base.Feed();
            return baseMessage + " Собака виляет хвостом!";
        }

        public override string Play()
        {
            string baseMessage = base.Feed();
            return baseMessage + $"{MakeSound()} Теперь собака довольна и чуток подустала!";
        }

        public override string ToCaress()
        {
            string baseMessage = base.ToCaress();
            return baseMessage + "Счастливый Ваф!";

        }

        public override string Walk()
        {
            string baseMessage = base.Walk();
            return baseMessage + "Собака набегалась на улице и нагавкалась на собак за оградами!";
        }

    }
}
