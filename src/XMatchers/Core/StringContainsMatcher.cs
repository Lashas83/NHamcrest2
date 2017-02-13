namespace XMatchers.Core
{
    internal class StringContainsMatcher : SubstringMatcher
    {
        public StringContainsMatcher(string substring) : base(substring) { }

        protected override bool EvalSubstringOf(string s)
        {
            return s.IndexOf(Substring, StringComparison) >= 0;
        }

        protected override string Relationship()
        {
            return "containing";
        }
    }
}