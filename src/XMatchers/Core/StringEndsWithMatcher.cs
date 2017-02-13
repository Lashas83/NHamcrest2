namespace XMatchers.Core
{
    internal class StringEndsWithMatcher : SubstringMatcher
    {
        public StringEndsWithMatcher(string substring) : base(substring)
        {
        }

        protected override bool EvalSubstringOf(string @string)
        {
            return @string.EndsWith(Substring, StringComparison);
        }

        protected override string Relationship()
        {
            return "ending with";
        }
    }
}