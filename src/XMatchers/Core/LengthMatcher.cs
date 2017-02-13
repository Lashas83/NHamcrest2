﻿using System.Collections;

namespace XMatchers.Core
{
    public class LengthMatcher<T> : IMatcher<T>
        where T : ICollection
    {
        private readonly int _length;

        public LengthMatcher(int length)
        {
            _length = length;
        }

        public void DescribeTo(IDescription description)
        {
            description.AppendFormat("a collection of length {0}", _length);
        }

        public bool Matches(T item)
        {
            return Matches(item, new NullDescription());
        }

        public void DescribeMismatch(T item, IDescription mismatchDescription)
        {
            Matches(item, mismatchDescription);
        }

        private bool Matches(T collection, IDescription mismatchDescription)
        {
            if (collection.Count == _length) return true;

            mismatchDescription.AppendFormat("collection had length {0}", collection.Count);
            return false;
        }
    }
}
