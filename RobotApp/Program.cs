using RobotProject;
using System;

namespace RobotApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start the game...");
            var robot = new Robot();
            var board = new Board(5, 5);

            var robotGame = new RobotGame(board, robot, new ConsolMessageDisplayer());
            do
            {
                var command = Console.ReadLine();
                var commandLines = command.Split(" ");

                if (commandLines[0].ToUpper().Equals("QUIT"))
                {
                    break;
                }
                robotGame.ProcessCommand(command);
            } while (true);
        }
    }

    public class ConsolMessageDisplayer : IMessageDisplayer
    {
        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
