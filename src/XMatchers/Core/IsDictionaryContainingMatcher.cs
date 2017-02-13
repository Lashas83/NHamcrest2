using System.Collections.Generic;
using System.Linq;

namespace XMatchers.Core
{
    class IsDictionaryContainingMatcher<TKey, TValue> : NonNullDiagnosingMatcher<IDictionary<TKey, TValue>>
    {
        private readonly IMatcher<TKey> _keyMatcher;
        private readonly IMatcher<TValue> _valueMatcher;

        public IsDictionaryContainingMatcher(IMatcher<TKey> keyMatcher, IMatcher<TValue> valueMatcher)
        {
            _keyMatcher = keyMatcher;
            _valueMatcher = valueMatcher;
        }

        protected override bool MatchesSafely(IDictionary<TKey, TValue> dictionary, IDescription mismatchDescription)
        {
            var matchedKeyEntries = dictionary.Where(entry => _keyMatcher.Matches(entry.Key)).ToArray();

            if (matchedKeyEntries.Length > 0)
            {
                return TryMatchValues(matchedKeyEntries, mismatchDescription);
            }
            else
            {
                DescribeEntryMismatches(dictionary, mismatchDescription, false);
                return false;
            }
        }

        private void DescribeEntryMismatches(IEnumerable<KeyValuePair<TKey, TValue>> entries, IDescription mismatchDescription, bool keysMatched)
        {
            var separate = false;

            foreach (var entry in entries)
            {
                if (separate)
                {
                    mismatchDescription.AppendText(",").AppendNewLine();
                }

                mismatchDescription.AppendText("[Key: ");
                if (keysMatched)
                {
                    mismatchDescription.AppendText(entry.Key.ToString());
                }
                else
                {
                    _keyMatcher.DescribeMismatch(entry.Key, mismatchDescription);
                }

                mismatchDescription.AppendText(", Value: ");
                _valueMatcher.DescribeMismatch(entry.Value, mismatchDescription);
                mismatchDescription.AppendText("]");

                separate = true;
            }
        }



        private bool TryMatchValues(KeyValuePair<TKey, TValue>[] matchedKeyEntries, IDescription mismatchDescription)
        {
            if (matchedKeyEntries.Any(entry => _valueMatcher.Matches(entry.Value))) return true;
            DescribeEntryMismatches(matchedKeyEntries, mismatchDescription, true);
            return false;
        }

        public override void DescribeTo(IDescription description)
        {
            description.AppendText("a dictionary containing entry [Key: ")
                .AppendDescriptionOf(_keyMatcher)
                .AppendText(", Value: ")
                .AppendDescriptionOf(_valueMatcher)
                .AppendText("]");
        }
    }
}
