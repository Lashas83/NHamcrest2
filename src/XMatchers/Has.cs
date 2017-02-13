using System.Collections.Generic;
using XMatchers.Core;

namespace XMatchers
{
    public static class Has
    {
        public static IMatcher<IEnumerable<T>> Item<T>(IMatcher<T> elementMatcher)
        {
            return new IsCollectionContainingMatcher<T>(elementMatcher);
        }

        public static IMatcher<IEnumerable<T>> Items<T>(params IMatcher<T>[] elementMatchers)
        {
            var all = new List<IMatcher<IEnumerable<T>>>();
            
            foreach (var elementMatcher in elementMatchers)
            {
                var matcher = new IsCollectionContainingMatcher<T>(elementMatcher);
                all.Add(matcher);
            }

            return Matches.AllOf(all);
        }

        public static IMatcher<IDictionary<TKey, TValue>> Entry<TKey, TValue>(IMatcher<TKey> keyMatcher, IMatcher<TValue> valueMatcher)
        {
            return new IsDictionaryContainingMatcher<TKey, TValue>(keyMatcher, valueMatcher);
        }
    }
}