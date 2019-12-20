using Pontemonti.AdventOfCode.Spaceship;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pontemonti.AdventOfCode.Year2019
{
    /// <summary>
    /// --- Day 11: Space Police ---
    /// 
    /// On the way to Jupiter, you're pulled over by the Space Police.
    /// 
    /// "Attention, unmarked spacecraft! You are in violation of Space Law! All 
    /// spacecraft must have a clearly visible registration identifier! You have 24 
    /// hours to comply or be sent to Space Jail!"
    /// 
    /// Not wanting to be sent to Space Jail, you radio back to the Elves on Earth 
    /// for help. Although it takes almost three hours for their reply signal to 
    /// reach you, they send instructions for how to power up the emergency hull 
    /// painting robot and even provide a small Intcode program (your puzzle input) 
    /// that will cause it to paint your ship appropriately.
    /// 
    /// There's just one problem: you don't have an emergency hull painting robot.
    /// 
    /// You'll need to build a new emergency hull painting robot. The robot needs 
    /// to be able to move around on the grid of square panels on the side of your 
    /// ship, detect the color of its current panel, and paint its current panel 
    /// black or white. (All of the panels are currently black.)
    /// 
    /// The Intcode program will serve as the brain of the robot. The program uses 
    /// input instructions to access the robot's camera: provide 0 if the robot is 
    /// over a black panel or 1 if the robot is over a white panel. Then, the 
    /// program will output two values:
    /// * First, it will output a value indicating the color to paint the panel 
    ///   the robot is over: 0 means to paint the panel black, and 1 means to 
    ///   paint the panel white.
    /// * Second, it will output a value indicating the direction the robot 
    ///   should turn: 0 means it should turn left 90 degrees, and 1 means it 
    ///   should turn right 90 degrees.
    /// 
    /// After the robot turns, it should always move forward exactly one panel. The 
    /// robot starts facing up.
    /// 
    /// The robot will continue running for a while like this and halt when it is 
    /// finished drawing. Do not restart the Intcode computer inside the robot 
    /// during this process.
    /// 
    /// For example, suppose the robot is about to start running. Drawing black 
    /// panels as ., white panels as #, and the robot pointing the direction it is 
    /// facing (< ^ > v), the initial state and region near the robot looks like 
    /// this:
    /// .....
    /// .....
    /// ..^..
    /// .....
    /// .....
    /// 
    /// The panel under the robot (not visible here because a ^ is shown instead) 
    /// is also black, and so any input instructions at this point should be 
    /// provided 0. Suppose the robot eventually outputs 1 (paint white) and then 
    /// 0 (turn left). After taking these actions and moving forward one panel, the 
    /// region now looks like this:
    /// .....
    /// .....
    /// .<#..
    /// .....
    /// .....
    /// 
    /// Input instructions should still be provided 0. Next, the robot might output 
    /// 0 (paint black) and then 0 (turn left):
    /// .....
    /// .....
    /// ..#..
    /// .v...
    /// .....
    /// 
    /// After more outputs (1,0, 1,0):
    /// .....
    /// .....
    /// ..^..
    /// .##..
    /// .....
    /// 
    /// The robot is now back where it started, but because it is now on a white 
    /// panel, input instructions should be provided 1. After several more outputs 
    /// (0,1, 1,0, 1,0), the area looks like this:
    /// .....
    /// ..<#.
    /// ...#.
    /// .##..
    /// .....
    /// 
    /// Before you deploy the robot, you should probably have an estimate of the 
    /// area it will cover: specifically, you need to know the number of panels it 
    /// paints at least once, regardless of color. In the example above, the robot 
    /// painted 6 panels at least once. (It painted its starting panel twice, but 
    /// that panel is still only counted once; it also never painted the panel it 
    /// ended on.)
    /// 
    /// Build a new emergency hull painting robot and run the Intcode program on 
    /// it. How many panels does it paint at least once?
    /// </summary>
    public class Day11Puzzle1 : IPuzzle
    {
        public const string programString = "3,8,1005,8,345,1106,0,11,0,0,0,104,1,104,0,3,8,102,-1,8,10,1001,10,1,10,4,10,108,1,8,10,4,10,102,1,8,28,1006,0,94,2,106,5,10,1,1109,12,10,3,8,1002,8,-1,10,1001,10,1,10,4,10,1008,8,1,10,4,10,101,0,8,62,1,103,6,10,1,108,12,10,3,8,102,-1,8,10,1001,10,1,10,4,10,1008,8,0,10,4,10,102,1,8,92,2,104,18,10,2,1109,2,10,2,1007,5,10,1,7,4,10,3,8,102,-1,8,10,1001,10,1,10,4,10,108,0,8,10,4,10,102,1,8,129,2,1004,15,10,2,1103,15,10,2,1009,6,10,3,8,102,-1,8,10,1001,10,1,10,4,10,1008,8,1,10,4,10,101,0,8,164,2,1109,14,10,1,1107,18,10,1,1109,13,10,1,1107,11,10,3,8,102,-1,8,10,101,1,10,10,4,10,108,0,8,10,4,10,1001,8,0,201,2,104,20,10,1,107,8,10,1,1007,5,10,3,8,102,-1,8,10,101,1,10,10,4,10,1008,8,1,10,4,10,101,0,8,236,3,8,1002,8,-1,10,1001,10,1,10,4,10,108,0,8,10,4,10,1001,8,0,257,3,8,102,-1,8,10,101,1,10,10,4,10,108,1,8,10,4,10,102,1,8,279,1,107,0,10,1,107,16,10,1006,0,24,1,101,3,10,3,8,102,-1,8,10,101,1,10,10,4,10,108,0,8,10,4,10,1002,8,1,316,2,1108,15,10,2,4,11,10,101,1,9,9,1007,9,934,10,1005,10,15,99,109,667,104,0,104,1,21101,0,936995730328,1,21102,362,1,0,1105,1,466,21102,1,838210728716,1,21101,373,0,0,1105,1,466,3,10,104,0,104,1,3,10,104,0,104,0,3,10,104,0,104,1,3,10,104,0,104,1,3,10,104,0,104,0,3,10,104,0,104,1,21102,1,235350789351,1,21101,0,420,0,1105,1,466,21102,29195603035,1,1,21102,1,431,0,1105,1,466,3,10,104,0,104,0,3,10,104,0,104,0,21101,0,825016079204,1,21101,0,454,0,1105,1,466,21101,837896786700,0,1,21102,1,465,0,1106,0,466,99,109,2,21201,-1,0,1,21101,0,40,2,21102,1,497,3,21101,0,487,0,1105,1,530,109,-2,2106,0,0,0,1,0,0,1,109,2,3,10,204,-1,1001,492,493,508,4,0,1001,492,1,492,108,4,492,10,1006,10,524,1101,0,0,492,109,-2,2105,1,0,0,109,4,2102,1,-1,529,1207,-3,0,10,1006,10,547,21102,1,0,-3,21201,-3,0,1,22102,1,-2,2,21101,1,0,3,21102,1,566,0,1105,1,571,109,-4,2106,0,0,109,5,1207,-3,1,10,1006,10,594,2207,-4,-2,10,1006,10,594,21201,-4,0,-4,1106,0,662,21201,-4,0,1,21201,-3,-1,2,21202,-2,2,3,21101,613,0,0,1105,1,571,22101,0,1,-4,21101,0,1,-1,2207,-4,-2,10,1006,10,632,21101,0,0,-1,22202,-2,-1,-2,2107,0,-3,10,1006,10,654,22101,0,-1,1,21102,654,1,0,105,1,529,21202,-2,-1,-2,22201,-4,-2,-4,109,-5,2105,1,0";

        public void Solve()
        {
            int result = CalculateResult();
            Console.WriteLine($"Panels painted at least once: {result}");
        }

        public static int CalculateResult()
        {
            HullPaintingRobot robot = HullPaintingRobot.CreateRobot(programString);
            robot.RunProgram();
            int result = robot.NumberOfPaintedPanels;
            return result;
        }
    }
}
