using Pontemonti.AdventOfCode.Geometry;
using Pontemonti.AdventOfCode.Intcode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pontemonti.AdventOfCode.Spaceship
{
    public class ArcadeCabinet
    {
        private ArcadeCabinetScreenOutputInstruction nextOutputInstruction;
        private int currentXPosition;
        private int currentYPosition;
        private Dictionary<Point, ArcadeCabinetScreenTileType> tiles;

        public ArcadeCabinet(IntcodeComputer intcodeComputer)
        {
            this.IntcodeComputer = intcodeComputer;
            this.IntcodeComputer.WaitingForInput += this.IntcodeComputerWaitingForInput;
            this.IntcodeComputer.OutputSent += this.IntcodeComputerOutputSent;
            this.nextOutputInstruction = ArcadeCabinetScreenOutputInstruction.XPosition;
            this.tiles = new Dictionary<Point, ArcadeCabinetScreenTileType>();
        }

        public IntcodeComputer IntcodeComputer { get; }
        public int Score { get; private set; }

        public void Run()
        {
            this.IntcodeComputer.Run();
        }

        public int FindNumberOfTiles(Func<ArcadeCabinetScreenTileType, bool> predicate)
            => this.tiles.Values.Count(predicate);

        private void DrawTile(long tileId)
        {
            Point point = new Point(this.currentXPosition, this.currentYPosition);
            ArcadeCabinetScreenTileType tile = (ArcadeCabinetScreenTileType)tileId;
            if (this.tiles.ContainsKey(point))
            {
                this.tiles[point] = tile;
            }
            else
            {
                this.tiles.Add(point, tile);
            }
        }
        private void IntcodeComputerOutputSent(object? sender, long e)
        {
            switch (this.nextOutputInstruction)
            {
                case ArcadeCabinetScreenOutputInstruction.XPosition:
                    this.currentXPosition = (int)e;
                    this.nextOutputInstruction = ArcadeCabinetScreenOutputInstruction.YPosition;
                    return;
                case ArcadeCabinetScreenOutputInstruction.YPosition:
                    this.currentYPosition = (int)e;
                    this.nextOutputInstruction = ArcadeCabinetScreenOutputInstruction.TileIdOrScore;
                    return;
                case ArcadeCabinetScreenOutputInstruction.TileIdOrScore:
                    if (this.currentXPosition == -1 && this.currentYPosition == 0)
                    {
                        this.Score = (int)e;
                    }
                    else
                    {
                        this.DrawTile(e);
                    }

                    this.nextOutputInstruction = ArcadeCabinetScreenOutputInstruction.XPosition;
                    return;
            }

            throw new InvalidOperationException();
        }

        private void IntcodeComputerWaitingForInput(object? sender, EventArgs e)
            => this.ProvideInput();

        private void ProvideInput()
        {
            // Assume there is one or zero paddles (zero when we're drawing initial state)
            Point? paddlePosition = this.FindPosition(tileType => tileType == ArcadeCabinetScreenTileType.HorizontalPaddle);
            if (paddlePosition == null)
            {
                return;
            }

            // Assume there is one or zero balls (zero when we're drawing initial state)
            Point? ballPosition = this.FindPosition(tileType => tileType == ArcadeCabinetScreenTileType.Ball);
            if (ballPosition == null)
            {
                return;
            }

            int input = 0;
            if (paddlePosition.Value.X > ballPosition.Value.X)
            {
                // -1 = move left
                input = -1;
            }
            else if (paddlePosition.Value.X < ballPosition.Value.X)
            {
                // 1 = move right
                input = 1;
            }

            this.IntcodeComputer.ProvideInput(input);
        }

        private Point? FindPosition(Func<ArcadeCabinetScreenTileType, bool> predicate)
        {
            if (!this.tiles.Any(kvp => predicate(kvp.Value)))
            {
                return null;
            }

            Point firstPosition = this.tiles.First(kvp => predicate(kvp.Value)).Key;
            return firstPosition;
        }
    }
}
