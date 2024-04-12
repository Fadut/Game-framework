using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
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
        public int UniqueId { get; set; } // TODO: Consider if id or name
        public int MaxCarryWeight { get; set; }
        public List<int> EquippedWeapons { get; set; } // shows no. of items. Change?
        public World World { get; set; }
        public string Name { get; set; }

        public Creature(int x, int y, int uniqueId, string name)
        {
            X = x;
            Y = y;
            HitPoints = 100; // Starting hit points. Change?
            _attackItems = new List<AttackItem>();
            _defenseItems = new List<DefenseItem>();
            UniqueId = uniqueId;
            MaxCarryWeight = 50; // starting weight. Change?
            EquippedWeapons = new List<int>();
            Name = name;
        }

        public override string ToString()
        {
            return $"Creature: {Name}, Position: ({X}, {Y}), Unique id: {UniqueId}";
        }

        public void Move(int deltaX,  int deltaY)
        {
            X += deltaX;
            Y += deltaY;
        }

        public int Hit(Creature target)
        {
            int totalDamage = 0;

            foreach (int weaponIndex in EquippedWeapons)
            {
                if (weaponIndex < _attackItems.Count)
                {
                    AttackItem weapon = _attackItems[weaponIndex];
                    totalDamage += weapon.HitPoints;
                }
            }

            target.ReceiveHit(totalDamage);

            return totalDamage;
        }

        public void ReceiveHit(int damage)
        {
            // Subtract damage from hit points
            HitPoints -= damage;

            if (HitPoints <= 0)
            {
                Die(); // handle creature death
            }
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
            // Logic hmm
        }

        private void Die()
        {
            Console.WriteLine($"Creature with ID {UniqueId} has died.");
            
            if (World != null)
            {
                World.RemoveCreature(this);
            }
        }
    }
}
