namespace XMatchers.Core
{
    internal class StringStartsWithMatcher : SubstringMatcher
    {
        public StringStartsWithMatcher(string substring) : base(substring)
        {
        }

        protected override bool EvalSubstringOf(string @string)
        {
            return @string.StartsWith(Substring, StringComparison);
        }

        protected override string Relationship()
        {
            return "starting with";
        }
    }
}