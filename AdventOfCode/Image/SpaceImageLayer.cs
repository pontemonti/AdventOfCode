using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pontemonti.AdventOfCode.Image
{
    public class SpaceImageLayer
    {
        public SpaceImageLayer(int layerNumber, int[] data, int width, int height)
        {
            if (data.Length != width * height)
            {
                throw new ArgumentOutOfRangeException($"Layer {layerNumber}: Invalid image format; received {data.Length} digits but size is {width}x{height} ({width * height} digits)");
            }

            this.LayerNumber = layerNumber;
            this.Data = data;
            this.Width = width;
            this.Height = height;
        }

        public int[] Data { get; }
        public int LayerNumber { get; }
        public int Width { get; }
        public int Height { get; }

        public int GetNumberOfDigits(int digit) => this.Data.Count(n => n == digit);
    }
}
