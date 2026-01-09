using ConsoleTamagotchi.Domain;

namespace ConsoleTamagotchi
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Кого выберешь? 1. Собака 2. Кот");

            string type = Console.ReadLine();

            Console.WriteLine("Имя?");

            string name = Console.ReadLine();

            Pet myPet = null;

            if (type == "1") myPet = new Dog(name);
            else if (type == "2") myPet = new Cat(name);
            else { return; }

            while (myPet.Health > 0)
            {
                Console.Clear();
                Console.WriteLine($"--- {myPet.Name} ---");
                Console.WriteLine($"| Здоровье: {myPet.Health} | Голод: {myPet.Hunger} | Силы: {myPet.Stamina} | Солько лет: {myPet.Years} |\n");

                Console.WriteLine("1. Кормить, 2. Играть, 3. Гладить, 4. Спать, 5.Погулять с питомцем, 6. Лечить, 7.Выход");
                string action = Console.ReadLine();

                switch (action)
                {
                    case "1": myPet.Feed(); break;
                    case "2": myPet.Play(); break;
                    case "3": myPet.ToCaress(); break;
                    case "4": myPet.Sleep(); break;
                    case "5": myPet.Walk(); break;
                    case "6": myPet.Heal(); break;
                    case "7": return;
                }

                Console.WriteLine($"Состояние: {myPet.GetStatus()}");
                Console.WriteLine("Нажми Enter...");
                Console.ReadLine();

                if (myPet.Years == 20)
                {
                    Console.WriteLine("R.I.P. Ваш питомец умер... от старости....");
                    break;
                }
            }
            if (myPet.Health == 0)
            {
                Console.WriteLine("R.I.P. Ваш питомец умер...");
            }
        }
    }
}
