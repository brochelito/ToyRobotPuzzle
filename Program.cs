using System;

namespace ToyRobotPuzzle;

class Program
{
    static void Main(string[] args)
    {
        Table table = Table.Create(5);
        Robot robot = Robot.Create(table);

        string command;
        while ((command = Console.ReadLine()) != null)
        {
            robot.ProcessCommand(command);
        }
    }
}