using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTamagotchi.Domain
{
    public abstract class Pet
    {
        // --- ПОЛЯ ---
        private string _name;
        private int _health;
        private int _hunger;
        private int _stamina;
        private int _years;
        private int _mood;
        private int _daysPassed;
        private bool _isDied;

        // --- СВОЙСТВА ---
        public string Name => _name;
        public int Health => _health;
        public int Hunger => _hunger;
        public int Stamina => _stamina;
        public int Years => _years;
        public int Mood => _mood;
        public int DaysPassed => _daysPassed;
        public bool IsDied => _isDied;

        // --- КОНСТАНТЫ (БАЛАНС) ---
        private const int MaxValue = 100;
        private const int MinValue = 0;

        // Время
        private const int MaxYears = 10; // Сделал поменьше для тестов
        private const int DaysPerYear = 10; // 10 действий = 1 год (чтобы быстрее старел)

        // Настройки Голода
        private const int HungerStep = 10;
        private const int StarvationThreshold = 100; // Если голод 100 - теряем здоровье
        private const int StarvationDamage = 15;
        private const int StarvationMood = 10;

        // Настройки Сна
        private const int SleepHungerCost = 30;
        private const int SleepPower = 100;
        private const int BadSleepPenalty = 3; // Делитель (100 / 3)

        // Настройки Игры
        private const int PlayHungerCost = 20; // (HungerStep * 2)
        private const int PlayMoodBonus = 20;
        private const int PlayStaminaCost = 20;

        // Настройки Прогулки
        private const int WalkHungerCost = 30; // (HungerStep * 3)
        private const int WalkMoodBonus = 40;
        private const int WalkStaminaCost = 40;

        // Настройки Ласки
        private const int CaressHungerCost = 5;
        private const int CaressMoodBonus = 5;

        // Настройки Лечения
        private const int HealHungerCost = 10;
        private const int HealStaminaCost = 30;

        protected Pet(string name)
        {
            _name = name;
            _health = 100;
            _hunger = 0;
            _stamina = 100;
            _years = 0;
            _mood = 100;
            _daysPassed = 0;
            _isDied = false;
        }

        private int Clamp(int value, int min, int max)
        {
            if (value > max) return max;
            if (value < min) return min;
            return value;
        }

        private void NormalizeStats()
        {
            // 1. Проверка Голода (влияет на здоровье)
            if (_hunger >= MaxValue)
            {
                _hunger = MaxValue;
                _health -= StarvationDamage;
                _mood = StarvationMood;
            }
            if (_hunger < MinValue) _hunger = MinValue;

            // 2. Обрезка границ (Clamp)
            _stamina = Clamp(_stamina, MinValue, MaxValue);
            _mood = Clamp(_mood, MinValue, MaxValue);

            // 3. Здоровье (верхняя граница)
            if (_health > MaxValue) _health = MaxValue;

            // 4. Проверка Смерти (Здоровье или Возраст)
            if (_health <= 0 || _years >= MaxYears)
            {
                _health = 0;
                _isDied = true;
            }
        }

        private void PassTime()
        {
            _daysPassed++;
            if (_daysPassed % DaysPerYear == 0)
            {
                _years++;
            }
        }

        // --- МЕТОДЫ ДЕЙСТВИЙ (PUBLIC) ---

        public virtual string Feed()
        {
            _health += 10;
            _hunger -= HungerStep;
            _stamina -= 5;

            PassTime();
            NormalizeStats();

            return $"{Name} вкусно покушал. Ням-ням!";
        }

        public virtual string Play()
        {
            _hunger += PlayHungerCost;
            _mood += PlayMoodBonus;
            _stamina -= PlayStaminaCost;

            string extraMessage = "";

            // Если устал во время игры
            if (_stamina <= 0)
            {
                extraMessage = "\n" + Sleep(); // Принудительный сон
            }
            else
            {
                // Если не уснул, то время идет штатно
                PassTime();
                NormalizeStats();
            }

            return $"{Name} весело поиграл!" + extraMessage;
        }

        public abstract string MakeSound();

        public virtual string ToCaress()
        {
            _hunger += CaressHungerCost;
            _mood += CaressMoodBonus;

            PassTime();
            NormalizeStats();

            return $"{Name} - Большое удовольствие: {MakeSound()}";
        }

        public virtual string Sleep()
        {
            _hunger += SleepHungerCost;

            string resultMessage;

            if (_stamina <= 0)
            {
                _stamina += SleepPower / BadSleepPenalty;
                resultMessage = $"{Name} вырубился прямо на полу... Спина болит.";
            }
            else
            {
                _stamina += SleepPower;
                resultMessage = $"{Name} отлично выспался в кроватке!";
            }

            PassTime();
            NormalizeStats();

            return resultMessage;
        }

        public virtual string Walk()
        {
            _hunger += WalkHungerCost;
            _mood += WalkMoodBonus;
            _stamina -= WalkStaminaCost;

            PassTime();
            NormalizeStats();

            return $"{Name} погулял на свежем воздухе. Было круто!";
        }

        public virtual string Heal()
        {
            _hunger += HealHungerCost;
            _health += MaxValue;
            _stamina -= HealStaminaCost;

            PassTime();
            NormalizeStats();

            return $"{Name} принял лекарство и теперь здоров!";
        }

        public string GetStatus()
        {
            // Используем тернарный оператор для краткости (Уровень PRO)
            string hungerStatus = _hunger < 10 ? "Сыт" : (_hunger < 50 ? "Проголодался" : "УМИРАЕТ С ГОЛОДУ!");
            string healthStatus = _health > 80 ? "Здоров" : (_health > 30 ? "Побит" : "При смерти...");
            string staminaStatus = _stamina > 80 ? "Бодр" : (_stamina > 30 ? "Норм" : "Спит на ходу");
            string moodStatus = _mood > 80 ? "Счастлив" : (_mood > 30 ? "Норм" : "Депрессия");

            return $"{hungerStatus} | {healthStatus} | {staminaStatus} | {moodStatus}";
        }
    }
}
