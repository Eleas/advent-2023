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
        [InlineData(51, 99)]
        [InlineData(72, 70)]
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
        [InlineData(51, 99)]
        [InlineData(72, 70)]
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

    }
}
