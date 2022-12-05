using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.DayCode
{
    internal class Day5 : IDayCode
    {
        public void RunDay(string input)
        {
            var stacksSectionLines = input.Split("\n\n")[0].Split('\n');
            var stackCount = int.Parse(stacksSectionLines.Last().Trim().Split(' ').Last());
            Stack<char>[] stacks = Enumerable.Range(0, stackCount).Select(x => new Stack<char>()).ToArray();
            for (int i = stacksSectionLines.Length-2; i > -1; i--)
            {
                for (int j = 0; j < stackCount; j++)
                {
                    var crate = new string(stacksSectionLines[i].Skip(j*4).Take(3).ToArray());
                    if (!string.IsNullOrWhiteSpace(crate)) stacks[j].Push(crate[1]);
                }
            }

            var movements = input.Split("\n\n")[1].Split('\n');
            
            var oldStacks = stacks.Select(x => new Stack<char>(x)).ToArray();
            foreach (var movement in movements)
            {
                var movementInstructions = movement.Split(' ').Where(x => int.TryParse(x, out int num)).Select(x => int.Parse(x)).ToArray();
                for (int i = 0; i < movementInstructions[0]; i++)
                {
                    oldStacks[movementInstructions[2] - 1].Push(oldStacks[movementInstructions[1] - 1].Pop());
                }
            }

            Console.WriteLine($"The top crate from each stack if it were the Cratemover 9000 is: {new string(oldStacks.Select(x => x.Peek()).ToArray())}");

            foreach (var movement in movements)
            {
                var movementInstructions = movement.Split(' ').Where(x => int.TryParse(x, out int num)).Select(x => int.Parse(x)).ToArray();
                var craneHolder = new Stack<char>();
                for (int i = 0; i < movementInstructions[0]; i++)
                {
                    craneHolder.Push(stacks[movementInstructions[1] - 1].Pop());
                }
                var crateCount = craneHolder.Count();
                for (int i = 0; i < crateCount; i++)
                {
                    stacks[movementInstructions[2] - 1].Push(craneHolder.Pop());
                }
            }
            Console.WriteLine($"The top crate from each stack because it is the Cratemover 9001 is: {new string(stacks.Select(x => x.Peek()).ToArray())}");
            Console.ReadLine();
        }
    }
}
