using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.DayCode
{
    internal class Day4 : IDayCode
    {
        public void RunDay(string input)
        {
            var pairs = input.Split('\n');
            int fullyContainedSetsCount = 0;
            int overlappingPairsCount = 0;
            foreach (var pair in pairs) { 
                var assignmentRanges = pair.Split(',');
                var firstElf = assignmentRanges[0].Split('-').Select(x => int.Parse(x)).ToList();
                var secondElf = assignmentRanges[1].Split('-').Select(x => int.Parse(x)).ToList();
                if (firstElf[0] >= secondElf[0] && firstElf[1] <= secondElf[1]) fullyContainedSetsCount++;
                else if (secondElf[0] >= firstElf[0] && secondElf[1] <= firstElf[1]) fullyContainedSetsCount++;

                if (firstElf[0] >= secondElf[0] && firstElf[0] <= secondElf[1]) overlappingPairsCount++;
                else if (secondElf[0] >= firstElf[0] && secondElf[0] <= firstElf[1]) overlappingPairsCount++;
            }
            Console.WriteLine($"Count of pairs with one set being fully contained: {fullyContainedSetsCount}");
            Console.WriteLine($"Count of pairs with overlap: {overlappingPairsCount}");
            Console.ReadLine();
        }
    }
}
