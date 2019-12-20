using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pontemonti.AdventOfCode.Geometry
{
    public struct WirePath
    {
        public const char UpDirectionCharacter = 'U';
        public const char DownDirectionCharacter = 'D';
        public const char LeftDirectionCharacter = 'L';
        public const char RightDirectionCharacter = 'R';

        public WirePath(Direction wireDirection, int distance)
        {
            this.WireDirection = wireDirection;
            this.Distance = distance;
        }

        public readonly Direction WireDirection { get; }
        public readonly int Distance { get; }

        public static WirePath Parse(string wirePathString)
        {
            wirePathString = wirePathString.Trim();
            char directionCharacter = wirePathString.First();
            Direction wireDirection = ParseDirectionCharacter(directionCharacter);

            string distanceString = wirePathString.Substring(1);
            int distance = int.Parse(distanceString);

            WirePath wirePath = new WirePath(wireDirection, distance);
            return wirePath;
        }

        public static IEnumerable<Point> GetPoints(IEnumerable<WirePath> wirePaths)
        {
            Point currentPoint = new Point(0, 0);
            foreach (WirePath wirePath in wirePaths)
            {
                for (int i = 0; i < wirePath.Distance; i++)
                {
                    currentPoint = currentPoint.GetNewPointOneStepInDirection(wirePath.WireDirection);
                    yield return currentPoint;
                }
            }
        }

        public static Direction ParseDirectionCharacter(char directionCharacter)
        {
            switch (directionCharacter)
            {
                case UpDirectionCharacter:
                    return Direction.Up;
                case DownDirectionCharacter:
                    return Direction.Down;
                case LeftDirectionCharacter:
                    return Direction.Left;
                case RightDirectionCharacter:
                    return Direction.Right;
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
