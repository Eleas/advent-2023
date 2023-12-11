namespace AdventOfCode2023
{
    public class Day4
    {
        public static int SumScratchWinnings(string v) =>
            ScratchCardsWon(v).Aggregate(0, (sum, _) => sum == 0 ? 1 : sum * 2);

        private static IEnumerable<int> ScratchCardsWon(string v)
        {
            var parts = v.Split(':').Last().Trim().Split('|');
            var winningNumbers = parts.First().Split(new[] { ' ' }, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).ToHashSet();
            var yourNumbers = parts.Last().Split(new[] { ' ' }, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

            var list = yourNumbers.Where(yourNumber => winningNumbers.Contains(yourNumber));

            return list.Select(x => int.Parse(x));
        }

        public static IEnumerable<int> CountScratchCardsWonBy(string v, int cardNumber) => Enumerable.Range(cardNumber + 1, ScratchCardsWon(v).Count());

        public static long SumFirstPartNumbers(string file) =>
            SumTotalScratchWinnings(FetchData.ReadList(file));

        private static long SumTotalScratchWinnings(IEnumerable<string> scratchCardList)
        {
            var sum = 0;
            foreach (var scratchCard in scratchCardList)
            {
                sum += SumScratchWinnings(scratchCard);
            }
            return sum;
        }

        public static int SumScratchCards(string file) => SumScratchCardWins(FetchData.ReadList(file));

        public static int SumScratchCardWins(IEnumerable<string> scratchCardList)
        {
            List<int> currentList = Enumerable.Range(1, scratchCardList.Count()).ToList();
            List<List<int>> cardCount = GetCardTable(scratchCardList);

            int sum = 0;
            do
            {
                sum += currentList.Count;
                currentList = ScratchCards(cardCount, currentList);
            } while (currentList.Count != 0);

            return sum;
        }

        private static List<List<int>> GetCardTable(IEnumerable<string> scratchCardList)
        {
            List<List<int>> cardCount = new();

            for (int i = 0; i < scratchCardList.Count(); ++i)
            {
                var cards = Day4.CountScratchCardsWonBy(scratchCardList.ElementAt(i), i + 1);
                cardCount.Add(cards.ToList());
            }

            return cardCount;
        }

        private static List<int> ScratchCards(List<List<int>> table, List<int> unprocessedCards)
        {
            var result = new List<int>();

            foreach (var card in unprocessedCards)
            {
                result.AddRange(table[card - 1]);
            }
            return result;
        }
    }
}
