using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMatchers.Tests.TestClasses;
using Xunit;
using Assert = XMatchers.Xunit.Assert;

namespace XMatchers.Tests
{
    public class ListOfComparisonMatcher_IsEmpty : ListOfComparisonMatcherSuccessTest<int>
    {
        protected override int[] Value => new int[0];
        protected override string ExpectedMatcherDescription => "an empty list";
    }

    public class ListOfComparisonMatcher_HasSingleInt : ListOfComparisonMatcherSuccessTest<int>
    {
        protected override int[] Value => new[] { 1 };
        protected override string ExpectedMatcherDescription => "a list containing:" + Environment.NewLine + "    1";
    }

    public class ListOfComparisonMatcher_HasSameListOfInts : ListOfComparisonMatcherSuccessTest<int>
    {
        protected override int[] Value => new[] { 3,4,5 };
        protected override string ExpectedMatcherDescription => "a list containing:" + Environment.NewLine 
            + "    3," + Environment.NewLine
            + "    4," + Environment.NewLine
            + "    5";
    }

    public class ListOfComparisonMatcher_HasSameListOfSimpleFlatClasses : ListOfComparisonMatcherSuccessTest<SimpleFlatClass>
    {
        protected override SimpleFlatClass[] Value => new[]
        {
            new SimpleFlatClass() {IntProperty = 5, StringProperty = "foo"},
            new SimpleFlatClass() {IntProperty = 14, StringProperty = "bar"}
        };

        protected override string ExpectedMatcherDescription => "a list containing:" + Environment.NewLine
                + "    a(n) SimpleFlatClass where:" + Environment.NewLine
                + "        member IntProperty value is 5" + Environment.NewLine
                + "        member StringProperty value is \"foo\"," + Environment.NewLine 
                + "    a(n) SimpleFlatClass where:" + Environment.NewLine
                + "        member IntProperty value is 14"+ Environment.NewLine 
                + "        member StringProperty value is \"bar\"";

        protected override IMatcher<SimpleFlatClass> Matcher(SimpleFlatClass expected)
        {
            return Describe.Object<SimpleFlatClass>()
                .Property(x => x.IntProperty, Is.EqualTo(expected.IntProperty))
                .Property(x => x.StringProperty, Is.EqualTo(expected.StringProperty));
        }
    }

    public abstract class ListOfComparisonMatcherSuccessTest<T>
    {
        private readonly IMatcher<IEnumerable<T>> _matcher;
        private readonly T[] _matched;

        protected abstract T[] Value { get; }
        protected abstract string ExpectedMatcherDescription { get; }

        protected virtual T[] MatchedValue => Value;

        [SuppressMessage("ReSharper", "VirtualMemberCallInContructor")]
        protected ListOfComparisonMatcherSuccessTest()
        {
            var example = Value;
            _matcher = Is.ListOf(example.Select(Matcher));
            _matched = MatchedValue;
        }

        protected virtual IMatcher<T> Matcher(T expected)
        {
            return Is.EqualTo(expected);
        }

        [Fact]
        public void MatcherShouldMatchValue()
        {
            Assert.That(_matched, _matcher);
        }

        [Fact]
        public void MatcherDescriptionMustBeCorrect()
        {
            var expected = ExpectedMatcherDescription;
            var description = new StringDescription();
            _matcher.DescribeTo(description);
            var actual = description.ToString();

            Assert.Equal(expected, actual);
        }
    }
}
