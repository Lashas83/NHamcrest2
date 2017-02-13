using System.Collections.Generic;
using XMatchers.Core;

namespace XMatchers
{
    public static class Matches
    {
        public static IMatcher<T> AllOf<T>(IEnumerable<IMatcher<T>> matchers)
        {
            return new AllOfMatcher<T>(matchers);
        }

        public static IMatcher<T> AllOf<T>(params IMatcher<T>[] matchers)
        {
            return new AllOfMatcher<T>(matchers);
        }

        public static IMatcher<T> AnyOf<T>(IEnumerable<IMatcher<T>> matchers)
        {
            return new AnyOfMatcher<T>(matchers);
        }

        public static IMatcher<T> AnyOf<T>(params IMatcher<T>[] matchers)
        {
            return new AnyOfMatcher<T>(matchers);
        }

        public static CombinableMatcher<T> Both<T>(IMatcher<T> matcher)
        {
            return new CombinableMatcher<T>(matcher);
        }

        public static CombinableMatcher<T> Either<T>(IMatcher<T> matcher)
        {
            return new CombinableMatcher<T>(matcher);
        }
    }
}