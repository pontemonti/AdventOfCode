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
        private readonly int maxOutputInstruction;
        private int currentXPosition;
        private int currentYPosition;
        private Dictionary<Point, ArcadeCabinetScreenTileType> tiles;

        public ArcadeCabinet(IntcodeComputer intcodeComputer)
        {
            this.IntcodeComputer = intcodeComputer;
            this.IntcodeComputer.OutputSent += this.IntcodeComputerOutputSent;
            this.nextOutputInstruction = ArcadeCabinetScreenOutputInstruction.XPosition;
            this.maxOutputInstruction = Enum.GetValues(typeof(ArcadeCabinetScreenOutputInstruction)).Cast<int>().Max();
            this.tiles = new Dictionary<Point, ArcadeCabinetScreenTileType>();
        }

        public IntcodeComputer IntcodeComputer { get; }

        public void Run()
        {
            this.IntcodeComputer.Run();
        }

        public int FindNumberOfTiles(Func<ArcadeCabinetScreenTileType, bool> predicate)
            => this.tiles.Values.Count(predicate);

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
                    this.nextOutputInstruction = ArcadeCabinetScreenOutputInstruction.TileId;
                    return;
                case ArcadeCabinetScreenOutputInstruction.TileId:
                    this.DrawTile(e);
                    this.nextOutputInstruction = ArcadeCabinetScreenOutputInstruction.XPosition;
                    return;
            }

            throw new InvalidOperationException();
        }

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
    }
}
