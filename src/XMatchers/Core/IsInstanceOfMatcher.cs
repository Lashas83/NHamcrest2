using System;
using System.Reflection;

namespace XMatchers.Core
{
    internal class IsInstanceOfMatcher<T> : DiagnosingMatcher<object>
    {
        private readonly Type _expectedType;

        public IsInstanceOfMatcher() : this(typeof(T)) { }

        protected IsInstanceOfMatcher(Type expectedType)
        {
            _expectedType = expectedType;
        }
        
        protected override bool Matches(object item, IDescription mismatchDescription)
        {
            if (ReferenceEquals(item, null))
            {
                mismatchDescription.AppendText("null");
                return false;
            }

            if (_expectedType.GetTypeInfo().IsInstanceOfType(item) == false)
            {
                mismatchDescription.AppendValue(item).AppendFormat(" is an instance of {0} not {1}", item.GetType().FullName, 
                    _expectedType.FullName);
                return false;
            }

            return true;
        }

        public override void DescribeTo(IDescription description)
        {
            description.AppendText("an instance of ").AppendText(_expectedType.FullName);
        }
    }

    internal class IsInstanceOfMatcher : IsInstanceOfMatcher<object>
    {
        public IsInstanceOfMatcher(Type expectedType) : base(expectedType) { }
    }
}