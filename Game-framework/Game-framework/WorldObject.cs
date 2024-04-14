using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_framework
{
    /// <summary>
    /// Represents an object in the game world, like Tree and Rock and so on. Obstacles that can block a path.
    /// </summary>
    public class WorldObject
    {
        private bool removable;

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

        public WorldObject(bool removable, int uniqueId, string name)
        {
            this.removable = removable;
            UniqueId = uniqueId;
            Name = name;
        }

        public override string ToString()
        {
            return $"Object: {Name}";
        }
    }
}
