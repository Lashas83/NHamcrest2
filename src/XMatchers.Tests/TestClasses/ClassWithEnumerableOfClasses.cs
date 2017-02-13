using System.Collections.Generic;

namespace XMatchers.Tests.TestClasses
{
    public class ClassWithEnumerableOfClasses
    {
        public int IntValue { get; set; }
        public IEnumerable<SimpleFlatClass> OtherThings { get; set; }
    }
}