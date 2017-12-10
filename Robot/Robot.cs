using System.Collections.Generic;
namespace RobotProject
{
    public enum DirectionEnum
    {
        North = 0,
        West = 1,
        South = 2,
        East = 3
    }

    public class Robot
    {
        private RobotPosition _robotPosition;

        public Robot()
        {

        }

        public Robot(RobotPosition robotPosition)
        {
            PlaceAt(robotPosition);
        }

        public void Left()
        {
            if (_robotPosition == null) return;
            _robotPosition.Direction = (DirectionEnum)(((int)_robotPosition.Direction + 1) % 4);
        }

        public void PlaceAt(RobotPosition robotPosition)
        {
            if (robotPosition == null) return;
            _robotPosition = robotPosition;
        }

        public void Right()
        {
            if (_robotPosition == null) return;
            var direction = (int)_robotPosition.Direction;
            if (direction == 0) direction = 4;
            _robotPosition.Direction = (DirectionEnum)((direction - 1) % 4);
        }

        public RobotPosition Report()
        {
            return _robotPosition;
        }
    }
}
