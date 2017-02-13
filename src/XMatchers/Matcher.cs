namespace XMatchers
{
    public abstract class Matcher<T> : IMatcher<T>
    {
        public virtual void DescribeTo(IDescription description) { }

        public virtual bool Matches(T item) { return false; }

        public virtual void DescribeMismatch(T item, IDescription mismatchDescription)
        {
            mismatchDescription.AppendText("was ").AppendValue(item);
        }

        public override string ToString()
        {
            var description = new StringDescription();
            DescribeTo(description);
            return description.ToString();
        }
    }
}