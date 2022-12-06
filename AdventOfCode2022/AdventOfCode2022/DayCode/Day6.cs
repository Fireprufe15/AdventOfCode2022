using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.DayCode
{
    internal class Day6 : IDayCode
    {
        public void RunDay(string input)
        {       
            Console.WriteLine($"Length till first packet marker: {FindMarkerIndex(input, 4)}");
            Console.WriteLine($"Length till first Start of message marker: {FindMarkerIndex(input, 14)}");
        }

        private int FindMarkerIndex(string input, int markerLength)
        {

            var window = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                if (window.Length == markerLength && window.ToString().Distinct().Count() == markerLength)
                {
                    return i;
                }
                if (window.Length == markerLength) window.Remove(0, 1);
                window = window.Append(input[i]);
            }
            return 0;
        }
    }
}
