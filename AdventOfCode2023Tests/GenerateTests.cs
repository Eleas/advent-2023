using AdventOfCode2023;

namespace AdventOfCode2023Tests
{
    public class GenerateTests
    {
        [Fact]
        public void NumberNameSequence_FromOneToNine_GetCorrectResponse()
        {
            var actual = Generate.NumberNameSequence(1, 9);
            List<string> expected = new () { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            Assert.Equal(expected, actual);
        }
    }
}