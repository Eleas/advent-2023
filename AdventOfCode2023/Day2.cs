using System.Drawing;

namespace AdventOfCode2023
{
    /// <summary>
    /// This challenge involves a game of colored cubes: red, green, and blue.
    /// The elf has a bag of cubes. For each game, he draws out cubes at random.
    /// You write down the results as a semicolon-separated list, one entry for each game.
    /// 
    /// You have a quantity of cubes yourself. The task is to determine whether
    /// or not you have enough cubes that you could have gotten the same result.
    /// 
    /// Two tasks: the first is to determine which games could be won (by summing
    /// the id number of each entry that could win). The second is to add together 
    /// all the cubes.
    /// 
    /// Some of these methods make little sense to expose. They're visible for
    /// purposes of testing, not because they are really needed for the API.
    /// </summary>
    public class Day2
    {
        public static List<Dictionary<string, int>> GetListOfAllGames(List<string> input) =>
            FetchData.GetPrunedList(':', input).Select(x => ConstructGameSet(x)).ToList();

        public static List<int> GetIndexesOfSuccessfulGames(List<string> input, Dictionary<string, int> ourCubes)
        {
            var games = Day2.GetListOfAllGames(input).ToList();

            var sum = games.Select((game, index) => new { Game = game, Index = index })
                           .Where(x => Day2.ContainsEnoughCubes(ourCubes, x.Game))
                           .Sum(x => x.Index + 1);

            return games.Select((game, index) => new { Game = game, Index = index })
                        .Where(x => Day2.ContainsEnoughCubes(ourCubes, x.Game))
                        .Select(x => x.Index + 1).ToList();
        }

        public static int SumFirstIndexes(string file) =>
            GetIndexesOfSuccessfulGames(FetchData.ReadList(file).ToList(), ConstructGameSet("12 red, 13 green, 14 blue")).Sum();

        public static int SumSecondValues(string file)
        {
            var input = FetchData.ReadList(file).ToList();
            var games = Day2.GetListOfAllGames(input).ToList();

            return games.Sum(game => game.Select(x => x.Value).Aggregate((a, x) => a * x));
        }

        public static long ComputePower(Dictionary<string, int> dictionary) =>
            dictionary.Select(x => x.Value).Aggregate((a, x) => a * x);

        private static readonly List<Color> Colors = new() { Color.Red, Color.Green, Color.Blue };

        private static List<string> ColorList(List<Color> colors) => colors.Select(c => c.Name.ToLower()).ToList();

        private static Dictionary<string, int> ConstructGameSet(string list)
        {
            var colorList = ColorList(Colors);
            var sets = FetchData.ChopToList(';', list);

            return sets.SelectMany(set => FetchData.ChopToList(',', set))
                       .SelectMany(item => colorList.Where(c => item.EndsWith(c))
                                                    .Select(c => new { Color = c, Value = int.Parse(item[..item.IndexOf(' ')]) }))
                       .GroupBy(x => x.Color)
                       .ToDictionary(g => g.Key, g => g.Max(x => x.Value));
        }

        private static bool ContainsEnoughCubes(Dictionary<string, int> ourCubes, Dictionary<string, int> cubesUsedInGame) =>
            ourCubes.All(cube => cubesUsedInGame.TryGetValue(cube.Key, out int count) && count <= cube.Value);
    }
}
