using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_framework.State
{
    // TODO: Maybe this is not needed. Maybe only for snake game
    public enum CreatureHeadingStatesType
    {
        NORTH,
        EAST,
        WEST,
        SOUTH
    };

    public enum InputType
    {
        LEFT,
        RIGHT, 
        FORWARD, 
        BACK
    };

    public record Move(int row, int col);

    public interface IState
    {
        Move NextMove(InputType input);
    }
}
