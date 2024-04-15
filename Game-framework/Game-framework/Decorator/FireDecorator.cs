using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_framework.Decorator
{
    public class FireDecorator : Weapon
    {
        private readonly Weapon _weapon;

        public FireDecorator(Weapon weapon) : base(weapon.Damage, "Fire" + weapon.Name, weapon.Range)
        {
            _weapon = weapon;
        }

        public override void Attack(Creature target)
        {
            Console.WriteLine($"Fire attack with {Name} for {_weapon.Damage} damage.");
            // target.ReceiveHit(_weapon.Damage)
            // Fire effect logic
        }
    }
}
