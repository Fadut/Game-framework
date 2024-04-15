using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_framework.Observer
{
    public class HealthMonitor : IObserver
    {
        public void Update(Creature creature)
        {
            Console.WriteLine($"Hit points update: {creature.Name}'s HP is now {creature.HitPoints}");
        }
    }
}
