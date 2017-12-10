using Moq;
using NUnit.Framework;
using RobotProject;

namespace Robot.Tests
{
    [TestFixture]
    public class RobotGameTests
    {
        [TestCase(DirectionEnum.North, 5, 5, 5, 5)]
        [TestCase(DirectionEnum.East, 5, 5, 5, 5)]
        [TestCase(DirectionEnum.West, 0, 0, 0, 0)]
        [TestCase(DirectionEnum.South, 0, 0, 0, 0)]
        [TestCase(DirectionEnum.North, 2, 3, 2, 4)]
        [TestCase(DirectionEnum.East, 2, 3, 3, 3)]
        [TestCase(DirectionEnum.West, 2, 3, 1, 3)]
        [TestCase(DirectionEnum.South, 2, 3, 2, 2)]
        public void WhenRobotMoves_RobotIsAtCorrectPosition(DirectionEnum initalDirection, int x, int y, int newX, int newY)
        {
            var mdMock = new Mock<IMessageDisplayer>();
            var messageDisplayer = mdMock.Object;
            var board = new Board(5, 5);
            var robot = new RobotProject.Robot();
            var game = new RobotGame(board, robot, messageDisplayer);


            game.ProcessCommand($"PLACE {x} {y} {DirectionEnum.North.ToString().ToUpper()}");
            game.ProcessCommand($"MOVE");
            game.ProcessCommand($"REPORT");

            mdMock.Verify(m => m.DisplayMessage($"Output: {newX}, {newY}, { initalDirection.ToString()}"), Times.AtMostOnce());
        }
    }
}
