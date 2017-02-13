using System.Collections.Generic;

namespace XMatchers.Core
{
    internal class AllOfMatcher<T> : DiagnosingMatcher<T>
    {
        private readonly IEnumerable<IMatcher<T>> _matchers;

        public AllOfMatcher(IEnumerable<IMatcher<T>> matchers)
        {
            _matchers = matchers;
        }

        protected override bool Matches(T item, IDescription mismatchDescription)
        {
            foreach (var matcher in _matchers)
            {
                if (matcher.Matches(item))
                    continue;

                mismatchDescription
                    .AppendText("while trying to match:")
                    .AppendNewLine()
                    .AppendDescriptionOf(matcher)
                    .AppendText(" got: ")
                    .AppendNewLine();
                matcher.DescribeMismatch(item, mismatchDescription);
                return false;
            }

            return true;
        }

        public override void DescribeTo(IDescription description)
        {
            description.AppendList("(", " " + "and" + " ", ")", _matchers);
        }        
    }
}