using System.Collections.Generic;
using XMatchers.Core;

namespace XMatchers
{
    public static class NotEvery
    {
        public static IMatcher<IEnumerable<T>> Item<T>(IMatcher<T> itemMatcher)
        {
            return new IsNotMatcher<IEnumerable<T>>(new EveryMatcher<T>(itemMatcher));
        }
    }
}