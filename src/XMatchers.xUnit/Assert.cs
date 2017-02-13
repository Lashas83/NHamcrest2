using System;
using System.Diagnostics;
using System.Threading.Tasks;
using XMatchers;
using Xunit.Sdk;

namespace XMatchers.Xunit
{
    public partial class Assert
    {
        public static void That<T>(T actual, XMatchers.IMatcher<T> matcher)
        {
            if (matcher.Matches(actual))
                return;

            var description = new StringDescription();
            matcher.DescribeTo(description);

            var mismatchDescription = new StringDescription();
            matcher.DescribeMismatch(actual, mismatchDescription);

            throw new MatchException(description.ToString(), mismatchDescription.ToString(), null);
        }

        [DebuggerHidden]
        public static async Task<T> EventuallyThat<T>(Func<Task<T>> requestFunction, IMatcher<T> matcher, int timeToWait = 5000, int interval = 500)
        {
            var sw = new Stopwatch();
            try
            {
                sw.Start();
                var result = default(T);
                while (sw.ElapsedMilliseconds <= timeToWait)
                {
                    result = await requestFunction();
                    if (matcher.Matches(result))
                        return result;

                    await Task.Delay(interval);
                }

                That(result, matcher);

                return result;
            }
            finally
            {
                sw.Stop();
            }
        }

        [Serializable]
        public class MatchException : AssertActualExpectedException
        {
            public MatchException(object expected, object actual, string userMessage)
                : base(expected, actual, userMessage)
            {
            }
        }
    }
}