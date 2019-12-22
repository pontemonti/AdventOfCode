using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pontemonti.AdventOfCode.Intcode;
using Pontemonti.AdventOfCode.Spaceship;
using Pontemonti.AdventOfCode.Utilities;

namespace Pontemonti.AdventOfCode.Year2019
{
    /// <summary>
    /// --- Part Two ---
    /// 
    /// The game didn't run because you didn't put in any quarters. Unfortunately, 
    /// you did not bring any quarters. Memory address 0 represents the number of 
    /// quarters that have been inserted; set it to 2 to play for free.
    /// 
    /// The arcade cabinet has a joystick that can move left and right. The 
    /// software reads the position of the joystick with input instructions:
    /// * If the joystick is in the neutral position, provide 0.
    /// * If the joystick is tilted to the left, provide -1.
    /// * If the joystick is tilted to the right, provide 1.
    /// 
    /// The arcade cabinet also has a segment display capable of showing a single 
    /// number that represents the player's current score. When three output 
    /// instructions specify X=-1, Y=0, the third output instruction is not a tile; 
    /// the value instead specifies the new score to show in the segment display. 
    /// For example, a sequence of output values like -1,0,12345 would show 12345 
    /// as the player's current score.
    /// 
    /// Beat the game by breaking all the blocks. What is your score after the last 
    /// block is broken?
    /// </summary>
    public class Day13Puzzle2 : IPuzzle
    {

        public void Solve()
        {
            int result = CalculateResult();
            Console.WriteLine($"Score: {result}");
        }

        public static int CalculateResult()
        {
            long[] program = InputHelper.ReadInt64CommaList(Day13Puzzle1.input).ToArray();

            // Memory address 0 represents the number of quarters that have been inserted;
            // set it to 2 to play for free.
            program[0] = 2;
            IntcodeComputer intcodeComputer = new IntcodeComputer("Elf arcade game - free play", program);
            ArcadeCabinet arcadeCabinet = new ArcadeCabinet(intcodeComputer);
            arcadeCabinet.Run();
            int score = arcadeCabinet.Score;
            return score;
        }
    }
}
