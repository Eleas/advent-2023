using AdventOfCode2023;

namespace AdventOfCode2023Tests
{
    public class Day1Tests
    {
        [Fact]
        public void GetFirstLastAsNumber_TwoNumbers_CorrectResult()
        {
            Assert.Equal(35, Day1.GetFirstLastAsNumber("a3005"));
        }

        [Fact]
        public void GetFirstLastAsNumber_OneNumber_CorrectResult()
        {
            Assert.Equal(33, Day1.GetFirstLastAsNumber("a3"));
        }

        [Fact]
        public void GetFirstLastAsNumber_NoNumber_ThrowsException()
        {
            Assert.Throws<System.InvalidOperationException>(() => Day1.GetFirstLastAsNumber("ab"));
        }

        [Fact]
        public void GetFirstLastAsNumberEnhanced_TwoNumbers_CorrectResult()
        {
            Assert.Equal(35, Day1.GetFirstLastAsNumberEnhanced("a3005"));
        }

        [Fact]
        public void GetFirstLastAsNumberEnhanced_OneNumber_CorrectResult()
        {
            Assert.Equal(33, Day1.GetFirstLastAsNumberEnhanced("a3"));
        }

        [Fact]
        public void GetFirstLastAsNumberEnhanced_TwoAlphabeticNumbers_CorrectResult()
        {
            Assert.Equal(86, Day1.GetFirstLastAsNumberEnhanced("eightwoa3005six"));
        }
    }
}
