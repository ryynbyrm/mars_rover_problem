using System;

namespace MarsRoverProject
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            try
            {
                //Create area for Rover that can move
                Plateau plateau = new Plateau(5, 5);

                //Create rover in coordinates(1,2) and heading direction is North
                Rover rover = new Rover(1, 2, Direction.North, plateau);
                rover.FindPositionInPlateau("LMLMLMLMM");
                Console.WriteLine($"{rover.CoordinateX} {rover.CoordinateY} {rover.HeadingDirection}");


                //Then update rover witn in coordinates(3,3) and heading direction is East
                rover = new Rover(3, 3, Direction.East, plateau);
                rover.FindPositionInPlateau("MMRMMRMRRM");
                Console.WriteLine($"{rover.CoordinateX} {rover.CoordinateY} {rover.HeadingDirection}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
