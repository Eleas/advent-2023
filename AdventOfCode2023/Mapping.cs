using System.Drawing;

namespace AdventOfCode2023
{
    public class Mapping
    {
        //public static IEnumerable<Point> GetPositionOfSymbols(Func<char, bool> isSpecificCharacter, List<string> map)
        //{
        //    for(int y = 0; y < map.Count; y++)
        //    {
        //        for (int x = 0; x < map[y].Length; x++)
        //        {
        //            if (isSpecificCharacter(map[y][x]))
        //            {
        //                yield return new Point(x, y);
        //            }
        //        }
        //    }
        //}



        public static IEnumerable<Point> GetPositionOfSymbols(Func<char, bool> specifiedCharacter, IEnumerable<string> map)
        {
            return map.SelectMany((row, y) => row.Select((character, x) => new { character, x, y }))
                      .Where(item => specifiedCharacter(item.character))
                      .Select(item => new Point(item.x, item.y));
        }

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
