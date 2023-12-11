using AdventOfCode2023;
using System.Drawing;

namespace AdventOfCode2023Tests
{
    /*
    1. any number adjacent to a symbol, even diagonally, is a "part number" 
    and should be included in your sum.
    
    2. (Periods (.) do not count as a 
    symbol.)

    In this schematic, 
        - two numbers not part numbers (not adjacent to a symbol): 114 (top right) and 58 (middle right)
        - rest is adjacent to a symbol and so is a part number; their sum is 4361.

    Q: What is the sum of all part numbers? 
    */

    public class Day3Tests
    {
        private static readonly string _schematic =
        """
        467..114..
        ...*......
        ..35..633.
        ......#...
        617*......
        .....+.58.
        ..592.....
        ......755.
        ...$.*....
        .664.598..
        """;

        [Theory]
        [InlineData(0, 0, 3, 467)]
        [InlineData(5, 0, 3, 114)]
        [InlineData(2, 2, 2, 35)]
        [InlineData(6, 2, 3, 633)]
        [InlineData(1, 9, 3, 664)]
        public void ListNumbers_TestSchematic_ValidNumbers(int x, int y, int length, int value)
        {
            var validNumbers = Day3.ListNumbers(ParseData.ChopToList('\n', _schematic));

            Assert.Contains<Number>(new Number(new Point(x, y), length, value), validNumbers);
        }

        [Theory]
        [InlineData(0, true)]
        [InlineData(1, false)]
        [InlineData(2, true)]
        [InlineData(3, true)]
        [InlineData(4, true)]
        public void IsPartsNumber_TestSchematic_ValidParts(int index, bool isPart)
        {
            var list = ParseData.ChopToList('\n', _schematic);
            var validNumbers = Day3.ListNumbers(list);

            Assert.Equal(isPart, Day3.IsPartNumber(validNumbers.ElementAt(index), list));
        }

        [Fact]
        public void IsPartsNumber_AskForSum_GetCorrectSum()
        {
            var list = ParseData.ChopToList('\n', _schematic);
            var validNumbers = Day3.ListNumbers(list);

            var parts = validNumbers.Select(x => Day3.IsPartNumber(x, list));

            var sum = validNumbers.Sum(x => Day3.IsPartNumber(x, list) ? x.Value : 0);

            Assert.Equal(4361, sum);
        }

        [Fact]
        public void GetNeighborTo_GivePoint_GetNeighbors()
        {
            var list = ParseData.ChopToList('\n', _schematic);
            var validNumbers = Day3.ListNumbers(list);

            IEnumerable<Number> neighbors = Mapping.GetNeighbors(validNumbers, new Point(2, 5));

            Assert.Equal(1209, neighbors.Sum(x => x.Value));
        }

        [Fact]
        public void GetNeighborTo_AsteriskPoints_GetGearSums()
        {

            var list = ParseData.ChopToList('\n', _schematic);
            var validNumbers = Day3.ListNumbers(list);

            List<Point> gearPoints = new()
            {
                new Point(3,1), new Point(3,4), new Point(5,8)
            };

            long sum = 0;
            foreach (var point in gearPoints)
            {
                var neighbors = Mapping.GetNeighbors(validNumbers, point);
                if (neighbors.Count() == 2)
                {
                    sum += neighbors.First().Value * neighbors.Last().Value;
                }
            }

            Assert.Equal(467835, sum);
        }
    }
}
