﻿// See https://aka.ms/new-console-template for more information
using AdventOfCode2022.DayCode;

Console.WriteLine("Hello, Santa's little helper! Welcome! Please make sure input file is present in the same file as the binary in the format 'dayX.in'");
Console.WriteLine("Please enter the day number: ");
string input = Console.ReadLine() ?? "invalid";

int day;
if (input == null || string.IsNullOrEmpty(input) || !int.TryParse(input, out day)) {
    Console.WriteLine($"Bad input! Stopping...");
    Console.ReadLine();
    return;
}

if (!File.Exists(Environment.CurrentDirectory + $"\\Input\\day{day}.in"))
{
    Console.WriteLine($"Input file for Day {day} is missing! Stopping...");
    Console.ReadLine();
    return;
}

string text = File.ReadAllText(Environment.CurrentDirectory + $"\\Input\\day{day}.in").Trim();
var type = Type.GetType("AdventOfCode2022.DayCode.Day" + day.ToString());

if (type == null)
{
    Console.WriteLine($"No class exists to handle Day {day}! How did I forget to implement it before running this!? Stopping...");
    Console.ReadLine();
    return;
}

IDayCode dayCode = (IDayCode)Activator.CreateInstance(type)!;

dayCode.RunDay(text);
