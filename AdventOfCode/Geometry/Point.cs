using System;
using System.Collections.Generic;
using System.Text;

namespace Pontemonti.AdventOfCode.Geometry
{
    public struct Point
    {
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public readonly int X { get; }
        public readonly int Y { get; }

        public Point GetNewPointOneStepInDirection(WireDirection wireDirection)
        {
            int x = this.X;
            int y = this.Y;
            switch(wireDirection)
            {
                case WireDirection.Up:
                    y++;
                    break;
                case WireDirection.Down:
                    y--;
                    break;
                case WireDirection.Left:
                    x--;
                    break;
                case WireDirection.Right:
                    x++;
                    break;
                default:
                    throw new InvalidOperationException();
            }

            return new Point(x, y);
        }

        public override bool Equals(object obj)
        {
            if (obj is Point otherPoint)
            {
                return this.X == otherPoint.X && this.Y == otherPoint.Y;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.X ^ this.Y;
        }
    }
}
