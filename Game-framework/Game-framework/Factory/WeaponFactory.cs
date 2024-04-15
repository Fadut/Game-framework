using Game_framework.Decorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_framework.Factory
{
    public interface IWeaponFactory
    {
        Weapon CreateWeapon();
    }
}
