namespace AdventOfCode2023
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Advent of Code 2023!");
            Console.WriteLine("--------------------");
            Console.WriteLine();
            Console.WriteLine("Let's see the output.");
            Console.WriteLine();

            Console.WriteLine($"Day 1: ");
            Console.WriteLine($"First number is {Day1.SumFirstRange("Data/input_day1.txt")}\n" +
                $"The second is {Day1.SumSecondRange("Data/input_day1.txt")}\n");

            Console.WriteLine($"Day 2: ");
            Console.WriteLine($"First number is {Day2.SumFirstIndexes("Data/input_day2.txt")}\n" +
                $"The second is {Day2.SumSecondValues("Data/input_day2.txt")}\n");

            Console.WriteLine($"Day 3: ");
            Console.WriteLine($"First number is {Day3.SumFirstPartNumbers("Data/input_day3.txt")}\n" +
                $"The second is {Day3.SumSecondPartNumbers("Data/input_day3.txt")}\n");

        }
    }
}