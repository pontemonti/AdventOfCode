using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pontemonti.AdventOfCode.Image
{
    public class SpaceImageFormat
    {
        private readonly string imageData;

        private SpaceImageFormat(string imageData, int width, int height)
        {
            this.imageData = imageData;
            this.Width = width;
            this.Height = height;
            this.Layers = this.GetLayers();
        }

        public IEnumerable<SpaceImageLayer> Layers { get; }
        public int Width { get; }
        public int Height { get; }

        public static SpaceImageFormat ParseSpaceImage(string imageData, int width, int height)
        {
            SpaceImageFormat spaceImage = new SpaceImageFormat(imageData, width, height);
            return spaceImage;
        }

        public int ElfChecksum()
        {
            // To make sure the image wasn't corrupted during transmission, the Elves would like 
            // you to find the layer that contains the fewest 0 digits. On that layer, what is 
            // the number of 1 digits multiplied by the number of 2 digits?
            int fewestZeroes = int.MaxValue;
            int numberOfZeroes;
            SpaceImageLayer layerWithFewestZeroes = null;
            foreach (SpaceImageLayer layer in this.Layers)
            {
                numberOfZeroes = layer.GetNumberOfDigits(0);
                if (numberOfZeroes < fewestZeroes)
                {
                    fewestZeroes = numberOfZeroes;
                    layerWithFewestZeroes = layer;
                    Console.WriteLine($"Layer with fewest zeroes: {layerWithFewestZeroes.LayerNumber}; number of zeroes: {numberOfZeroes}");
                }
            }

            //SpaceImageLayer layerWithFewestZeroes = this.Layers.OrderBy(layer => layer.GetNumberOfDigits(0)).First();
            numberOfZeroes = layerWithFewestZeroes.GetNumberOfDigits(0);
            int numberOfOnes = layerWithFewestZeroes.GetNumberOfDigits(1);
            int numberOfTwoes = layerWithFewestZeroes.GetNumberOfDigits(2);
            Console.WriteLine($"Layer {layerWithFewestZeroes.LayerNumber}: number of 0 digits: {numberOfZeroes}; number of 1 digits: {numberOfOnes}; number of 2 digits: {numberOfTwoes}");
            int checksum = numberOfOnes * numberOfTwoes;
            return checksum;
        }

        public int[] GetVisiblePixels()
        {
            int numberOfPixels = this.Width * this.Height;
            int[] visiblePixels = Enumerable.Repeat((int)SpaceImageColors.Transparent, numberOfPixels).ToArray();
            foreach (SpaceImageLayer layer in this.Layers)
            {
                int[] layerData = layer.Data;
                for (int i = 0; i < layerData.Length; i++)
                {
                    if (visiblePixels[i] == (int)SpaceImageColors.Transparent)
                    {
                        visiblePixels[i] = layerData[i];
                    }
                }
            }

            return visiblePixels;
        }

        private IEnumerable<SpaceImageLayer> GetLayers()
        {
            int digitsPerLayer = this.Width * this.Height;
            int numberOfLayers = this.imageData.Length / digitsPerLayer;
            List<SpaceImageLayer> layers = new List<SpaceImageLayer>(numberOfLayers);
            for (int i = 0; i < numberOfLayers; i++)
            {
                string layerData = this.imageData.Substring(i * digitsPerLayer, digitsPerLayer);
                List<int> layerDigits = new List<int>();
                for (int j = 0; j < layerData.Length; j++)
                {
                    layerDigits.Add(int.Parse(layerData.Substring(j, 1)));
                }

                SpaceImageLayer layer = new SpaceImageLayer(i+1, layerDigits.ToArray(), this.Width, this.Height);
                layers.Add(layer);
            }

            return layers;
        }
    }
}
