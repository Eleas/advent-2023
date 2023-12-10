namespace AdventOfCode2023
{
    public class FetchData
    {
        /// <summary>
        /// Reads input, chops it up into lines.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<string> ReadList(string path, bool trim = true)
        {
            string line;
            var sr = new StreamReader(path)
                ?? throw new FileNotFoundException();

            do
            {
                line = sr?.ReadLine() ?? string.Empty;

                if (line != null && line != string.Empty) 
                {
                    yield return (trim) ? line.Trim() : line; 
                }
            } while (line != null);

            sr?.Close();
        }

        public static IEnumerable<string> PruneBeginning(char delimiter, 
            IEnumerable<string> list) =>
            list.Select(x => x[(x.IndexOf(delimiter) + 1)..].Trim());

        public static IEnumerable<string> ChopToList(char delimiter, string line) =>
            line.Split(delimiter, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

        public static List<string> GetPrunedList(char delimiter, IEnumerable<string> input) =>
            PruneBeginning(delimiter, input).ToList();
    }
}
