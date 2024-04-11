using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_framework.State
{
    public class GameStateMachinePattern : IState
    {
        private IStateMachinePattern _currentState;

        public GameStateMachinePattern()
        {
            _currentState = new StateMachinePatternNorth();
        }

        public Move NextMove(InputType input)
        {
            // Find next move from current state and input
            Move nextMove = _currentState.NextAction(input);

            // Find next state from current state and input
            _currentState = _currentState.NextState(input);

            return nextMove;
        }
    }
}
