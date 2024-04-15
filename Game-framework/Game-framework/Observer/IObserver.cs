using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_framework.Observer
{
    public interface IObserver
    {
        void Update(Creature creature);
    }
}
