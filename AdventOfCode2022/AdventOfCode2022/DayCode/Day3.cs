using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.DayCode
{
    internal class Day3 : IDayCode
    {
        public void RunDay(string input)
        {
            var ruckSacks = input.Split('\n');
            var totalWrongPackLetterPriority = 0;
            foreach (var ruckSack in ruckSacks)
            {
                var letter = ruckSack.First(c => ruckSack.Take(ruckSack.Length / 2).Contains(c) && ruckSack.TakeLast(ruckSack.Length / 2).Contains(c));
                var letterInt = letter & 0b11111;
                totalWrongPackLetterPriority += char.IsUpper(letter) ? letterInt + 26 : letterInt;
            }

            var totalGroupBadgePriority = 0;
            for (var i = 0; i < ruckSacks.Length; i+=3)
            {
                var group = ruckSacks.Skip(i).Take(3).ToArray();
                var commonLetter = group[0].First(c => group[1].Contains(c) && group[2].Contains(c));
                var commonLetterInt = commonLetter & 0b11111;
                totalGroupBadgePriority += char.IsUpper(commonLetter) ? commonLetterInt + 26 : commonLetterInt;
            }
            Console.WriteLine($"Sum of priorities of wrongly packed items: {totalWrongPackLetterPriority}");
            Console.WriteLine($"Sum of priorities of group badges: {totalGroupBadgePriority}");
            Console.ReadKey();
        }
    }
}
