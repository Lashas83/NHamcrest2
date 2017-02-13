using XMatchers.Core;

namespace XMatchers
{
    public static class Ends
    {
        public static IMatcher<string> With(string substring)
        {
            return new StringEndsWithMatcher(substring);
        }
    }
}