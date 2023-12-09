namespace AdventOfCode2023
{
    public class Generate
    {
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

        public static IEnumerable<string> NumberNameSequence(int begin, int end)
        {
            for (int i = begin; i <= end; i++)
                yield return NumToString(i);
        }
    }
}
