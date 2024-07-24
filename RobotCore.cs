using System;

namespace ToyRobotPuzzle;

public static class RobotCore
{
    public static (int X, int Y) Move((int X, int Y) position, Direction direction)
    {
        return direction switch
        {
            Direction.NORTH => (position.X, position.Y + 1),
            Direction.SOUTH => (position.X, position.Y - 1),
            Direction.EAST => (position.X + 1, position.Y),
            Direction.WEST => (position.X - 1, position.Y),
            _ => position
        };
    }

    public static Direction TurnLeft(Direction direction)
    {
        return direction switch
        {
            Direction.NORTH => Direction.WEST,
            Direction.WEST => Direction.SOUTH,
            Direction.SOUTH => Direction.EAST,
            Direction.EAST => Direction.NORTH,
            _ => direction
        };
    }

    public static Direction TurnRight(Direction direction)
    {
        return direction switch
        {
            Direction.NORTH => Direction.EAST,
            Direction.EAST => Direction.SOUTH,
            Direction.SOUTH => Direction.WEST,
            Direction.WEST => Direction.NORTH,
            _ => direction
        };
    }
}

