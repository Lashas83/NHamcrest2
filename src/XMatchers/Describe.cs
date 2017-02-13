using System.Linq;
using XMatchers.Core;

namespace XMatchers
{
    public static class Describe
    {
        public static IObjectFeatureMatcher<T> Object<T>()
        {
            return new ObjectFeatureMatcher<T>(Enumerable.Empty<IMatcher<T>>());
        }
    }
}