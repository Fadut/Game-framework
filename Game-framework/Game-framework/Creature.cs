using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Game_framework
{
    public class Creature
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int HitPoints { get; set; }
        public List<AttackItem> _attackItems { get; set; }
        public List<DefenseItem> _defenseItems { get; set; }
        public int UniqueId { get; set; }
        public int MaxCarryWeight { get; set; }
        public List<int> EquippedWeapons { get; set; } // shows no. of items. Change?

        public Creature(int x, int y, int uniqueId)
        {
            X = x;
            Y = y;
            HitPoints = 100; // Starting hit points. Change?
            _attackItems = new List<AttackItem>();
            _defenseItems = new List<DefenseItem>();
            UniqueId = uniqueId;
            MaxCarryWeight = 50; // starting weight. Change?
            EquippedWeapons = new List<int>();
        }

        public void Move(int deltaX,  int deltaY)
        {
            X += deltaX;
            Y += deltaY;
        }

        public int Hit(Creature target)
        {
            // Logic
            return HitPoints; // Revise
        }

        public void ReceiveHit(int damage)
        {
            // Logic
        }

        public void Loot(AttackItem item)
        {
            _attackItems.Add(item);
        }

        public void Loot(DefenseItem item)
        {
            _defenseItems.Add(item);
        }

        public void EquipWeapon(int weaponIndex)
        {
            // Logic
        }
    }
}
