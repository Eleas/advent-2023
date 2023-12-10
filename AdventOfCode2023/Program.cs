﻿namespace AdventOfCode2023
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Advent of Code 2023!");
            Console.WriteLine("--------------------");
            Console.WriteLine();
            Console.WriteLine("Let's see the output.");

            Console.WriteLine($"Day 1: " +
                $"First number is {Day1.SumFirstRange("Data/input_day1.txt")}. " +
                $"The second is {Day1.SumSecondRange("Data/input_day1.txt")}.");
            Console.WriteLine();

            Console.WriteLine($"Day 2: " +
                $"First number is {Day2.SumFirstIndexes("Data/input_day2.txt")}. " + 
                $"The second is {Day2.SumSecondValues("Data/input_day2.txt")}.");
            Console.WriteLine();
        }
    }
}