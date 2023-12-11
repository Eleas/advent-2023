using System.Drawing;

namespace AdventOfCode2023
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<IEnumerable<T>> GroupAdjacentBy<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            List<T> group = new();

            foreach (var item in source)
            {
                if (predicate(item))
                {
                    group.Add(item);
                }
                else if (group.Any())
                {
                    yield return group;
                    group = new List<T>();
                }
            }

            if (group.Any())
            {
                yield return group;
            }
        }
    }

    public record Number(Point Position, int Length, int Value);

    public class Day3
    {
        public static IEnumerable<Number> ListNumbers(IEnumerable<string> enumerable)
        {
            return enumerable
                .SelectMany((line, y) => line
                    .Select((c, x) => new { Char = c, X = x })
                    .GroupAdjacentBy(c => char.IsDigit(c.Char))
                    .Where(g => g.Any())
                    .Select(g => new Number(new Point(g.First().X, y), g.Count(), int.Parse(new string(g.Select(c => c.Char).ToArray())))))
                .ToList();
        }

        public static bool IsPartNumber(Number n, IEnumerable<string> map) =>
            Mapping.GetAndPadNumber(map, n.Position.Y, n.Position.X, n.Length, '.').Any(x => HasPartSymbol(x));

        public static int SumFirstPartNumbers(string file) => SumPartNumbers(FetchData.ReadList(file));

        public static long SumSecondPartNumbers(string file) => SumGearPoints(FetchData.ReadList(file));

        public static long SumGearPoints(IEnumerable<string> list)
        {
            var validNumbers = Day3.ListNumbers(list);

            return ComputeGearPoints(list)
                   .AsParallel() // Use only for large datasets
                   .Select(point => Mapping.GetNeighbors(validNumbers, point).ToList())
                   .Where(neighbors => neighbors.Count == 2)
                   .Sum(neighbors => neighbors[0].Value * neighbors[1].Value);
        }

        private static IEnumerable<Point> ComputeGearPoints(IEnumerable<string> list) =>
            list.SelectMany((line, y) => line
                        .Select((ch, x) => new { ch, x })
                        .Where(item => item.ch == '*')
                        .Select(item => new Point(item.x, y)));

        private static int SumPartNumbers(IEnumerable<string> schematic) =>
            Day3.ListNumbers(schematic).
            Sum(x => Day3.IsPartNumber(x, schematic) ? x.Value : 0);

        private static bool HasPartSymbol(string line) =>
            line.Any(c => c != '.' && !char.IsNumber(c));
    }
}
