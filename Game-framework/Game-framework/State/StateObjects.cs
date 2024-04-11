using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_framework.State
{
    public class StateObjects
    {
        public static IStateMachinePattern North => new StateMachinePatternNorth();

        public static IStateMachinePattern West = new StateMachinePatternNorth();

        public static IStateMachinePattern South = new StateMachinePatternNorth();

        public static IStateMachinePattern East = new StateMachinePatternNorth();
    }
}
