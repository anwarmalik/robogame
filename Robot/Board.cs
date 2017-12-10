using System;
using System.Collections.Generic;
using System.Text;

namespace RobotProject
{
    public class Board
    {
        private int _maxXUnits;
        private int _maxYUnits;

        public Board(int maxXUnits, int maxYUnits)
        {
            _maxXUnits = maxXUnits;
            _maxYUnits = maxYUnits;
        }

        public bool ValdatePosition(RobotPosition robotPosition)
        {
            return robotPosition.X > _maxXUnits || robotPosition.X < 0
                || robotPosition.Y > _maxYUnits || robotPosition.Y < 0;
        }
    }
}
