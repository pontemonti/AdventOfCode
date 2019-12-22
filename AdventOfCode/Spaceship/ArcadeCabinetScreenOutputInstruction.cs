using System;
using System.Collections.Generic;
using System.Text;

namespace Pontemonti.AdventOfCode.Spaceship
{
    /// <summary>
    /// The software draws tiles to the screen with output instructions:
    /// every three output instructions specify the
    /// x position (distance from the left),
    /// y position (distance from the top),
    /// and tile id.
    /// </summary>
    public enum ArcadeCabinetScreenOutputInstruction
    {
        XPosition = 0,
        YPosition = 1,
        TileIdOrScore = 2
    }
}
