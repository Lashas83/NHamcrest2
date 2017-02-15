using System.Text;

namespace XMatchers.Core
{
    public class StringDescription : Description
    {
        private readonly StringBuilder _out;

        public StringDescription() : this(new StringBuilder()) { }

        public StringDescription(StringBuilder @out)
        {
            _out = @out;
        }

        protected override void Append(string str)
        {
            _out.Append(str);
        }

        public override string ToString()
        {
            return _out.ToString();
        }
    }
}