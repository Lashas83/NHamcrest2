using XMatchers.Core;

namespace XMatchers
{
    public static class Contains
    {
        public static IMatcher<string> String(string substring)
        {
            return new StringContainsMatcher(substring);
        }
    }
}