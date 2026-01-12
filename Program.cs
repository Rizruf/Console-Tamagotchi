using ConsoleTamagotchi.Domain;
using ConsoleTamagotchi.Logic;

namespace ConsoleTamagotchi
{
    internal class Program
    {
        public enum MenuAction
        {
            Feed = 1,
            Play,
            Caress,
            Sleep,
            Walk,
            Heal,
            Shop,
            Work,
            Exit
        }

        static void Main(string[] args)
        {
            Shop shop = new Shop();

            int money = 100;

            Console.WriteLine("Кого выберешь? 1. Собака 2. Кот");

            string type = Console.ReadLine();

            Console.WriteLine("Имя?");

            string name = Console.ReadLine();

            Pet myPet = null;

            if (type == "1") myPet = new Dog(name);
            else if (type == "2") myPet = new Cat(name);
            else { return; }

            List<Food> inventory = new List<Food>();

            inventory.Add(new Food("Сочное яблоко", 10, 10));
            inventory.Add(new Food("Стейк Рибай", 40, 40));
            inventory.Add(new Food("Сухарик", 5, 5));
            inventory.Add(new Food("Элитный Корм", 50, 50));

            while (myPet.IsDied == false)
            {
                Console.Clear();
                Console.WriteLine($"--- {myPet.Name} ---");
                Console.WriteLine($"| Здоровье: {myPet.Health} | Голод: {myPet.Hunger} | Силы: {myPet.Stamina} | Солько лет: {myPet.Years} |\n");

                Console.WriteLine("1. Кормить, 2. Играть, 3. Гладить, 4. Спать, 5.Погулять с питомцем, 6. Лечить, 7. Магазин, 8. Работа 9.Выход");
                string action = Console.ReadLine();

                if (Enum.TryParse(action, out MenuAction currentAction))
                {
                    switch (currentAction)
                    {
                        case MenuAction.Feed:

                            if (inventory.Count == 0)
                            {
                                Console.WriteLine("Рюкзак пуст! Нечего кушать :(");
                                break;
                            }

                            Console.WriteLine("--- ИНВЕНТАРЬ ---");
                            for (int i = 0; i < inventory.Count; i++)
                            {

                                Console.WriteLine($"{i + 1}. {inventory[i].Name} (Сытость: {inventory[i].NutritionalValue})");
                            }

                            Console.Write("Что выберешь (номер): ");
                            string input = Console.ReadLine();

                            if (int.TryParse(input, out int foodIndex) && foodIndex > 0 && foodIndex <= inventory.Count)
                            {

                                Food selectedFood = inventory[foodIndex - 1];


                                Console.WriteLine(myPet.Feed(selectedFood));


                                inventory.Remove(selectedFood);

                            }
                            else
                            {
                                Console.WriteLine("Такой еды нет! Питомец смотрит на тебя с недоумением.");
                            }
                            break;

                        case MenuAction.Play:
                            Console.WriteLine(myPet.Play());
                            break;
                        case MenuAction.Caress:
                            Console.WriteLine(myPet.ToCaress());
                            break;
                        case MenuAction.Sleep:
                            Console.WriteLine(myPet.Sleep());
                            break;
                        case MenuAction.Walk:
                            Console.WriteLine(myPet.Walk());
                            break;
                        case MenuAction.Heal:
                            Console.WriteLine(myPet.Heal());
                            break;
                        case MenuAction.Shop:

                            List<Food> product = shop.GetFoods();
                            while (true)
                            {
                                Console.WriteLine($"У вас в кормане {money}");
                                Console.WriteLine("Что хотите купить?");

                                if (product.Count == 0)
                                {
                                    Console.WriteLine("В магазине нечего купить!");
                                    break;
                                }

                                Console.WriteLine(" ---Товары--- ");
                                for (int i = 0; i < product.Count; i++)
                                {
                                    Console.WriteLine($"Товар {i + 1} {product[i].Name} - питательность: {product[i].NutritionalValue}");
                                }

                                Console.WriteLine("Продавец: Что выбираете? (номер)");
                                string choice = Console.ReadLine();

                                if (int.TryParse(choice, out int currentCoice) && currentCoice > 0 && currentCoice <= product.Count && money >= product[currentCoice - 1].Cost)
                                {
                                    money -= product[currentCoice - 1].Cost;

                                    Food selectedProduct = product[currentCoice - 1];

                                    Console.WriteLine($"Вы купили: {product[currentCoice - 1].Name}");


                                    product.Remove(selectedProduct);

                                    inventory.Add(selectedProduct);

                                    Console.WriteLine($"У вас в кормане {money}");
                                }
                                else
                                {
                                    Console.WriteLine("Такой еды нет! Продавец смотрит на тебя с недоумением.");
                                }

                                Console.WriteLine("Хотите купить еще что-то? 1. Да, 2. Нет");
                                string answer = Console.ReadLine();

                                answer = answer.ToLower();

                                if (answer == "да")
                                {
                                    continue;
                                }
                                else break;

                            }
                            break;

                        case MenuAction.Work:
                            money += 75;
                            myPet.Wait();

                            Console.WriteLine("Вы поработали и добавили в своей кошелек 75 монет");
                            break;
                        default:
                            Console.WriteLine("Вы ввели того что не существует! Повторите свой выбор. Нажмите Enter.");
                            Console.ReadLine();
                            continue;
                    }
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
            if (myPet.IsDied == true && myPet.Years != 20)
            {
                Console.WriteLine("R.I.P. Ваш питомец умер...");
            }
        }
    }
}
