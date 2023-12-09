namespace AdventOfCode2023
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Advent of Code 2023!");
            Console.WriteLine("--------------------");
            Console.WriteLine();
            Console.WriteLine("Let's see the output.");

            Console.WriteLine($"Day 1: " +
                $"First number is {Day1.SumFirstRange("Data/input_day1.txt")}. " +
                $"The second is {Day1.SumSecondRange("Data/input_day1.txt")}.");
        }
    }
}