using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_framework.Decorator
{
    public abstract class Weapon
    {
        private int _damage;
        private string _name;
        private string _range;

        public int Damage
        {
            get { return _damage; }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("Damage of attack item must be 1 or greater.");
                }
                _damage = value;
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 1)
                {
                    throw new ArgumentException("Name must have atleast 1 character");
                }
                _name = value;
            }
        }

        public string Range
        {
            get { return _range; }
            set
            {
                if (value.ToLower() != "melee" && value.ToLower() != "ranged")
                {
                    throw new ArgumentException("Range must be 'Melee' or 'Ranged'.");
                }
                _range = value;
            }
        }

        public Weapon(int damage, string name, string range)
        {
            Damage = damage;
            Name = name;
            Range = range;
        }

        public override string ToString()
        {
            return $"Name: {Name} (Damage: {Damage}, Range: {Range})";
        }

        public virtual void Attack(Creature target)
        {
            Console.WriteLine($"Attacking with {Name} for {Damage} damage.");
            //target.ReceiveHit(Damage);
        }
    }
}
