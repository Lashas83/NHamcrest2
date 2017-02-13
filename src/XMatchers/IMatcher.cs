namespace XMatchers
{
    public interface IMatcher<in T> : ISelfDescribing
    {
        bool Matches(T item);
        void DescribeMismatch(T item, IDescription mismatchDescription);
    }
}