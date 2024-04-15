using Game_framework.Decorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_framework.Factory
{
    public class BowFactory : IWeaponFactory
    {
        private Random _random = new Random();

        public Weapon CreateWeapon()
        {
            string[] bowNames = { "Short Bow", "Long Bow", "Composite Bow" };
            string randomName = bowNames[_random.Next(bowNames.Length)];

            int randomDamage = _random.Next(4, 22);
            string range = "ranged";
            return new Bow(randomDamage, randomName, range);
        }
    }
}
