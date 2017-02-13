using System;

namespace XMatchers.Core
{
	internal class IsLessThanOrEqualToMatcher<T> : Matcher<T> where T : IComparable<T>
	{
		private readonly T _object;

		public IsLessThanOrEqualToMatcher(T arg)
		{
			_object = arg;
		}

		public override void DescribeTo(IDescription description)
		{
			description.AppendText("less than or equal to ").AppendValue(_object);
		}

		public override bool Matches(T arg)
		{
			return arg.CompareTo(_object) <= 0;
		}
	}
}