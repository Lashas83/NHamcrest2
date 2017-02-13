using System;

namespace XMatchers.Core
{
	internal class IsGreaterThanOrEqualToMatcher<T> : Matcher<T> where T : IComparable<T>
	{
		private readonly T _object;

		public IsGreaterThanOrEqualToMatcher(T arg)
		{
			_object = arg;
		}

		public override void DescribeTo(IDescription description)
		{
			description.AppendText("greater than or equal to ").AppendValue(_object);
		}

		public override bool Matches(T arg)
		{
			return arg.CompareTo(_object) >= 0;
		}
	}
}