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

        public override void MakeSound()
        {
            Console.WriteLine("Ваф!");
        }

        public override void Feed()
        {
            base.Feed();
            Console.WriteLine("Собака виляет хвостом и чавкает!");
        }

        public override void Play()
        {
            base.Play();
            Console.WriteLine("Теперь собака довольна и чуток подустала!");
        }

        public override void ToCaress()
        {
            base.ToCaress();
            Console.WriteLine("Счастливый Ваф!");

        }

        public override void Walk()
        {
            base.Walk();
            Console.WriteLine("Собака набегалась на улице и нагавкалась на собак за оградами!");
        }

    }
}
