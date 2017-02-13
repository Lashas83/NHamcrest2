using System;
using System.Collections;
using System.Collections.Generic;
using XMatchers.Core;

namespace XMatchers
{
    public class Is
    {
        public static Matcher<object> Anything()
        {
            return new AnythingMatcher<object>();
        }

        public static Matcher<object> Anything(string description)
        {
            return new AnythingMatcher<object>(description);
        }

        public static IMatcher<T> EqualTo<T>(T value)
        {
            return IsEqualMatcher<T>.EqualTo(value);
        }

        public static IMatcher<bool> True()
        {
            return IsEqualMatcher<bool>.EqualTo(true);
        }

        public static IMatcher<bool> False()
        {
            return IsEqualMatcher<bool>.EqualTo(false);
        }

        public static IMatcher<T> GreaterThan<T>(T value) where T : IComparable<T>
        {
            return new IsGreaterThanMatcher<T>(value);
        }

        public static IMatcher<T> GreaterThanOrEqualTo<T>(T value) where T : IComparable<T>
        {
            return new IsGreaterThanOrEqualToMatcher<T>(value);
        }

        public static IMatcher<object> InstanceOf<T>()
        {
            return new IsInstanceOfMatcher<T>();
        }

        public static IMatcher<object> InstanceOf(Type expectedType)
        {
            return new IsInstanceOfMatcher(expectedType);
        }

        public static IMatcher<object> Any<T>()
        {
            return new IsInstanceOfMatcher<T>();
        }

        public static IMatcher<T> LessThan<T>(T value) where T : IComparable<T>
        {
            return new IsLessThanMatcher<T>(value);
        }

        public static IMatcher<T> LessThanOrEqualTo<T>(T value) where T : IComparable<T>
        {
            return new IsLessThanOrEqualToMatcher<T>(value);
        }

        public static IMatcher<T> Not<T>(T value)
        {
            return Not(EqualTo(value));
        }

        public static Matcher<T> Not<T>(IMatcher<T> matcher)
        {
            return new IsNotMatcher<T>(matcher);
        }

        public static IMatcher<T> Null<T>()
        {
            return new IsNullMatcher<T>();
        }

        public static IMatcher<object> Null()
        {
            return new IsNullMatcher();
        }

        public static IMatcher<T> NotNull<T>()
        {
            return Not(Null<T>());
        }

        public static IMatcher<object> NotNull()
        {
            return Not(Null());
        }

        public static IMatcher<T> SameAs<T>(T @object)
        {
            return new IsSameMatcher<T>(@object);
        }

        public static IMatcher<ICollection> OfLength(int length)
        {
            return new LengthMatcher<ICollection>(length);
        }

        public static IMatcher<IEnumerable<T>> OfLength<T>(int length)
        {
            return new TypedLengthMatcher<T>(length);
        }

        public static IMatcher<IEnumerable<T>> SetOf<T>(IEnumerable<IMatcher<T>> elementMatchers)
        {
            return new IsEquivalentSetMatcher<T>(elementMatchers);
        }

        public static IMatcher<IEnumerable<T>> SetOf<T>(params IMatcher<T>[] elementMatchers)
        {
            return new IsEquivalentSetMatcher<T>(elementMatchers);
        }

        public static IMatcher<IEnumerable<T>> ListOf<T>(IEnumerable<IMatcher<T>> elementMatchers)
        {
            return new IsEquivalentListMatcher<T>(elementMatchers);
        }

        public static IMatcher<IEnumerable<T>> ListOf<T>(params IMatcher<T>[] elementMatchers)
        {
            return new IsEquivalentListMatcher<T>(elementMatchers);
        }

        public static IMatcher<T> StructurallyEqualTo<T>(T exampleValue)
        {
            return new StructuralComparisonMatcher<T>(exampleValue);
        }

        public static IMatcher<T> OfType<T, TDest>(IMatcher<TDest> exampleValue)
        {
            return new CastMatcher<T, TDest>(exampleValue);
        }
    }
}