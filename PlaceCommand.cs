namespace ToyRobotPuzzle;

public class PlaceCommand
{
    public int X { get; }
    public int Y { get; }
    public Direction Direction { get; }

    private PlaceCommand(int x, int y, Direction direction)
    {
        X = x;
        Y = y;
        Direction = direction;
    }

    public static bool TryCreate(string arguments, Direction defaultDirection, out PlaceCommand placeCommand)
    {
        placeCommand = null;
        var args = arguments.Split(',');
        if (args.Length < 2 ||
            !int.TryParse(args[0], out int x) ||
            !int.TryParse(args[1], out int y))
        {
            return false;
        }

        var direction = args.Length == 3 ? ParseDirection(args[2]) : defaultDirection;
        placeCommand = new PlaceCommand(x, y, direction);
        return true;
    }

    private static Direction ParseDirection(string direction)
    {
        return direction.ToUpper() switch
        {
            "NORTH" => Direction.NORTH,
            "SOUTH" => Direction.SOUTH,
            "EAST" => Direction.EAST,
            "WEST" => Direction.WEST,
            _ => throw new ArgumentException("Invalid direction")
        };
    }
}
