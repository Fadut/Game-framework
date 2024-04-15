using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_framework.Decorator
{
    public class BasicWeapon : Weapon
    {
        public BasicWeapon() : base(5, "Basic Weapon", "melee") { }
    }
}
