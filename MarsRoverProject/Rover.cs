using System;
using System.Linq;
namespace MarsRoverProject
{
    public class Rover
    {
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }
        public Direction HeadingDirection { get; set; }

        //constructors
        public Rover()
        {
            this.CoordinateX = CoordinateX;
            this.CoordinateY = CoordinateY;
            HeadingDirection = Direction.North;
        }
        public Rover(int x, int y, Direction direction, Plateau plateau)
        {
            if(x < 0 || x > plateau.CoordinateX || y < 0 || y > plateau.CoordinateY)
            {
                throw new Exception("Rover position can not be exceed to Plateau surface area");
            }
            if (!Enum.GetValues(typeof(Direction)).OfType<Direction>().Contains(direction))
            {
                throw new Exception("Direction commands are not right");
            }

            this.CoordinateX = x;
            this.CoordinateY = y;
            HeadingDirection = direction;
        }

        private void RotateLeft()
        {
            if (this.HeadingDirection == Direction.North)
                this.HeadingDirection = Direction.West;
            else if (this.HeadingDirection == Direction.South)
                this.HeadingDirection = Direction.East;
            else if (this.HeadingDirection == Direction.East)
                this.HeadingDirection = Direction.North;
            else if (this.HeadingDirection == Direction.West)
                this.HeadingDirection = Direction.South;
        }

        private void RotateRight()
        {

            if (this.HeadingDirection == Direction.North)
                this.HeadingDirection = Direction.East;
            else if (this.HeadingDirection == Direction.South)
                this.HeadingDirection = Direction.West;
            else if (this.HeadingDirection == Direction.East)
                this.HeadingDirection = Direction.South;
            else if (this.HeadingDirection == Direction.West)
                this.HeadingDirection = Direction.North;
        }

        private void MoveForward()
        {
            if (this.HeadingDirection == Direction.North)
                this.CoordinateY += 1;
            else if (this.HeadingDirection == Direction.South)
                this.CoordinateY -= 1;
            else if (this.HeadingDirection == Direction.East)
                this.CoordinateX += 1;
            else if (this.HeadingDirection == Direction.West)
                this.CoordinateX -= 1;
        }


        public void FindPositionInPlateau(string moves)
        {
            foreach (var move in moves)
            {
                switch (move)
                {
                    case 'M':
                        this.MoveForward();
                        break;
                    case 'L':
                        this.RotateLeft();
                        break;
                    case 'R':
                        this.RotateRight();
                        break;
                    default:
                        throw new Exception("Invalid characted for positioning rover");
                }
            }
        }
    }
}
