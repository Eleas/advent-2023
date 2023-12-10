using AdventOfCode2023;
using System.Runtime.InteropServices;

/* 
As you walk, the Elf shows you a small bag and some cubes which are either red, green, or blue. 
Each time you play this game, he will hide a secret number of cubes of each color in the bag, 
and your goal is to figure out information about the number of cubes.

To get information, once a bag has been loaded with cubes, the Elf will reach into the bag, 
grab a handful of random cubes, show them to you, and then put them back in the bag. He'll 
do this a few times per game.

You play several games and record the information from each game (your puzzle input). Each game 
is listed with its ID number (like the 11 in Game 11: ...) followed by a semicolon-separated 
list of subsets of cubes that were revealed from the bag (like 3 red, 5 green, 4 blue).

For example, the record of a few games might look like this:

    Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
    Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
    Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
    Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
    Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green

In game 1, three sets of cubes are revealed from the bag (and then put back again). The first 
set is 3 blue cubes and 4 red cubes; the second set is 1 red cube, 2 green cubes, and 6 blue 
cubes; the third set is only 2 green cubes.

The Elf would first like to know which games would have been possible if the bag contained only 
12 red cubes, 13 green cubes, and 14 blue cubes?

In the example above, games 1, 2, and 5 would have been possible if the bag had been loaded 
with that configuration. However, game 3 would have been impossible because at one point 
the Elf showed you 20 red cubes at once; similarly, game 4 would also have been impossible 
because the Elf showed you 15 blue cubes at once. If you add up the IDs of the games that 
would have been possible, you get 8.

Determine which games would have been possible if the bag had been loaded with only 12 red 
cubes, 13 green cubes, and 14 blue cubes. What is the sum of the IDs of those games?


 */



namespace AdventOfCode2023Tests
{
    public class Day2Tests
    {
        private static string Input = """
        Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
        Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
        Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
        Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
        Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green
        """;

        [Fact]
        public void GetListOfAllGames_TestInput_GetCorrectCountOfBlues()
        {
            Dictionary<string, int> firstGame = Day2.GetListOfAllGames(FetchData.ChopToList('\n',Input).ToList()).First();
            var blueContent = (firstGame.ContainsKey("blue")) ? firstGame["blue"] : 0;

            Assert.Equal(6, blueContent);
        }

        [Fact]
        public void GetIndexOfSuccessfulGames_MarbleListAndGameRecord_SumOfValidGameIds()
        {
            var ourMarbles = new Dictionary<string, int>()
            {
                { "red", 12 },
                { "green", 13 },
                { "blue", 14 }
            };

            var sum = Day2.GetIndexesOfSuccessfulGames(FetchData.ChopToList('\n',Input).ToList(), ourMarbles).Sum();
            Assert.Equal(8, sum);
        }

        [Theory]
        [InlineData(2, 12)]
        [InlineData(3, 1560)]
        [InlineData(4, 630)]
        [InlineData(5, 36)]
        public void SumMinimumCubesPower_GamesTwoThroughFive_GetCorrectResult(int oneBasedIndex, int powerValue)
        {
            var gameData = Day2.GetListOfAllGames(FetchData.ChopToList('\n', Input).ToList()).ToList();

            Assert.Equal(powerValue, Day2.ComputePower(gameData[oneBasedIndex - 1]));
        }
    }
}
