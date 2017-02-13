using System.Collections.Generic;
using XMatchers.Core;

namespace XMatchers
{
    public static class Every
    {
        public static IMatcher<IEnumerable<T>> Item<T>(IMatcher<T> itemMatcher)
        {
            return new EveryMatcher<T>(itemMatcher);
        }
    }
}