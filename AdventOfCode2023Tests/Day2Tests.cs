using AdventOfCode2023;

namespace AdventOfCode2023Tests
{
    public class Day2Tests
    {
        private static readonly string testInput = """
        Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
        Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
        Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
        Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
        Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green
        """;

        [Fact]
        public void GetListOfAllGames_TestInput_GetCorrectCountOfBlues()
        {
            Dictionary<string, int> firstGame = Day2.GetListOfAllGames(ParseData.ChopToList('\n', testInput).ToList()).First();
            var blueContent = (firstGame.ContainsKey("blue")) ? firstGame["blue"] : 0;

            Assert.Equal(6, blueContent);
        }

        [Fact]
        public void GetIndexOfSuccessfulGames_CubeListAndGameRecord_SumOfValidGameIds()
        {
            var ourCubes = new Dictionary<string, int>()
            {
                { "red", 12 },
                { "green", 13 },
                { "blue", 14 }
            };

            var sum = Day2.GetIndexesOfSuccessfulGames(ParseData.ChopToList('\n', testInput).ToList(), ourCubes).Sum();
            Assert.Equal(8, sum);
        }

        [Theory]
        [InlineData(2, 12)]
        [InlineData(3, 1560)]
        [InlineData(4, 630)]
        [InlineData(5, 36)]
        public void SumMinimumCubesPower_GamesTwoThroughFive_GetCorrectResult(int oneBasedIndex, int powerValue)
        {
            var gameData = Day2.GetListOfAllGames(ParseData.ChopToList('\n', testInput).ToList()).ToList();

            Assert.Equal(powerValue, Day2.ComputePower(gameData[oneBasedIndex - 1]));
        }
    }
}
