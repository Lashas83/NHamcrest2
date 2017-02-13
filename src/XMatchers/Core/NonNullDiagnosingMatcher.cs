namespace XMatchers.Core
{
    public abstract class NonNullDiagnosingMatcher<T> : Matcher<T>
    {
        protected abstract bool MatchesSafely(T collection, IDescription mismatchDescription);

        public override bool Matches(T item)
        {
            return ReferenceEquals(item, null) == false && MatchesSafely(item, new NullDescription());
        }

        public override void DescribeMismatch(T item, IDescription mismatchDescription)
        {
            if (ReferenceEquals(item, null))
            {
                base.DescribeMismatch(item, mismatchDescription);
            }
            else
            {
                MatchesSafely(item, mismatchDescription);
            }
        }
    }
}