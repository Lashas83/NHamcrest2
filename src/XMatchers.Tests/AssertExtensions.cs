using XMatchers.Xunit;

namespace XMatchers.Tests
{
    public static class AssertExtensions
    {
        public static void ShouldHaveDescription(this ISelfDescribing matcher, string expected)
        {
            var description = new StringDescription();
            matcher.DescribeTo(description);
            var actual = description.ToString();

            Assert.Equal(expected, actual);
        }

        public static void ShouldHaveDescription(this ISelfDescribing matcher, IMatcher<string> expectedMatcher)
        {
            var description = new StringDescription();
            matcher.DescribeTo(description);
            var actual = description.ToString();

            Assert.That(actual, expectedMatcher);
        }

        public static void ShouldHaveMismatchDescriptionForValue<TMatched>(this IMatcher<TMatched> matcher, TMatched value, string expected)
        {
            var description = new StringDescription();
            matcher.DescribeMismatch(value, description);
            var actual = description.ToString();

            Assert.Equal(expected, actual);
        }

        public static void ShouldHaveMismatchDescriptionForValue<TMatched>(this IMatcher<TMatched> matcher, TMatched value, IMatcher<string> expectedMatcher)
        {
            var description = new StringDescription();
            matcher.DescribeMismatch(value, description);
            var actual = description.ToString();

            Assert.That(actual, expectedMatcher);
        }
    }
}