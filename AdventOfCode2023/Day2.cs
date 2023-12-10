using System.Drawing;

namespace AdventOfCode2023
{
    public class Day2
    {
        private static readonly List<Color> Colors = new() { Color.Red, Color.Green, Color.Blue };

        private static List<string> ColorList (List<Color> colors) => colors.Select(c => c.Name.ToLower()).ToList();

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

        public static List<Dictionary<string, int>> GetListOfAllGames(List<string> input) => 
            FetchData.GetPrunedList(':', input).Select(x => ConstructGameSet(x)).ToList();

        private static bool ContainsEnoughMarbles(Dictionary<string, int> ourMarbles, Dictionary<string, int> marblesUsedInGame) {
            foreach (var marble in ourMarbles)
            {
                if (!marblesUsedInGame.ContainsKey(marble.Key) || marblesUsedInGame[marble.Key] > marble.Value)
                {
                    return false;
                }
            }
            return true;
        }

        public static List<int> GetIndexesOfSuccessfulGames(List<string> input, Dictionary<string, int> ourMarbles)
        {
            var games = Day2.GetListOfAllGames(input).ToList();

            var sum = games.Select((game, index) => new { Game = game, Index = index })
                           .Where(x => Day2.ContainsEnoughMarbles(ourMarbles, x.Game))
                           .Sum(x => x.Index + 1);

            return games.Select((game, index) => new { Game = game, Index = index })
                        .Where(x => Day2.ContainsEnoughMarbles(ourMarbles, x.Game))
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
    }
}
