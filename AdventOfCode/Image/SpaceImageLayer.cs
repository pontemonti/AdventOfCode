using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pontemonti.AdventOfCode.Image
{
    public class SpaceImageLayer
    {
        private readonly int[] digits;

        public SpaceImageLayer(int layerNumber, int[] digits, int width, int height)
        {
            if (digits.Length != width * height)
            {
                throw new ArgumentOutOfRangeException($"Layer {layerNumber}: Invalid image format; received {digits.Length} digits but size is {width}x{height} ({width * height} digits)");
            }

            this.LayerNumber = layerNumber;
            this.digits = digits;
            this.Width = width;
            this.Height = height;
        }

        public int LayerNumber { get; }
        public int Width { get; }
        public int Height { get; }

        public int GetNumberOfDigits(int digit) => this.digits.Count(n => n == digit);
    }
}
