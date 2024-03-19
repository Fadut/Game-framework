using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_framework
{
    public class DefenseItem : WorldObject
    {
        public int ReduceHitPoints {  get; set; }
        public string Name { get; set; }

        public DefenseItem(int x, int y, bool removable, int reduceHitPoints, string name, int uniqueId)
            : base(x, y, removable, uniqueId)
        {
            ReduceHitPoints = reduceHitPoints;
            Name = name;
        }
    }
}
