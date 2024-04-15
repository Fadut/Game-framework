using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_framework.Decorator
{
    public class PoisonDecorator : Weapon
    {
        private readonly Weapon _weapon;

        public PoisonDecorator(Weapon weapon) : base(weapon.Damage, "Poisoned" + weapon.Name, weapon.Range)
        {
            _weapon = weapon;
        }

        public override void Attack(Creature target)
        {
            Console.WriteLine($"Poisoned attack with {Name} for {_weapon.Damage} damage.");
            // target.ReceiveHit(_weapon.Damage)
            // Poison effect logic
        }
    }
}
