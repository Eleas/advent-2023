using System.Drawing;

namespace AdventOfCode2023
{
    public class Mapping
    {
        /// <summary>
        /// This looks through a text map, and returns the coordinates
        /// of anything matching the predicate function.
        /// </summary>
        /// <param name="specifiedCharacter">Predicate function: a 
        /// function which takes a character and then returns true
        /// if it fits your criteria.</param>
        /// <param name="map">Several strings of equal length.</param>
        /// <returns>A collection of points that match what you
        /// were looking for.</returns>
        public static IEnumerable<Point> GetPositionOfSymbols(Func<char, bool> specifiedCharacter, IEnumerable<string> map) =>
            map.SelectMany((row, y) => row.Select((character, x) => new { character, x, y }))
                      .Where(item => specifiedCharacter(item.character))
                      .Select(item => new Point(item.x, item.y));

        public static IEnumerable<string> GetAndPadLine(IEnumerable<string> map, int line, char padding)
        {
            // Get first line if exists, otherwise empty.
            if (line > 0) { yield return padding + map.ElementAt(line - 1) + padding; }
            else { yield return new string(padding, map.First().Length + 2); }

            yield return padding + map.ElementAt(line) + padding;

            // Get last line if exists, otherwise empty.
            if (line < map.Count() - 1) { yield return padding + map.ElementAt(line + 1) + padding; }
            else { yield return new string(padding, map.First().Length + 2); }
        }

        public static IEnumerable<string> GetAndPadNumber(IEnumerable<string> map, int row, int column, int length, char padding)
        {
            var mapping = Mapping.GetAndPadLine(map, row, padding);
            return mapping.Select(c => c.Substring(column, length + 2));
        }

        public static IEnumerable<Number> GetNeighbors(IEnumerable<Number> validNumbers, Point point)
        {
            return validNumbers.Where(number =>
            {
                var p = number.Position;
                return point.Y <= p.Y + 1 && point.Y >= p.Y - 1 &&
                       point.X >= p.X - 1 && point.X <= p.X + number.Length;
            });
        }
    }
}
