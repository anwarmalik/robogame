namespace RobotProject
{
    public class RobotPosition  {

        public int X { get; set; }
        public int Y { get; set; }
        public DirectionEnum Direction { get; set; }

        public RobotPosition NewPosition(int step = 1)
        {
            var newPosition = new RobotPosition
            {
                X = this.X,
                Y = this.Y,
                Direction = this.Direction,
            };

            if (newPosition.Direction == DirectionEnum.East)
            {
                newPosition.X += step;
            }
            else if (newPosition.Direction == DirectionEnum.West)
            {
                newPosition.X -= step;
            }
            else if (newPosition.Direction == DirectionEnum.North)
            {
                newPosition.Y += step;
            }
            else if (newPosition.Direction == DirectionEnum.South)
            {
                newPosition.Y -= step;
            }

            return newPosition;
        }
    }
}
