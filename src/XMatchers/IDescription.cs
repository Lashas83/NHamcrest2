using System;
using System.Collections.Generic;

namespace XMatchers
{
    public interface IDescription
    {
        IDescription AppendText(string text);
        IDescription AppendFormat(string format, params object[] args);
        IDescription AppendDescriptionOf(ISelfDescribing value);
        IDescription AppendValue(object value);
		IDescription AppendNewLine();
        IDescription AppendValueList<T>(string start, string separator, string end, IEnumerable<T> values);
        IDescription AppendList(string start, string separator, string end, IEnumerable<ISelfDescribing> values);

        IDisposable IndentBy(int numberOfSpaces);
    }
}