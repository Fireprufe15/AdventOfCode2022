using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.DayCode
{
    class Day1: IDayCode
    {
        public void RunDay()
        {
            string text = File.ReadAllText(Environment.CurrentDirectory + "\\Inputs\\day1.in");
            string[] elves = text.Split("\n\n");

            // Get elves total calories
            List<int> elveTotals = elves.Select(elve => elve.Split('\n').Select(line => int.Parse(line)).Sum()).ToList();

            // Get total of top 3
            var totalOfTopThree = elveTotals.OrderByDescending(elve => elve).Take(3).Sum();

            // Output answers
            Console.WriteLine("Max Elf Calories "+elveTotals.Max());
            Console.WriteLine("Top 3 Elf total Calories " + totalOfTopThree);
            Console.ReadKey();
        }
    }
}
