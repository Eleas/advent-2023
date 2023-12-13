namespace AdventOfCode2023
{
    public record TranslationRule(long Source, long Destination, long Steps);

    public class Translator
    {
        private readonly List<TranslationRule> _translations;

        public Translator(List<TranslationRule> rules)
        {
            _translations = rules;
        }

        public Translator(string section)
        {
            var ruleLines = ParseData.ChopToList('\n', section);
            _translations = new List<TranslationRule>();

            foreach (var rule in ruleLines)
            {
                var values = rule.Split(" ", StringSplitOptions.TrimEntries);
                _translations.Add(new TranslationRule(long.Parse(values[0]),
                    long.Parse(values[1]),
                    long.Parse(values[2])));
            }
        }

        public long Translate(long input)
        {
            foreach (var translation in _translations)
            {
                if (input >= translation.Source && input < translation.Source + translation.Steps)
                {
                    return input + translation.Destination - translation.Source;
                }
            }
            return input;
        }
    }
}
