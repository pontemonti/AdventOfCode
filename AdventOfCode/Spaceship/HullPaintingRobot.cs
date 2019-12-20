using Pontemonti.AdventOfCode.Geometry;
using Pontemonti.AdventOfCode.Image;
using Pontemonti.AdventOfCode.Intcode;
using Pontemonti.AdventOfCode.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pontemonti.AdventOfCode.Spaceship
{
    public class HullPaintingRobot
    {
        private readonly IntcodeComputer intcodeComputer;
        private readonly Dictionary<Point, SpaceImageColors> paintedPositions;
        private Direction currentDirection;
        private Point currentPosition;
        private HullPaintingRobotInstruction nextOutputInstruction;

        private HullPaintingRobot(IntcodeComputer intcodeComputer)
        {
            this.intcodeComputer = intcodeComputer;
            this.intcodeComputer.OutputSent += this.IntcodeComputerOutputSent;
            this.paintedPositions = new Dictionary<Point, SpaceImageColors>();
            this.currentDirection = Direction.Up;
            this.currentPosition = new Point(0, 0);
        }

        public int NumberOfPaintedPanels => this.paintedPositions.Keys.Count;

        public static HullPaintingRobot CreateRobot(string programString)
        {
            long[] program = InputHelper.ReadInt64CommaList(programString).ToArray();
            IntcodeComputer intcodeComputer = new IntcodeComputer("HullPaintingRobot", program);
            HullPaintingRobot robot = new HullPaintingRobot(intcodeComputer);
            return robot;
        }

        public void RunProgram()
        {
            // We need to start by sending the initial state as input to the program
            this.SendInputToProgram();
            this.intcodeComputer.Run();
        }

        private SpaceImageColors GetCurrentColor()
        {
            if (this.paintedPositions.ContainsKey(this.currentPosition))
            {
                return this.paintedPositions[this.currentPosition];
            }

            return SpaceImageColors.Black;
        }

        private void IntcodeComputerOutputSent(object? sender, long e)
        {
            switch (this.nextOutputInstruction)
            {
                case HullPaintingRobotInstruction.Color:
                    this.PaintCurrentPanel((SpaceImageColors)e);
                    this.nextOutputInstruction = HullPaintingRobotInstruction.TurnDirection;
                    return;
                case HullPaintingRobotInstruction.TurnDirection:
                    this.Turn((HullPaintingRobotTurnDirections)e);
                    this.nextOutputInstruction = HullPaintingRobotInstruction.Color;
                    this.SendInputToProgram();
                    return;
            }

            throw new InvalidOperationException($"Can't handle value {this.nextOutputInstruction}.");
        }

        private void SendInputToProgram()
        {
            SpaceImageColors color = this.GetCurrentColor();
            this.intcodeComputer.ProvideInput((long)color);
        }

        private void Turn(HullPaintingRobotTurnDirections turnDirection)
        {
            if (this.currentDirection == Direction.Up && turnDirection == HullPaintingRobotTurnDirections.TurnLeft90Degrees
             || this.currentDirection == Direction.Down && turnDirection == HullPaintingRobotTurnDirections.TurnRight90Degrees)
            {
                this.currentDirection = Direction.Left;
                this.currentPosition = new Point(this.currentPosition.X - 1, this.currentPosition.Y);
            }
            else if (this.currentDirection == Direction.Up && turnDirection == HullPaintingRobotTurnDirections.TurnRight90Degrees
                  || this.currentDirection == Direction.Down && turnDirection == HullPaintingRobotTurnDirections.TurnLeft90Degrees)
            {
                this.currentDirection = Direction.Right;
                this.currentPosition = new Point(this.currentPosition.X + 1, this.currentPosition.Y);
            }
            else if (this.currentDirection == Direction.Left && turnDirection == HullPaintingRobotTurnDirections.TurnRight90Degrees
                  || this.currentDirection == Direction.Right && turnDirection == HullPaintingRobotTurnDirections.TurnLeft90Degrees)
            {
                this.currentDirection = Direction.Up;
                this.currentPosition = new Point(this.currentPosition.X, this.currentPosition.Y + 1);
            }
            else if (this.currentDirection == Direction.Left && turnDirection == HullPaintingRobotTurnDirections.TurnLeft90Degrees
                  || this.currentDirection == Direction.Right && turnDirection == HullPaintingRobotTurnDirections.TurnRight90Degrees)
            {
                this.currentDirection = Direction.Down;
                this.currentPosition = new Point(this.currentPosition.X, this.currentPosition.Y - 1);
            }
        }

        private void PaintCurrentPanel(SpaceImageColors color)
        {
            if (this.paintedPositions.ContainsKey(this.currentPosition))
            {
                this.paintedPositions[this.currentPosition] = color;
            }
            else
            {
                this.paintedPositions.Add(this.currentPosition, color);
            }
        }
    }
}
