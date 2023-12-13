using AdventOfCode2023;

namespace AdventOfCode2023Tests
{
    public class Day5Tests
    {
        private static readonly string _almanac = """
            seeds: 79 14 55 13

            seed-to-soil map:
            50 98 2
            52 50 48

            soil-to-fertilizer map:
            0 15 37
            37 52 2
            39 0 15

            fertilizer-to-water map:
            49 53 8
            0 11 42
            42 0 7
            57 7 4

            water-to-light map:
            88 18 7
            18 25 70

            light-to-temperature map:
            45 77 23
            81 45 19
            68 64 13

            temperature-to-humidity map:
            0 69 1
            1 0 69

            humidity-to-location map:
            60 56 37
            56 93 4

            """;

        [Theory]
        [InlineData(10, 10)]
        [InlineData(49, 49)]
        [InlineData(99, 51)]
        [InlineData(70, 72)]
        public static void Translate_SeedToSoilNumbers_GetCorrectSpan(int inData, int outData)
        {
            // Arrange
            List<TranslationRule> rules = new() { new TranslationRule(50, 98, 2), new TranslationRule(52, 50, 48) };
            Translator seedToSoil = new(rules);

            // Act
            Assert.Equal(outData, seedToSoil.Translate(inData));
        }

        [Theory]
        [InlineData(10, 10)]
        [InlineData(49, 49)]
        [InlineData(99, 51)]
        [InlineData(70, 72)]
        public static void Translate_SeedToSoilNumbersWithStringInput_GetCorrectSpan(int inData, int outData)
        {
            // Arrange
            Translator seedToSoil = new("""
                50 98 2
                52 50 48
                """);

            // Act
            Assert.Equal(outData, seedToSoil.Translate(inData));
        }

        /*
         * Seed 79, soil 81, fertilizer 81, water 81, light 74, temperature 78, humidity 78, location 82.
         * Seed 14, soil 14, fertilizer 53, water 49, light 42, temperature 42, humidity 43, location 43.
         * Seed 55, soil 57, fertilizer 57, water 53, light 46, temperature 82, humidity 82, location 86.
         * Seed 13, soil 13, fertilizer 52, water 41, light 34, temperature 34, humidity 35, location 35.
         */

        [Theory]
        [InlineData(78, 82)]
        [InlineData(43, 43)]
        [InlineData(82, 86)]
        [InlineData(35, 35)]
        public static void Translate_FromHumidity_GetLocation(int inData, int expectedData)
        {
            // Arrange
            Translator seedToSoil = new(string.Join("\n", ParseData.GetSection(_almanac, "humidity-to-location map")));

            var list = Day5.GenerateMapNames();

            // Act
            Assert.Equal(expectedData, seedToSoil.Translate(inData));
        }

        [Theory]
        [InlineData(79, 82)]
        [InlineData(14, 43)]
        [InlineData(55, 86)]
        [InlineData(13, 35)]
        public static void Translate_SeedValues_LocationValues(long seed, long location)
        {
            long value = seed;
            foreach (var t in Day5.GenerateTranslationList(_almanac))
            {
                value = t.Translate(value);
            }

            Assert.Equal(location, value);
        }

        [Fact]
        public static void TranslateSeedToLocation_SeedValueList_GetLowest()
        {
            List<long> seeds = Day5.GetSeedCount(_almanac);
            var translators = Day5.GenerateTranslationList(_almanac).ToList();

            var current = Day5.TranslateSeedToLocation(seeds.First(), translators);

            foreach (var s in seeds)
            {
                current = Math.Min(current, Day5.TranslateSeedToLocation(s, translators));
            }

            Assert.Equal(35, current);
        }

    }
}
