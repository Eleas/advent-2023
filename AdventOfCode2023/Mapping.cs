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

        /// <summary>
        /// Sometimes, you need to surround a list of strings with
        /// whitespace or some other character. This function does that.
        /// </summary>
        /// <param name="map">Several strings of equal length.</param>
        /// <param name="padCharacter">The character to use when padding.</param>
        /// <returns>Those same strings, padded.</returns>
        public static IEnumerable<string> PadMap(IEnumerable<string> map, char padCharacter)
        {
            yield return new string(padCharacter, map.First().Length + 2);
            foreach (var line in map)
            {
                yield return padCharacter + line + padCharacter;
            }
            yield return new string(padCharacter, map.First().Length + 2);
        }
    }
}
