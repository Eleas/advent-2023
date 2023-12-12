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

        [Fact]
        public static void SeedToSoil_TestAlmanac_DescribedRangeOfValues()
        {
            List<int> table = Day5.CreateSeedSoilTable(ParseData.ChopToList('\n', _almanac));

            Assert.Equal(0, table[0]);
            Assert.Equal(52, table[50]);
            Assert.Equal(99, table[97]);
            Assert.Equal(50, table[98]);
        }
    }
}
