using AdventOfCode2023;
using System.Drawing;

namespace AdventOfCode2023Tests
{
    public class MappingTests
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

        [Fact]
        public void GetPositionOfSymbols_Testinput_FindAllAsterisks()
        {
            var asterisks = Mapping.GetPositionOfSymbols(c => c == '*',
                FetchData.ChopToList('\n', _schematic));

            Assert.Equal(new Point(3, 1), asterisks.First());
        }

        [Fact]
        public void GetAndPadLine_MiddleOfMap_GetThreeLines()
        {
            var expected =
            """
            ....*.......
            ...35..633..
            .......#....
            """;

            var actual = Mapping.GetAndPadLine(FetchData.ChopToList('\n', _schematic), 2, '.');
            Assert.Equal(FetchData.ChopToList('\n', expected), actual);
        }

        [Fact]
        public void GetAndPadLine_StartOfMap_GetThreeLines()
        {
            var expected =
            """
            ............
            .467..114...
            ....*.......
            """;

            var actual = Mapping.GetAndPadLine(FetchData.ChopToList('\n', _schematic), 0, '.');
            Assert.Equal(FetchData.ChopToList('\n', expected), actual);
        }

        [Fact]
        public void GetAndPadLine_EndOfMap_GetThreeLines()
        {
            var expected =
            """
            ....$.*.....
            ..664.598...
            ............
            """;

            var actual = Mapping.GetAndPadLine(FetchData.ChopToList('\n', _schematic), 9, '.');
            Assert.Equal(FetchData.ChopToList('\n', expected), actual);
        }

        [Fact]
        public void GetNeighbors_OffByOne_Fails()
        {
            var list = FetchData.ChopToList('\n', _schematic);
            var validNumbers = Day3.ListNumbers(list);

            var neighbors = Mapping.GetNeighbors(validNumbers, new Point(5, 8));

            Assert.Equal(2, neighbors.Count());
        }
    }
}
