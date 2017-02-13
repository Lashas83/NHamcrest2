using System.Collections.Generic;

namespace XMatchers.Core
{
    internal class AnyOfMatcher<T> : Matcher<T>
    {
        private readonly IEnumerable<IMatcher<T>> _matchers;

        public AnyOfMatcher(IEnumerable<IMatcher<T>> matchers)
        {
            _matchers = matchers;
        }

        public override bool Matches(T item)
        {
            foreach (var matcher in _matchers)
            {
                if (matcher.Matches(item))
                    return true;
            }
            return false;
        }

        public override void DescribeTo(IDescription description)
        {
            description.AppendList("(", " " + "or" + " ", ")", _matchers);
        }
    }
}
