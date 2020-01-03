using System;
using System.Linq;
using System.Reflection;

namespace Pontemonti.AdventOfCode
{
    class Program
    {
        private const int defaultYear = 2019;
        private const int defaultDay = 15;
        private const int defaultPuzzle = 2;

        static void Main(string[] args)
        {
            Console.WriteLine("Finding puzzle...");
            string puzzleName = GetPuzzleName();
            Console.WriteLine($"Retrieving puzzle '{puzzleName}'...");
            IPuzzle puzzle = GetPuzzleType(puzzleName);
            Console.WriteLine($"Solving puzzle '{puzzle.GetType().FullName}'...");
            puzzle.Solve();
        }

        private static string GetPuzzleName()
        {
            int year = defaultYear;
            int day = defaultDay;
            int puzzle = defaultPuzzle;
            string puzzleName = $"{year}.Day{day:00}Puzzle{puzzle}";
            return puzzleName;
        }

        private static IPuzzle GetPuzzleType(string puzzleName)
        {
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            Type puzzleType = types.FirstOrDefault(type => type.FullName.EndsWith(puzzleName));
            ConstructorInfo constructorInfo = puzzleType.GetConstructor(Type.EmptyTypes);
            IPuzzle puzzle = (IPuzzle)constructorInfo.Invoke(null);
            return puzzle;
        }
    }
}
