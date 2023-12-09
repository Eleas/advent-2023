namespace AdventOfCode2
{
    internal class Program
    {
        /// <summary>
        /// Method sufficient for solving first part of the problem.
        /// </summary>
        /// <param name="line">Line of text.</param>
        /// <returns>First and last literal digit found.</returns>
        public static int GetFirstLastAsNumber(string line)
        {
            if (line == null || line == string.Empty) { return 0; }

            string numbers = string.Concat(line.Where(char.IsDigit));
            return ((numbers?.First() - '0' ?? 0) * 10) + numbers?.Last() - '0' ?? 0;
        }

        /// <summary>
        /// Digits used to define the numbers.
        /// </summary>
        private static readonly List<string> digits = new()
        {
            "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"
        };

        public static int GetFirstLastAsNumberEnhanced(string line) => line != null ?
            (GetUpperDigit(line) * 10) + GetLowerDigit(line) :
            0;

        public static int GetUpperDigit(string line) =>
            line.Select((c, p) => EvaluateNumber(line, p))
                       .FirstOrDefault(result => result != 0);

        public static int GetLowerDigit(string line) => line.Reverse()
               .Select((c, p) => EvaluateNumber(line, line.Length - 1 - p))
               .FirstOrDefault(result => result != 0);

        /// <summary>
        /// Checks whether position p in line is a number, whether
        /// literal or the name of a number.
        /// </summary>
        /// <param name="line">text</param>
        /// <param name="p">position</param>
        /// <returns>The number in question, or 0 if not found.</returns>
        public static int EvaluateNumber(string line, int p)
        {
            if (char.IsDigit(line[p]))
            {
                char digit = (char)(line[p] - '0');
                return digit;
            }
            else
            {
                var actualDigit = digits.Select((d, index) => new { d, index })
                                        .FirstOrDefault(x => line[p..].StartsWith(x.d));

                return actualDigit != null ? actualDigit.index + 1 : 0;
            }
        }

        /// <summary>
        /// Reads input.txt, chops it up into lines.
        /// </summary>
        /// <returns></returns>
        static IEnumerable<string> GetChoppedList()
        {
            string line;
            StreamReader sr = new("input.txt");

            do
            {
                line = sr.ReadLine();
                if (line != null && line != string.Empty) { yield return line; }
            } while (line != null);

            sr.Close();
        }

        static void Main(string[] args)
        {
            var input = GetChoppedList();
            int sum = 0;

            foreach (var ln in input)
            {
                sum += GetFirstLastAsNumberEnhanced(ln.Trim());
            }

            Console.WriteLine(sum);
        }
    }
}