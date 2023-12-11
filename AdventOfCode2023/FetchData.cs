namespace AdventOfCode2023
{
    public class FetchData
    {
        /// <summary>
        /// Reads input, chops it up into lines.
        /// </summary>
        /// <returns>An enumerable of the lines.</returns>
        public static IEnumerable<string> ReadList(string path, bool trim = true)
        {
            string? line;
            var sr = new StreamReader(path)
                ?? throw new FileNotFoundException();

            do
            {
                line = sr.ReadLine();

                if (line != null && line != string.Empty)
                {
                    yield return (trim) ? line.Trim() : line;
                }
            } while (line != null);

            sr?.Close();
        }

        /// <summary>
        /// We use this to trim each list entry at the start, up until 
        /// (the character after) the delimiter.
        /// </summary>
        /// <param name="delimiter">Symbol to prune.</param>
        /// <param name="collection">Enumerable of lines to prune.</param>
        /// <returns>Pruned lines.</returns>
        public static IEnumerable<string> PruneBeginning(char delimiter,
            IEnumerable<string> collection) =>
            collection.Select(x => x[(x.IndexOf(delimiter) + 1)..].Trim());

        /// <summary>
        /// Does the pruning, but returns it as a list.
        /// </summary>
        /// <param name="delimiter">Symbol to prune.</param>
        /// <param name="collection">Enumerable of lines to prune.</param>
        /// <returns>Pruned lines as list.</returns>
        public static List<string> GetPrunedList(char delimiter, IEnumerable<string> collection) =>
            PruneBeginning(delimiter, collection).ToList();

        /// <summary>
        /// Cuts up a strings by the given delimiter, and trims whitespace.
        /// </summary>
        /// <param name="delimiter">Character to use as separator.</param>
        /// <param name="text">String to cut up.</param>
        /// <returns>Split string.</returns>
        public static IEnumerable<string> ChopToList(char delimiter, string text) =>
            text.Split(delimiter, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
    }
}
