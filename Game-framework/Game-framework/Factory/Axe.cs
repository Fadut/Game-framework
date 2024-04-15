using Game_framework.Decorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_framework.Factory
{
    public class Axe : Weapon
    {
        public Axe(int damage, string name, string range) : base(damage, name, range) { }
    }
}
