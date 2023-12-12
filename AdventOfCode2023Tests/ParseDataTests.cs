using AdventOfCode2023;

namespace AdventOfCode2023Tests
{
    public class ParseDataTests
    {
        private static string _almanac = """
            seeds: 79 14 55 13

            seed-to-soil map:
            50 98 2
            52 50 48

            soil-to-fertilizer map:
            """;

        [Fact]
        public static void GetSection_AddLargerText_GetCorrectPiece()
        {
            List<string> expected = new List<string>()
            {
                "seed-to-soil map:","50 98 2","52 50 48"
            };

            var actual = ParseData.GetSection(_almanac, "seed-to-soil map:").ToList();

            Assert.Equal(expected, actual);
        }
    }
}
