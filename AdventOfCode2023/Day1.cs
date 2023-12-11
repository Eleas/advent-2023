namespace AdventOfCode2023
{
    /// <summary>
    /// First tasks is to get the first and last digit of each
    /// line. 
    /// 
    /// The Enhanced version will read that digit in either numeric
    /// symbol or written as a word.
    /// </summary>
    public class Day1
    {
        /// <summary>
        /// Method sufficient for solving first part of the problem.
        /// </summary>
        /// <param name="line">Line of text.</param>
        /// <returns>First and last literal digit found.</returns>
        public static int GetFirstLastAsNumber(string line)
        {
            if (string.IsNullOrEmpty(line)) return 0;

            var digits = line.Where(char.IsDigit).ToList();

            if (!digits.Any()) return 0;

            int firstDigit = digits.First() - '0';
            int lastDigit = digits.Last() - '0';

            return firstDigit * 10 + lastDigit;
        }

        public static int GetFirstLastAsNumberEnhanced(string line) => line != null ?
                    (GetUpperDigit(line) * 10) + GetLowerDigit(line) :
                    0;

        public static int SumFirstRange(string file) =>
            FetchData.ReadList(file).Sum(x => GetFirstLastAsNumber(x));

        public static int SumSecondRange(string file) =>
            FetchData.ReadList(file).Sum(x => GetFirstLastAsNumberEnhanced(x));

        /// <summary>
        /// Checks whether position p in line is a number, whether
        /// literal or the name of a number.
        /// </summary>
        /// <param name="line">text</param>
        /// <param name="p">position</param>
        /// <returns>The number in question, or 0 if not found.</returns>
        private static int EvaluateNumber(string line, int p)
        {
            if (char.IsDigit(line[p]))
            {
                return (char)(line[p] - '0');
            }
            else
            {
                var actualDigit = Generate.AscendingNumberSequence(1, 9).Select((d, index) => new { d, index })
                                        .FirstOrDefault(x => line[p..].StartsWith(x.d));

                return actualDigit != null ? actualDigit.index + 1 : 0;
            }
        }

        private static int GetUpperDigit(string line) =>
            line.Select((c, p) => EvaluateNumber(line, p))
                       .FirstOrDefault(result => result != 0);

        private static int GetLowerDigit(string line) => line.Reverse()
               .Select((c, p) => EvaluateNumber(line, line.Length - 1 - p))
               .FirstOrDefault(result => result != 0);
    }
}
