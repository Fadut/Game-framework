using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_framework
{
    public class AttackItem : WorldObject
    {
        public int Damage { get; set; } // Change?
        public int Range { get; set; }
        public string Name { get; set; }

        public AttackItem(int x, int y, bool removable, int damage, int range, string name, int uniqueId)
            : base(x, y, removable, uniqueId, name) 
        {
            Damage = damage;
            Range = range;
            Name = name;
        }

        public override string ToString()
        {
            return Name + "deals " + Damage + " damage";
        }
    }
}
