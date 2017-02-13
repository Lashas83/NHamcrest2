using System;

namespace XMatchers.Tests.TestClasses
{
    public class ClassWithArrayOfClasses
    {
        public Guid Id { get; set; }
        public SimpleFlatClass[] OtherThings { get; set; }
    }
}