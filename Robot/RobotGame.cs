using System;
using System.Linq;

namespace RobotProject
{
    public interface IMessageDisplayer
    {
        void DisplayMessage(string message);
    }

    public class RobotGame
    {
        private Robot _robot;
        private Board _board;
        private IMessageDisplayer _messageDisplayer;

        public RobotGame(Board board1, Robot robot1, IMessageDisplayer messageDisplayer)
        {
            _robot = robot1;
            _board = board1;
            _messageDisplayer = messageDisplayer;
        }

        public void ProcessCommand(string command)
        {
            var commandLines = command.Split(" ");

            switch (commandLines[0].ToUpper())
            {
                case "PLACE":
                    var position = BuildFromArgs(commandLines.Skip(1).ToArray());
                    if (position == null)
                    {
                        _messageDisplayer.DisplayMessage("Invald Args");
                        break;
                    }
                    _robot.PlaceAt(position);
                    break;
                case "LEFT":
                    _robot.Left();
                    break;
                case "RIGHT":
                    _robot.Right();
                    break;
                case "MOVE":
                    if (_robot.Report() == null) break;
                    var newPosition = _robot.Report().NewPosition();
                    if (!_board.ValdatePosition(newPosition))
                    {
                        _robot.PlaceAt(newPosition);
                    }
                    break;
                case "REPORT":
                    var poistion = _robot.Report();
                    if (poistion == null)
                    {
                        _messageDisplayer.DisplayMessage($"Off the board!....");
                        break;
                    };
                    _messageDisplayer.DisplayMessage($"Output: {poistion.X}, {poistion.Y}, {poistion.Direction.ToString()}");
                    break;
                default:
                    _messageDisplayer.DisplayMessage("Invalid Commands");
                    break;
            }
        }

        public static RobotPosition BuildFromArgs(string[] args)
        {
            if (args.Length != 3)
            {
                return null;
            }

            Enum.TryParse(args[2], true, out DirectionEnum direction);
            Int32.TryParse(args[0], out int x);
            Int32.TryParse(args[1], out int y);


            return new RobotPosition
            {
                X = x,
                Y = y,
                Direction = direction
            };
        }

    }
}
