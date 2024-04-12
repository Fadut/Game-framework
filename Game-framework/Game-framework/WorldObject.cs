using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_framework
{
    public class WorldObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsRemovable { get; set; } // if object is wall = not removable
        public int UniqueId { get; private set; }
        public string Name { get; set; }

        public WorldObject(int x, int y, bool removable, int uniqueId, string name)
        {
            X = x;
            Y = y;            
            IsRemovable = removable;
            UniqueId = uniqueId;
            Name = name;
        }
    }
}
