using Pontemonti.AdventOfCode.Geometry;
using Pontemonti.AdventOfCode.Image;
using Pontemonti.AdventOfCode.Spaceship;
using Pontemonti.AdventOfCode.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pontemonti.AdventOfCode.Year2019
{
    /// <summary>
    /// --- Part Two ---
    /// 
    /// You're not sure what it's trying to paint, but it's definitely not a 
    /// registration identifier. The Space Police are getting impatient.
    /// 
    /// Checking your external ship cameras again, you notice a white panel marked 
    /// "emergency hull painting robot starting panel". The rest of the panels are 
    /// still black, but it looks like the robot was expecting to start on a white 
    /// panel, not a black one.
    /// 
    /// Based on the Space Law Space Brochure that the Space Police attached to one 
    /// of your windows, a valid registration identifier is always eight capital 
    /// letters. After starting the robot on a single white panel instead, what 
    /// registration identifier does it paint on your hull?
    /// </summary>
    public class Day11Puzzle2 : IPuzzle
    {
        public void Solve()
        {
            HullPaintingRobot robot = CalculateResult();
            Dictionary<Point, SpaceImageColors> paintedPositions = robot.PaintedPanels;
            System.Drawing.Rectangle rectangle = GeometryHelper.CalculateBounds(paintedPositions.Keys);
            // Prints PGUEHCJH
            for (int y = 0; y <= rectangle.Height; y++)
            {
                for (int x = 0; x <= rectangle.Width; x++)
                {
                    Point p = new Point(rectangle.X + x, rectangle.Y - y);
                    SpaceImageColors color = SpaceImageColors.Black;
                    if (paintedPositions.ContainsKey(p))
                    {
                        color = paintedPositions[p];
                    }

                    if (color == SpaceImageColors.Black)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    else if (color == SpaceImageColors.White)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                    }

                    Console.Write(" ");
                }

                Console.WriteLine();
            }
        }

        public static HullPaintingRobot CalculateResult()
        {
            HullPaintingRobot robot = HullPaintingRobot.CreateRobot(Day11Puzzle1.programString, SpaceImageColors.White);
            robot.RunProgram();
            return robot;
        }
    }
}
