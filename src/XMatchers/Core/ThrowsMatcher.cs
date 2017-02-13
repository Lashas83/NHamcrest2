using System;

namespace XMatchers.Core
{
	internal class ThrowsMatcher<T> : DiagnosingMatcher<Action> where T : Exception
	{
		private Predicate<T> _predicate = e => true;

		public override void DescribeTo(IDescription description)
		{
			description.AppendFormat("the block to throw an exception of type {0}", typeof(T));
		}

		protected override bool Matches(Action action, IDescription mismatchDescription)
		{
			try
			{
				action();
				mismatchDescription.AppendText("no exception was thrown");
			}
			catch (T ex)
			{
				if (_predicate(ex))
					return true;

				mismatchDescription.AppendText("the exception was of the correct type, but did not match the predicate")
					.AppendNewLine()
					.AppendValue(ex);
			}
			catch (Exception ex)
			{
                mismatchDescription.AppendFormat("an exception of type {0} was thrown", ex.GetType())
					.AppendNewLine()
					.AppendValue(ex);
			}
			return false;
		}

        public ThrowsMatcher<T> With(Predicate<T> predicate)
		{
			_predicate = predicate;
			return this;
		}
	}
}