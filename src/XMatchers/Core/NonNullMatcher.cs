namespace XMatchers.Core
{
    public abstract class NonNullMatcher<T> : Matcher<T> where T : class
    {
        protected abstract bool MatchesSafely(T item);

        public virtual void DescribeMismatchSafely(T item, IDescription mismatchDescription)
        {
            base.DescribeMismatch(item, mismatchDescription);
        }

        public sealed override bool Matches(T item)
        {
            return item != null && MatchesSafely(item);
        }

        public override void DescribeMismatch(T item, IDescription description)
        {
            if (item == null)
            {
                base.DescribeMismatch(item, description);
            }
            else
            {
                DescribeMismatchSafely(item, description);
            }
        }
    }
}