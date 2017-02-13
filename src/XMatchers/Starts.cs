using XMatchers.Core;

namespace XMatchers
{
    public static class Starts
    {
        public static IMatcher<string> With(string substring)
        {
            return new StringStartsWithMatcher(substring);
        }
    }
}