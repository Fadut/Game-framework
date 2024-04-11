using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_framework.State
{
    public interface IStateMachinePattern
    {
        IStateMachinePattern NextState(InputType input);
        Move NextAction(InputType input);
    }
}
