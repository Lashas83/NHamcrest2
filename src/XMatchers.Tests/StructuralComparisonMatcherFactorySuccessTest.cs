﻿using XMatchers.Core;
using Xunit;
using Assert = XMatchers.Xunit.Assert;

namespace XMatchers.Tests
{
    public abstract class StructuralComparisonMatcherFactorySuccessTest<T>
    {
        private readonly IMatcher<T> _matcher;
        private readonly T _matched;

        protected abstract T CreateValue();
        protected abstract string ExpectMatcherDescription();

        protected virtual T CreateMatchedValue()
        {
            return this.CreateValue();
        }

        protected StructuralComparisonMatcherFactorySuccessTest()
        {
            var example = CreateValue();
            _matcher = Is.StructurallyEqualTo(example);
            _matched = CreateMatchedValue();
        }

        [Fact]
        public void MatcherShouldMatchValue()
        {
            Assert.That(_matched, _matcher);
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
