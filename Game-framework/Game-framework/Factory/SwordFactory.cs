using Game_framework.Decorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_framework.Factory
{
    public class SwordFactory : IWeaponFactory
    {
        private Random _random = new Random();

        public Weapon CreateWeapon()
        {
            string[] swordNames = { "Iron Sword", "Steel Sword", "Legendary Sword" };
            string randomName = swordNames[_random.Next(swordNames.Length)];

            int randomDamage = _random.Next(5, 25);
            string range = "melee";
            return new Sword(randomDamage, randomName, range);
        }

        // uneeded for melee weapon
        private string GetRandomRange()
        {
            string[] rangeTypes = { "melee", "ranged" };
            return rangeTypes[_random.Next(rangeTypes.Length)];
        }
    }
}
