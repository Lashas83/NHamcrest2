using System;

namespace XMatchers.Core
{
	internal class IsGreaterThanMatcher<T> : Matcher<T> where T : IComparable<T>
	{
		private readonly T _object;

		public IsGreaterThanMatcher(T arg)
		{
			_object = arg;
		}

		public override void DescribeTo(IDescription description)
		{
			description.AppendText("greater than ").AppendValue(_object);
		}

		public override bool Matches(T arg)
		{
			return arg.CompareTo(_object) > 0;
		}
	}
}