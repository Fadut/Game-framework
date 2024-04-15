using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Game_framework
{
    /// <summary>
    /// Represents a creature in the game, with fitting methods such as Hit, Loot, Die etc. 
    /// </summary>
    public class Creature
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int HitPoints { get; set; }
        public List<AttackItem> _attackItems { get; set; }
        public List<DefenseItem> _defenseItems { get; set; }
        public int UniqueId { get; set; } // TODO: Consider if id or name
        public int MaxCarryWeight { get; set; }
        public List<AttackItem> EquippedWeapons { get; set; } // shows no. of items. Change?
        public World World { get; set; } // Used for Die() method. Refactor?
        public string Name { get; set; }

        /// <summary>
        /// Constructs a new instance of the Creature class.
        /// </summary>
        /// <param name="x">The x-coordinate on the grid-system of the 2D game world.</param>
        /// <param name="y">The y-coordinate on the grid-system of the 2D game world.</param>
        /// <param name="uniqueId">A unique identifier of the Creature. Perhaps unneeded in future.</param>
        /// <param name="name">Name of the creature.</param>
        public Creature(int x, int y, int uniqueId, string name)
        {
            X = x;
            Y = y;
            HitPoints = 100; // Starting hit points. Change?
            _attackItems = new List<AttackItem>();
            _defenseItems = new List<DefenseItem>();
            UniqueId = uniqueId;
            MaxCarryWeight = 50; // Starting weight. Change?
            EquippedWeapons = new List<AttackItem>();
            Name = name;
        }

        public override string ToString()
        {
            return $"Creature: {Name} - Position: ({X}, {Y}). Deals {GetTotalDamage()} damage.";
        }

        public void Move(int deltaX,  int deltaY)
        {
            X += deltaX;
            Y += deltaY;
        }

        public bool IsAlive()
        {
            return HitPoints > 0;
        }

        /// <summary>
        /// The method for a creature hitting another creature (its target). Calculates damage by adding weapons.
        /// </summary>
        /// <param name="target">Target creature to receive the hit, which deals damage to hit points.</param>
        /// <returns></returns>
        public int Hit(Creature target)
        {
            if (IsAlive())
            {
                int totalDamage = 0;

                foreach (AttackItem weapon in EquippedWeapons)
                {
                    totalDamage += weapon.Damage;
                }

                if (target.IsAlive())
                {
                    target.ReceiveHit(totalDamage);

                    Console.WriteLine($"Target: {target.Name} took {totalDamage} damage from {Name}. HP remaining: {target.HitPoints}");

                    if (!target.IsAlive())
                    {
                        Console.WriteLine($"Target {target.Name} has died.");
                        //Die();
                    }
                }
                else
                {
                    Console.WriteLine($"Target {target.Name} is already dead. No damage dealt");
                    return 0;
                }

                return totalDamage;
            }   
            else   
            {
                Console.WriteLine($"Attacker {Name} is dead. Cannot perform attack");
                return 0;  
            }
        }

        public int GetTotalDamage()
        {
            int totalDamage = 0;

            foreach (AttackItem weapon in EquippedWeapons)
            {
                totalDamage += weapon.Damage;
            }

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

        public void Loot(DefenseItem item) // are 2 loot methods needed? Or name change needed
        {
            _defenseItems.Add(item);
        }

        public void EquipWeapon(AttackItem attackItem)
        {
            EquippedWeapons.Add(attackItem);
            Logger.Instance.LogInformation($"Weapon equipped: {attackItem.Name}");
        }

        private void Die()
        {
            Console.WriteLine($"Creature: {Name} with ID: {UniqueId} has died.");
            
            if (World != null)
            {
                World.RemoveCreature(this);
            }
        }
    }
}
