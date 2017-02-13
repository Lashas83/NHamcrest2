using System.Collections.Generic;

namespace XMatchers.Core
{
    internal class EveryMatcher<T> : NonNullDiagnosingMatcher<IEnumerable<T>>
    {
        private readonly IMatcher<T> matcher;

        public EveryMatcher(IMatcher<T> matcher)
        {
            this.matcher = matcher;
        }

        protected override bool MatchesSafely(IEnumerable<T> collection, IDescription mismatchDescription)
        {
            foreach (var item in collection)
            {
                if (matcher.Matches(item))
                    continue;

                mismatchDescription.AppendText("an item ");
                matcher.DescribeMismatch(item, mismatchDescription);
                return false;
            }
            return true;
        }

        public override void DescribeTo(IDescription description)
        {
            description.AppendText("every item ").AppendDescriptionOf(matcher);
        }
    }
}