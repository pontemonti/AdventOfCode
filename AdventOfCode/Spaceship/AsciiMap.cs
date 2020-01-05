using System.Collections.Generic;
using System.Linq;
using Pontemonti.AdventOfCode.Geometry;

namespace Pontemonti.AdventOfCode.Spaceship
{
    public class AsciiMap
    {
        private HashSet<Point> scaffoldPositions;
        private int maxX;
        private int maxY;

        public AsciiMap(IEnumerable<Point> scaffoldPositions)
        {
            this.scaffoldPositions = new HashSet<Point>(scaffoldPositions);
            this.maxX = this.scaffoldPositions.Max(point => point.X);
            this.maxY = this.scaffoldPositions.Max(point => point.Y);
        }

        public int CalculateSumOfAlignmentParameters()
            => this.FindIntersections().ToArray().Sum(point => point.X * point.Y);

        public IEnumerable<Point> FindIntersections()
        {
            RepairDroidMovementCommand[] movementCommands = new[]
            {
                RepairDroidMovementCommand.North,
                RepairDroidMovementCommand.East,
                RepairDroidMovementCommand.South,
                RepairDroidMovementCommand.West
            };

            for (int x = 0; x <= maxX; x++)
            {
                for (int y = 0; y <= maxY; y++)
                {
                    Point point = new Point(x, y);
                    if (this.scaffoldPositions.Contains(point))
                    {
                        bool isIntersection = true;
                        foreach (RepairDroidMovementCommand movementCommand in movementCommands)
                        {
                            Point otherPoint = point.GetNextPosition(movementCommand);
                            if (!this.scaffoldPositions.Contains(otherPoint))
                            {
                                isIntersection = false;
                                break;
                            }
                        }

                        if (isIntersection)
                        {
                            yield return point;
                        }
                    }
                }
            }
        }
    }
}