﻿using Pontemonti.AdventOfCode.Image;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pontemonti.AdventOfCode.Year2019
{
    /// <summary>
    /// --- Part Two ---
    /// 
    /// Now you're ready to decode the image. The image is rendered by stacking the 
    /// layers and aligning the pixels with the same positions in each layer. The 
    /// digits indicate the color of the corresponding pixel: 0 is black, 1 is 
    /// white, and 2 is transparent.
    /// 
    /// The layers are rendered with the first layer in front and the last layer in 
    /// back. So, if a given position has a transparent pixel in the first and 
    /// second layers, a black pixel in the third layer, and a white pixel in the 
    /// fourth layer, the final image would have a black pixel at that position.
    /// 
    /// For example, given an image 2 pixels wide and 2 pixels tall, the image 
    /// data 0222112222120000 corresponds to the following image layers:
    /// Layer 1: 02
    ///          22
    /// 
    /// Layer 2: 11
    ///          22
    /// 
    /// Layer 3: 22
    ///          12
    /// 
    /// Layer 4: 00
    ///          00
    /// 
    /// Then, the full image can be found by determining the top visible pixel in 
    /// each position:
    /// * The top-left pixel is black because the top layer is 0.
    /// * The top-right pixel is white because the top layer is 2 (transparent), 
    ///   but the second layer is 1.
    /// * The bottom-left pixel is white because the top two layers are 2, but 
    ///   the third layer is 1.
    /// * The bottom-right pixel is black because the only visible pixel in that 
    ///   position is 0 (from layer 4).
    /// 
    /// So, the final image looks like this:
    /// 01
    /// 10
    /// 
    /// What message is produced after decoding your image?
    /// </summary>
    public class Day08Puzzle2 : IPuzzle
    {
        public void Solve()
        {
            Console.WriteLine($"Visible digits:");
            int[] visiblePixels = GetResult();
            WriteImageToConsole(visiblePixels);
        }

        public static int[] GetResult()
        {
            SpaceImageFormat spaceImage = SpaceImageFormat.ParseSpaceImage(Day8Puzzle1.input, Day8Puzzle1.inputImageWidth, Day8Puzzle1.inputImageHeight);
            int[] visiblePixels = spaceImage.GetVisiblePixels();
            return visiblePixels;
        }

        public static void WriteImageToConsole(int[] visiblePixels)
        {
            // For the current input, this writes "AGUEB"
            for (int row = 0; row < Day8Puzzle1.inputImageHeight; row++)
            {
                for (int column = 0; column < Day8Puzzle1.inputImageWidth; column++)
                {
                    int pixel = visiblePixels[row * Day8Puzzle1.inputImageWidth + column];
                    if (pixel == (int)SpaceImageColors.Black)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    else if (pixel == (int)SpaceImageColors.White)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                    }

                    Console.Write(" ");
                }

                Console.WriteLine();
            }
        }
    }
}
