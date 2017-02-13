namespace XMatchers.Core
{
    internal class AnythingMatcher<T> : Matcher<T>
    {
        private readonly string _message;

        public AnythingMatcher() : this("ANYTHING") { }

        public AnythingMatcher(string message)
        {
            _message = message;
        }

        public override bool Matches(T item)
        {
            return true;
        }

        public override void DescribeTo(IDescription description)
        {
            description.AppendText(_message);
        }
    }
}