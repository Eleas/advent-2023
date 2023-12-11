namespace AdventOfCode2023
{
    public class Generate
    {
        /// <summary>
        /// We expand this to cover all numbers, but only when we 
        /// have the need. A little exercise in minimalism, right?
        /// </summary>
        /// <param name="number">Integer to convert to text.</param>
        /// <returns>Text version of the number.</returns>
        /// <exception cref="NotImplementedException">Numbers. Too many 
        /// numbers. Numbers everywhere...
        /// </exception>
        private static string NumToString(int number) =>
        number switch
        {
            < 0 => $"minus {NumToString(-number)}",
            0 => "zero",
            1 => "one",
            2 => "two",
            3 => "three",
            4 => "four",
            5 => "five",
            6 => "six",
            7 => "seven",
            8 => "eight",
            9 => "nine",
            10 => "ten",
            11 => "eleven",
            12 => "twelve",
            _ => throw new NotImplementedException()
        };

        /// <summary>
        /// From one number to another.
        /// </summary>
        /// <param name="begin">Start number.</param>
        /// <param name="end">End number.</param>
        /// <returns>A sequence of numbers, but 
        /// as words.</returns>
        public static IEnumerable<string> AscendingNumberSequence(int begin, int end)
        {
            for (int i = begin; i <= end; i++)
                yield return NumToString(i);
        }
    }
}
