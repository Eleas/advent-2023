namespace AdventOfCode2023
{

    public class Day5
    {
        public static IEnumerable<string> GenerateMapNames()
        {
            List<string> basicMapName = new()
            {
                "seed",
                "soil",
                "fertilizer",
                "water",
                "light",
                "temperature",
                "humidity",
                "location"
            };

            for (int i = 0; i < basicMapName.Count - 1; i++)
            {
                yield return $"{basicMapName[i]}-to-{basicMapName[i + 1]} map";
            }
        }

        public static IEnumerable<Translator> GenerateTranslationList(string almanac)
        {
            foreach (var map in Day5.GenerateMapNames())
            {
                yield return new(string.Join("\n", ParseData.GetSection(almanac, map)));
            }
        }

        public static List<long> GetSeedCount(string almanac)
        {
            var searchParam = "seeds: ";
            var startIndex = almanac.IndexOf(searchParam) + searchParam.Length;
            var length = almanac.IndexOf("\r\n\r\n") - startIndex;
            var seedDescription = almanac.Substring(startIndex, length).Split(" ", StringSplitOptions.TrimEntries);

            return seedDescription.Select(long.Parse).ToList();
        }

        public static long TranslateSeedToLocation(long seed, List<Translator> translators)
        {
            long value = seed;
            foreach (var t in translators)
            {
                value = t.Translate(value);
            }

            return value;
        }

        public static long GetLowestSeedValue(string file) => ComputeLowestSeedValue(ParseData.Read(file));

        public static long ComputeLowestSeedValue(string almanac)
        {
            var translators = GenerateTranslationList(almanac).ToList();
            var seeds = GetSeedCount(almanac);

            var current = Day5.TranslateSeedToLocation(seeds.First(), translators);

            foreach (var s in seeds)
            {
                current = Math.Min(current, Day5.TranslateSeedToLocation(s, translators));
            }
            return current;
        }


    }
}
