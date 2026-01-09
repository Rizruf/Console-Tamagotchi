using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTamagotchi.Domain
{
    public abstract class Pet
    {
        private string _name;
        private int _health;
        private int _hunger;
        private int _stamina;
        private int _years;
        private int _numMood;
        private int _daysPassed;

        public string Name => _name;
        public int Health => _health;
        public int Hunger => _hunger;
        public int Stamina => _stamina;
        public int Years => _years;
        public int NumMood => _numMood;
        public int DaysPassed => _daysPassed;

        protected Pet(string name)
        {
            _name = name;
            _health = 100;
            _hunger = 0;
            _stamina = 100;
            _years = 0; //2 day 1 year; 20 years to died
            _numMood = 100;
            _daysPassed = 0;
        }

        public virtual void Feed()
        {
            _hunger -= 30;
            if (_hunger < 0) _hunger = 0;

            _health += 5;
            if (_health > 100) _health = 100;

            if (_numMood > 100) _numMood = 100;
            else _numMood += 5;

            _stamina -= 2;
            if (_stamina < 0)
            {
                _stamina = 0;
                _numMood -= 10;
            }
        }

        public virtual void Play()
        {
            _hunger += 10;
            if (_hunger > 100)
            {
                _hunger = 100;
                _health -= 30;
            }
            if (_health < 0) _health = 0;

            _stamina -= 20;
            if (_stamina < 0)
            {
                _stamina = 0;
                _numMood -= 10;
            }
            else _numMood += 10;

            if (_numMood > 100) _numMood = 100;
        }

        public abstract void MakeSound();

        public virtual void ToCaress()
        {
            _numMood += 5;
            if (_numMood > 100) _numMood = 100;

            _hunger += 5;
            if (_hunger > 100) _hunger = 100;

            MakeSound();
        }

        public virtual void Sleep()
        {

            _hunger += 30;
            if (_hunger > 100)
            {
                _health -= 30;
                if (_health < 0) _health = 0;
                _hunger = 100;
            }
            _stamina += 100;
            if (_stamina > 100) _stamina = 100;

            _daysPassed++;

            if (_daysPassed % 2 == 0)
            {
                _years++;
                Console.WriteLine("С Днем Рождения! Питомец стал старше.");
            }
        }

        public virtual void Walk()
        {
            _hunger += 25;
            if (_hunger > 100)
            {
                _health -= 25;
                if (_health < 0) _health = 0;
                _hunger = 100;
            }
            _stamina -= 30;
            if (_stamina < 0)
            {
                _stamina = 0;
                _health -= 10;
            }
            _numMood += 30;
            if (_numMood > 100)
            {
                _numMood = 100;
            }
        }

        public virtual void Heal()
        {

        }

        public string GetStatus()
        {
            string hungerStatus = "";
            if (_hunger < 10) hungerStatus = "Сыт";
            else if (_hunger < 50) hungerStatus = "Проголодался";
            else hungerStatus = "УМИРАЕТ С ГОЛОДУ!";

            string healthStatus = "";
            if (_health > 80) healthStatus = "Здоров как бык";
            else if (_health > 30) healthStatus = "Побитый жизнью";
            else healthStatus = "При смерти...";

            string staminaStatus = "";
            if (_stamina > 80) staminaStatus = "Полон сил";
            else if (_stamina > 30) staminaStatus = "Спокойный";
            else staminaStatus = "Падает с ног...";

            string moodStatus = "";
            if (_numMood > 80) moodStatus = "Счастлив";
            else if (_numMood > 30) moodStatus = "Нормально";
            else moodStatus = "Депрессия...";

            return $"{hungerStatus} | {healthStatus} | {staminaStatus} | {moodStatus}";
        }
    }
}
