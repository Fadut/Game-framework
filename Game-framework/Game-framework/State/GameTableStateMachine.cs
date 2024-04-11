using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_framework.State
{
    class StateAction
    {
        public CreatureHeadingStatesType HeadingState { get; set; } // next state
        public CreatureHeadingStatesType Action { get; set; } // direction the snake should move
    }

    public class GameTableStateMachine : IState
    {
        // internal table as StateMachine
        private StateAction[,] _stateMachine;
        private CreatureHeadingStatesType _currentHeadingState;

        public GameTableStateMachine()
        {
            _currentHeadingState = CreatureHeadingStatesType.NORTH;

            // init table
            _stateMachine = new StateAction[4,3];
            _stateMachine[(int)CreatureHeadingStatesType.NORTH, (int)InputType.LEFT] = new StateAction() { HeadingState = CreatureHeadingStatesType.WEST, Action = CreatureHeadingStatesType.WEST };
            _stateMachine[(int)CreatureHeadingStatesType.NORTH, (int)InputType.RIGHT] = new StateAction() { HeadingState = CreatureHeadingStatesType.EAST, Action = CreatureHeadingStatesType.EAST };
            _stateMachine[(int)CreatureHeadingStatesType.NORTH, (int)InputType.FORWARD] = new StateAction() { HeadingState = CreatureHeadingStatesType.NORTH, Action = CreatureHeadingStatesType.NORTH };

            _stateMachine[(int)CreatureHeadingStatesType.EAST, (int)InputType.LEFT] = new StateAction() { HeadingState = CreatureHeadingStatesType.NORTH, Action = CreatureHeadingStatesType.NORTH };
            _stateMachine[(int)CreatureHeadingStatesType.EAST, (int)InputType.RIGHT] = new StateAction() { HeadingState = CreatureHeadingStatesType.SOUTH, Action = CreatureHeadingStatesType.SOUTH };
            _stateMachine[(int)CreatureHeadingStatesType.EAST, (int)InputType.FORWARD] = new StateAction() { HeadingState = CreatureHeadingStatesType.EAST, Action = CreatureHeadingStatesType.EAST };

            _stateMachine[(int)CreatureHeadingStatesType.WEST, (int)InputType.LEFT] = new StateAction() { HeadingState = CreatureHeadingStatesType.SOUTH, Action = CreatureHeadingStatesType.SOUTH };
            _stateMachine[(int)CreatureHeadingStatesType.WEST, (int)InputType.RIGHT] = new StateAction() { HeadingState = CreatureHeadingStatesType.NORTH, Action = CreatureHeadingStatesType.NORTH };
            _stateMachine[(int)CreatureHeadingStatesType.WEST, (int)InputType.FORWARD] = new StateAction() { HeadingState = CreatureHeadingStatesType.WEST, Action = CreatureHeadingStatesType.WEST };

            _stateMachine[(int)CreatureHeadingStatesType.SOUTH, (int)InputType.LEFT] = new StateAction() { HeadingState = CreatureHeadingStatesType.EAST, Action = CreatureHeadingStatesType.EAST };
            _stateMachine[(int)CreatureHeadingStatesType.SOUTH, (int)InputType.RIGHT] = new StateAction() { HeadingState = CreatureHeadingStatesType.WEST, Action = CreatureHeadingStatesType.WEST };
            _stateMachine[(int)CreatureHeadingStatesType.SOUTH, (int)InputType.FORWARD] = new StateAction() { HeadingState = CreatureHeadingStatesType.SOUTH, Action = CreatureHeadingStatesType.SOUTH };

        }

        public Move NextMove(InputType input)
        {
            // Find next move from current state and input
            CreatureHeadingStatesType nextMove = _stateMachine[(int)_currentHeadingState, (int)input].Action;

            // Find next state from current state and input
            _currentHeadingState = _stateMachine[(int)_currentHeadingState, (int)input].HeadingState;
            return ConvertDirection2Move(nextMove);
        }

        private Move ConvertDirection2Move(CreatureHeadingStatesType nextMove)
        {
            switch (nextMove)
            {
                case CreatureHeadingStatesType.NORTH: return MoveObjects.GoNorth;
                case CreatureHeadingStatesType.EAST: return MoveObjects.GoEast;
                case CreatureHeadingStatesType.SOUTH: return MoveObjects.GoSouth;

                default: return MoveObjects.GoWest;
            }
        }
    }
}
