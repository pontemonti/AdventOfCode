using System;
using System.Collections.Generic;
using System.Text;
using Pontemonti.AdventOfCode.Geometry;

namespace Pontemonti.AdventOfCode.Spaceship
{
    public static class RepairDroidMovementCommandExtensions
    {
        public static Point GetNextPosition(this Point originPoint, RepairDroidMovementCommand movementCommand)
        {
            switch (movementCommand)
            {
                case RepairDroidMovementCommand.East:
                    return new Point(originPoint.X + 1, originPoint.Y);
                case RepairDroidMovementCommand.North:
                    return new Point(originPoint.X, originPoint.Y + 1);
                case RepairDroidMovementCommand.South:
                    return new Point(originPoint.X, originPoint.Y - 1);
                case RepairDroidMovementCommand.West:
                    return new Point(originPoint.X - 1, originPoint.Y);
            }

            throw new InvalidOperationException($"Don't know how to handle {movementCommand}.");
        }

        public static RepairDroidMovementCommand Reverse(this RepairDroidMovementCommand command)
        {
            switch (command)
            {
                case RepairDroidMovementCommand.East:
                    return RepairDroidMovementCommand.West;
                case RepairDroidMovementCommand.North:
                    return RepairDroidMovementCommand.South;
                case RepairDroidMovementCommand.South:
                    return RepairDroidMovementCommand.North;
                case RepairDroidMovementCommand.West:
                    return RepairDroidMovementCommand.East;
            }

            throw new InvalidOperationException($"Can't find command {command}.");
        }
    }
}
