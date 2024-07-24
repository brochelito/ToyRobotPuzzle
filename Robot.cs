using System;

namespace ToyRobotPuzzle;

public class Robot
{
    private readonly Table _table;
    private int _x;
    private int _y;
    private Direction _direction;
    private bool _isPlaced;

    private Robot(Table table)
    {
        _table = table;
    }

    public static Robot Create(Table table)
    {
        return new Robot(table);
    }

    public void ProcessCommand(string command)
    {
        var commands = command.Split(' ');

        if (commands.Length == 0)
        {
            HandleEmptyCommands();
            return;
        }

        ProcessNonEmptyCommands(commands);
    }

    private void ProcessNonEmptyCommands(string[] commands)
    {
        var commandType = commands[0];
        var arguments = commands.Length > 1 ? commands[1] : null;

        switch (commandType)
        {
            case "PLACE":
                if (arguments != null) HandlePlaceCommand(arguments);
                break;

            case "MOVE":
                Move();
                break;

            case "LEFT":
                TurnLeft();
                break;

            case "RIGHT":
                TurnRight();
                break;

            case "REPORT":
                Report();
                break;

            default:
                HandleUnknownCommand();
                break;
        }
    }

    private void HandleEmptyCommands()
    {
        Console.WriteLine("No commands provided.");
    }

    private void HandlePlaceCommand(string arguments)
    {
        if (PlaceCommand.TryCreate(arguments, _direction, out var placeCommand))
        {
            Place(placeCommand.X, placeCommand.Y, placeCommand.Direction);
        }
    }

    private void HandleUnknownCommand()
    {
        Console.WriteLine("Unknown command received.");
    }

    private void Place(int x, int y, Direction direction)
    {
        if (_table.IsValidPosition(x, y))
        {
            _x = x;
            _y = y;
            _direction = direction;
            _isPlaced = true;
        }
    }

    private void Move()
    {
        if (!_isPlaced) return;

        var newPosition = RobotCore.Move((_x, _y), _direction);
        if (_table.IsValidPosition(newPosition.X, newPosition.Y))
        {
            _x = newPosition.X;
            _y = newPosition.Y;
        }
    }

    private void TurnLeft()
    {
        if (!_isPlaced) return;

        _direction = RobotCore.TurnLeft(_direction);
    }

    private void TurnRight()
    {
        if (!_isPlaced) return;

        _direction = RobotCore.TurnRight(_direction);
    }

    private void Report()
    {
        if (!_isPlaced) return;

        Console.WriteLine($"{_x},{_y},{_direction}");
    }
}
