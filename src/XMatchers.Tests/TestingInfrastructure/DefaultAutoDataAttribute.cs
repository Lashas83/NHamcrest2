using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Xunit2;

namespace XMatchers.Tests.TestingInfrastructure
{
    public class DefaultAutoDataAttribute : InlineAutoDataAttribute
    {
        public DefaultAutoDataAttribute() : this(new object[0])
        {
            
        }

        public DefaultAutoDataAttribute(params object[] values) : base(values)
        {
            var fixture = AutoDataAttribute.Fixture;
            fixture.Inject(fixture);
        }
    }
}
