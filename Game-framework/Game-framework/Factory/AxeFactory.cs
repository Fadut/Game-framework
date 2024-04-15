using Game_framework.Decorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_framework.Factory
{
    public class AxeFactory : IWeaponFactory
    {
        private Random _random = new Random();

        public Weapon CreateWeapon()
        {
            string[] axeNames = { "Wooden Axe", "Stone Axe", "Battle Axe" };
            string randomName = axeNames[_random.Next(axeNames.Length)];

            int randomDamage = _random.Next(7, 18);
            string range = "melee";
            return new Axe(randomDamage, randomName, range);
        }
    }
}
