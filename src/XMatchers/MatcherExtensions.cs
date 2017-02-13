using System.Collections.Generic;
using System.Linq;

namespace XMatchers
{
    public static class MatcherExtensions
    {
        public static CastMatcherBuilder<T> InCollection<T>(this IMatcher<IEnumerable<T>> matcher)
        {
            return new CastMatcherBuilder<T>(matcher);
        }
    }

    public class CastMatcherBuilder<TDerived>
    {
        private readonly IMatcher<IEnumerable<TDerived>> _derivedMatcher;

        public CastMatcherBuilder(IMatcher<IEnumerable<TDerived>> derivedMatcher)
        {
            _derivedMatcher = derivedMatcher;
        }

        public IMatcher<IEnumerable<TBase>> OfType<TBase>()
        {
            return new OfTypeMatcher<TDerived, TBase>(_derivedMatcher);
        }
    }

    class OfTypeMatcher<TDerived, TBase> : IMatcher<IEnumerable<TBase>>
    {
        private readonly IMatcher<IEnumerable<TDerived>> _matcher;

        public OfTypeMatcher(IMatcher<IEnumerable<TDerived>> matcher)
        {
            _matcher = matcher;
        }

        public void DescribeTo(IDescription description)
        {
            _matcher.DescribeTo(description);
        }

        public bool Matches(IEnumerable<TBase> item)
        {
            return _matcher.Matches(item.OfType<TDerived>());
        }

        public void DescribeMismatch(IEnumerable<TBase> item, IDescription mismatchDescription)
        {
            _matcher.DescribeMismatch(item.OfType<TDerived>(), mismatchDescription);
        }
    }
}