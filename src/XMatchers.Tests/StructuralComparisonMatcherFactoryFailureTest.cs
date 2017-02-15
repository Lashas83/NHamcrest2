﻿using XMatchers.Core;
using Xunit;
using Assert = XMatchers.Xunit.Assert;

namespace XMatchers.Tests
{
    public abstract class StructuralComparisonMatcherFactoryFailureTest<T>
    {
        private readonly IMatcher<T> _matcher;
        private readonly T _matched;

        protected abstract string ExpectMatcherDescription();
        protected abstract T CreateExampleValue();
        protected abstract T CreateMatchedValue();
        protected abstract string ExpectMismatchDescription();

        protected StructuralComparisonMatcherFactoryFailureTest()
        {
            var example = CreateExampleValue();
            _matcher = Is.StructurallyEqualTo(example);
            _matched = CreateMatchedValue();
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
            var expected = ExpectMismatchDescription();
            var actual = description.ToString();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MatcherDescriptionMustBeCorrect()
        {
            var expected = ExpectMatcherDescription();
            var description = new StringDescription();
            _matcher.DescribeTo(description);
            var actual = description.ToString();

            Assert.Equal(expected, actual);
        }
    }
}