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
        public void PadMap_Map_PaddedMap()
        {
            var padded = Mapping.PadMap(FetchData.ChopToList('\n', _schematic), '.');

            Assert.Equal(new string('.', 12), padded.First());
            Assert.StartsWith("....*", padded.ElementAt(2));
        }
    }
}
