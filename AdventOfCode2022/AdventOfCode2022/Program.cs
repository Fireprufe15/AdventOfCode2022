// See https://aka.ms/new-console-template for more information
using AdventOfCode2022.DayCode;

Console.WriteLine("Hello, Santa's little helper! Welcome! Please make sure input file is present in the same file as the binary in the format 'dayX.in'");
Console.WriteLine("Please enter the day number: ");
int day = int.Parse(Console.ReadLine());

string text = File.ReadAllText(Environment.CurrentDirectory + $"\\Input\\day{day}.in").Trim();
var type = Type.GetType("AdventOfCode2022.DayCode.Day" + day.ToString());
IDayCode dayCode = (IDayCode)Activator.CreateInstance(type);
dayCode.RunDay(text);
