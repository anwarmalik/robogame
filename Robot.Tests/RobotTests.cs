using NUnit.Framework;
using System;
using RobotProject;
namespace Robot.Tests
{
    [TestFixture]
    public class RobotTests
    {
        
        [SetUp]
        public void SetUp()
        {
            
        }

        [TestCase(DirectionEnum.North, DirectionEnum.West)]
        [TestCase(DirectionEnum.West, DirectionEnum.South)]
        [TestCase(DirectionEnum.South, DirectionEnum.East)]
        [TestCase(DirectionEnum.East, DirectionEnum.North)]
        public void VerifyDirectionsOnLeft(DirectionEnum iniitialDirection, DirectionEnum expectedDirection)
        {
            var robot = new RobotProject.Robot();

            robot.PlaceAt(new RobotPosition { X = 0, Y = 0, Direction = iniitialDirection });
            robot.Left();

            var position = robot.Report();

            Console.WriteLine($"{position.Direction} - {expectedDirection}");

            Assert.AreEqual(expectedDirection, position.Direction);
        }

        [TestCase(DirectionEnum.West, DirectionEnum.North)]
        [TestCase(DirectionEnum.South, DirectionEnum.West)]
        [TestCase(DirectionEnum.East, DirectionEnum.South)]
        [TestCase(DirectionEnum.North, DirectionEnum.East)]
        public void VerifyDirectionsOnRight(DirectionEnum iniitialDirection, DirectionEnum expectedDirection)
        {
            var robot = new RobotProject.Robot();

            robot.PlaceAt(new RobotPosition { X = 0, Y = 0, Direction = iniitialDirection });
            robot.Right();

            var position = robot.Report();

            Assert.AreEqual(position.Direction, expectedDirection);
        }
    }
}
