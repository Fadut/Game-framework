using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_framework
{
    public class AttackItem : WorldObject
    {
        public int HitPoints { get; set; } // Change?
        public int Range { get; set; }
        public string Name { get; set; }

        public AttackItem(int x, int y, bool removable, int hitPoints, int range, string name, int uniqueId)
            : base(x, y, removable, uniqueId, name) 
        {
            HitPoints = hitPoints;
            Range = range;
            Name = name;
        }
    }
}
