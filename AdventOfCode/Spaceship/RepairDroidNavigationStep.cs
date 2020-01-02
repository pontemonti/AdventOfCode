using System;
using System.Collections.Generic;
using System.Text;
using Pontemonti.AdventOfCode.Geometry;

namespace Pontemonti.AdventOfCode.Spaceship
{
    public class RepairDroidNavigationStep
    {
        public RepairDroidNavigationStep(Point originPosition, RepairDroidMovementCommand movementCommand, Stack<RepairDroidNavigationStep> shortestPathToOrigin)
        {
            this.OriginPosition = originPosition;
            this.MovementCommand = movementCommand;
            this.DestinationPosition = originPosition.GetNextPosition(movementCommand);
            this.ShortestPathToOrigin = shortestPathToOrigin;
        }

        public Point OriginPosition { get; }
        public Point DestinationPosition { get; }
        public RepairDroidMovementCommand MovementCommand { get; }
        public Stack<RepairDroidNavigationStep> ShortestPathToOrigin { get; }
        public int StepsFromStart => this.ShortestPathToOrigin.Count;
    }
}
