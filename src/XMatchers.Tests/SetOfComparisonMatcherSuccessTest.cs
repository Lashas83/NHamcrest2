using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMatchers.Core;
using XMatchers.Tests.TestClasses;
using Xunit;
using Assert = XMatchers.Xunit.Assert;

namespace XMatchers.Tests
{
    public class EmptyListIsEqualToEmptySet : SetOfComparisonMatcherSuccessTest<int>
    {
        protected override int[] ExampleValue => new int[0];
        protected override int[] MatchedValue => new int[0];
        protected override string ExpectedMatcherDescription => "an empty set";
    }

    public class ListOfSingleElementIsEqualToSetOfSingleElement : SetOfComparisonMatcherSuccessTest<int>
    {
        protected override int[] ExampleValue => new[] { 1 };
        protected override int[] MatchedValue => new[] { 1 };
        protected override string ExpectedMatcherDescription => "a set containing:" + Environment.NewLine + "    1";
    }

    public class ListOfSameOrderIsEqualToSetOfSameOrder : SetOfComparisonMatcherSuccessTest<int>
    {
        protected override int[] ExampleValue => new[] { 3, 4, 5 };
        protected override int[] MatchedValue => new[] { 3, 4, 5 };
        protected override string ExpectedMatcherDescription => "a set containing:" + Environment.NewLine
            + "    3," + Environment.NewLine
            + "    4," + Environment.NewLine
            + "    5";
    }

    public class ListOfDifferentOrderIsEqualToSetOf : SetOfComparisonMatcherSuccessTest<int>
    {
        protected override int[] ExampleValue => new[] { 3, 4, 5 };
        protected override int[] MatchedValue => new[] { 4, 5, 3 };
        protected override string ExpectedMatcherDescription => "a set containing:" + Environment.NewLine
            + "    3," + Environment.NewLine
            + "    4," + Environment.NewLine
            + "    5";
    }

    //public class ListOfComparisonMatcher_HasSameListOfSimpleFlatClasses : SetOfComparisonMatcherSuccessTest<SimpleFlatClass>
    //{
    //    protected override SimpleFlatClass[] Value => new[]
    //    {
    //        new SimpleFlatClass() {IntProperty = 5, StringProperty = "foo"},
    //        new SimpleFlatClass() {IntProperty = 14, StringProperty = "bar"}
    //    };

    //    protected override string ExpectedMatcherDescription => "a list containing:" + Environment.NewLine
    //            + "    a(n) SimpleFlatClass where:" + Environment.NewLine
    //            + "        member IntProperty value is 5" + Environment.NewLine
    //            + "        member StringProperty value is \"foo\"," + Environment.NewLine 
    //            + "    a(n) SimpleFlatClass where:" + Environment.NewLine
    //            + "        member IntProperty value is 14"+ Environment.NewLine 
    //            + "        member StringProperty value is \"bar\"";

    //    protected override IMatcher<SimpleFlatClass> Matcher(SimpleFlatClass expected)
    //    {
    //        return Describe.Object<SimpleFlatClass>()
    //            .Property(x => x.IntProperty, Is.EqualTo(expected.IntProperty))
    //            .Property(x => x.StringProperty, Is.EqualTo(expected.StringProperty));
    //    }
    //}

    public abstract class SetOfComparisonMatcherSuccessTest<T>
    {
        private readonly IMatcher<IEnumerable<T>> _matcher;
        private readonly T[] _matched;

        protected abstract T[] ExampleValue { get; }
        protected abstract string ExpectedMatcherDescription { get; }
        //protected virtual T[] MatchedValue => ExampleValue;
        protected abstract T[] MatchedValue { get; }

        [SuppressMessage("ReSharper", "VirtualMemberCallInContructor")]
        protected SetOfComparisonMatcherSuccessTest()
        {
            var example = ExampleValue;
            _matcher = Is.SetOf(example.Select(Matcher));
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
