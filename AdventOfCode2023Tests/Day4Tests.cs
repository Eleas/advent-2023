using AdventOfCode2023;

namespace AdventOfCode2023Tests
{
    public class Day4Tests
    {
        // First part are winning numbers. Second part are your numbers.
        // First match you have, card gets one point. 
        // Subsequent matches double the card's point.

        private static string scratchCards = """
            Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53
            Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19
            Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1
            Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83
            Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36
            Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11
            """;

        [Fact]
        public static void SumScratchWinnings_FirstCardInput_GetSum()
        {
            int sum = Day4.SumScratchWinnings("Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53");

            Assert.Equal(8, sum);
        }

        [Fact]
        public static void ScratchCardsWonBy_FirstCardInput_GetRightNumbers()
        {
            int number = 1;
            var first = "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53";
            var actual = Day4.CountScratchCardsWonBy(first, number);

            Assert.Equal(Enumerable.Range(number + 1, 4), actual);
        }

        [Fact]
        public static void ScratchCardsWonBy_SecondCardInput_GetRightNumbers()
        {
            int number = 2;
            var first = "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19";
            var actual = Day4.CountScratchCardsWonBy(first, number);

            Assert.Equal(Enumerable.Range(number + 1, 2), actual);
        }

        [Fact]
        public static void ScratchCardsWonBy_MultipleTimes_ComputeTotalCards()
        {
            var sum = Day4.SumScratchCardWins(FetchData.ChopToList('\n', scratchCards));

            Assert.Equal(30, sum);
        }
    }
}
