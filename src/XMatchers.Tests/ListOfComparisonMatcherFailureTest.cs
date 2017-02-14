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
    //public class EmptyListIsNotEqualToNonEmptyList : ListOfComparisonMatcherFailureTest<int>
    //{
    //    protected override int[] ExampleValues => new int[] { 1 };
    //    protected override string ExpectedMatcherDescription => "an empty list";
    //    protected override string ExpectedMismatchDescription => "asfd";
    //}

    public class NonEmptyListIsNotEqualToEmptyList : ListOfComparisonMatcherFailureTest<int>
    {
        protected override int[] ExampleValues => new[] { 1 };
        protected override int[] MatchedValue => new int[0];
        protected override string ExpectedMatcherDescription => "an empty list";
        protected override string ExpectedMismatchDescription => "was too short (expected to be of length 1, was 0)";
    }

    public abstract class ListOfComparisonMatcherFailureTest<T>
    {
        private readonly IMatcher<IEnumerable<T>> _matcher;
        private readonly T[] _matched;

        protected abstract string ExpectedMatcherDescription { get; }
        protected abstract T[] ExampleValues { get; }
        protected virtual T[] MatchedValue => ExampleValues;
        protected abstract string ExpectedMismatchDescription { get; }

        [SuppressMessage("ReSharper", "VirtualMemberCallInContructor")]
        protected ListOfComparisonMatcherFailureTest()
        {
            var example = ExampleValues;
            _matcher = Is.ListOf(example.Select(Matcher));
            _matched = MatchedValue;
        }

        protected virtual IMatcher<T> Matcher(T expected)
        {
            return Is.EqualTo(expected);
        }

        [Fact]
        public void MatcherShouldNotMatchValue()
        {
            Assert.That(_matched, Is.Not(_matcher));
        }

        [Fact]
        public void MismatchDescriptionMustBeCorrect()
        {
            var description = new StringDescription();
            _matcher.DescribeMismatch(_matched, description);
            var expected = ExpectedMismatchDescription;
            var actual = description.ToString();
            Assert.Equal(expected, actual);
        }

        //[Fact]
        //public void MatcherDescriptionMustBeCorrect()
        //{
        //    var expected = ExpectedMatcherDescription;
        //    var description = new StringDescription();
        //    _matcher.DescribeTo(description);
        //    var actual = description.ToString();

        //    Assert.Equal(expected, actual);
        //}
    }
}
